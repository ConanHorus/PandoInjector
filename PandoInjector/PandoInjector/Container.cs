// Licensed under the MIT license.

namespace PandoInjector
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics.CodeAnalysis;
  using System.Linq;
  using System.Runtime.CompilerServices;
  using System.Text;
  using System.Threading.Tasks;
  using PandoInjector.Dependencies;
  using PandoInjector.Exceptions;
  using PandoInjector.Providers;

  /// <summary>
  /// The container.
  /// </summary>
  public class Container
  {
    /// <summary>
    /// Container types.
    /// </summary>
    private readonly Dictionary<Type, (Type type, LifeCycleType lifeCycle)> containerTypes =
      new Dictionary<Type, (Type type, LifeCycleType lifeCycle)>();

    /// <summary>
    /// Dependency finder.
    /// </summary>
    private readonly IDependencyFinder dependencyFinder;

    /// <summary>
    /// Type providers.
    /// </summary>
    private Dictionary<Type, TypeProvider>? typeProviders;

    /// <summary>
    /// Initializes a new instance of the <see cref="Container"/> class.
    /// </summary>
    public Container() => this.dependencyFinder = new DependencyFinder();

    /// <summary>
    /// Resolves the instance of T.
    /// </summary>
    /// <returns>A T.</returns>
    /// <typeparam name="T">Type to resolve.</typeparam>
    /// <exception cref="ManyConstructorsException">Type contains more than one constructor.</exception>
    /// <exception cref="NotRegisteredException">Type is not registered.</exception>
    /// <exception cref="CircularDependenciesException">Circular dependency detected.</exception>
    public T Resolve<T>()
      where T : class
    {
      return (T)this.Resolve(typeof(T));
    }

    /// <summary>
    /// Registers the class with key.
    /// </summary>
    /// <param name="lifeCycle">Life cycle definition.</param>
    /// <returns>A bool.</returns>
    /// <typeparam name="Tkey">Key that is registering the class.</typeparam>
    /// <typeparam name="Tclass">Class being registered.</typeparam>
    public bool Register<Tkey, Tclass>(LifeCycleType lifeCycle = LifeCycleType.Transient)
      where Tkey : class
      where Tclass : class, Tkey
    {
      this.typeProviders = null;
      if (this.containerTypes.ContainsKey(typeof(Tkey)))
      {
        return false;
      }

      this.containerTypes.Add(typeof(Tkey), (typeof(Tclass), lifeCycle));
      return true;
    }

    /// <summary>
    /// Builds the registrations.
    /// </summary>
    /// <exception cref="ManyConstructorsException">Type contains more than one constructor.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [MemberNotNull(nameof(typeProviders))]
    public void Build()
    {
      if (this.typeProviders is not null)
      {
        return;
      }

      this.GenerateTypeProvidersDictionary();
    }

    /// <summary>
    /// Resolves the type.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>An object.</returns>
    /// <exception cref="ManyConstructorsException">Type contains more than one constructor.</exception>
    /// <exception cref="NotRegisteredException">Type is not registered.</exception>
    /// <exception cref="CircularDependenciesException">Circular dependency detected.</exception>
    public object Resolve(Type type)
    {
      return this.Resolve(type, new DependencyStack());
    }

    /// <summary>
    /// Resolves the type.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="dependencyStack">The dependency stack.</param>
    /// <returns>An object.</returns>
    /// <exception cref="ManyConstructorsException">Type contains more than one constructor.</exception>
    /// <exception cref="NotRegisteredException">Type is not registered.</exception>
    /// <exception cref="CircularDependenciesException">Circular dependency detected.</exception>
    internal object Resolve(Type type, DependencyStack dependencyStack)
    {
      dependencyStack.Push(type);
      this.Build();

      if (!this.typeProviders.ContainsKey(type))
      {
        throw new NotRegisteredException($"The type {type.Name} is not registered");
      }

      var instance = this.typeProviders[type].GetInstance(this, dependencyStack);
      dependencyStack.Pop();
      return instance;
    }

    /// <summary>
    /// Generates the type providers dictionary.
    /// </summary>
    /// <exception cref="ManyConstructorsException">Type contains more than one constructor.</exception>
    [MemberNotNull(nameof(typeProviders))]
    private void GenerateTypeProvidersDictionary()
    {
      this.typeProviders = new Dictionary<Type, TypeProvider>();
      foreach (var pair in this.containerTypes)
      {
        TypeProvider provider = this.GenerateTypeProvider(pair);

        this.typeProviders.Add(pair.Key, provider);
      }
    }

    /// <summary>
    /// Generates the type provider.
    /// </summary>
    /// <param name="pair">The pair.</param>
    /// <returns>A TypeProvider.</returns>
    /// <exception cref="ManyConstructorsException">Type contains more than one constructor.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TypeProvider GenerateTypeProvider(KeyValuePair<Type, (Type type, LifeCycleType lifeCycle)> pair)
    {
      return pair.Value.lifeCycle switch
      {
        LifeCycleType.Singleton => new SingletonProvider(pair.Value.type, this.dependencyFinder),
        _ => new TransientProvider(pair.Value.type, this.dependencyFinder),
      };
    }
  }
}