// Licensed under the MIT license.

namespace PandoInjector
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Runtime.CompilerServices;
  using System.Text;
  using System.Threading.Tasks;
  using PandoInjector.Dependencies;
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
    /// Initializes a new instance of the <see cref="Container"/> class.
    /// </summary>
    /// <param name="dependencyFinder">The dependency finder.</param>
    internal Container(IDependencyFinder dependencyFinder) => this.dependencyFinder = dependencyFinder;

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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Build()
    {
      if (this.typeProviders is not null)
      {
        return;
      }

      this.GenerateTypeProvidersDictionary();
    }

    /// <summary>
    /// Generates the type providers dictionary.
    /// </summary>
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