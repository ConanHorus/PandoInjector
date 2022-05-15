// Licensed under the MIT license.

namespace PandoInjector.Providers
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Reflection;
  using System.Text;
  using System.Threading.Tasks;
  using PandoInjector.Dependencies;
  using PandoInjector.Exceptions;

  /// <summary>
  /// The type provider.
  /// </summary>
  internal abstract class TypeProvider
  {
    /// <summary>
    /// Constructor info.
    /// </summary>
    private readonly ConstructorInfo constructorInfo;

    /// <summary>
    /// Array of dependencies.
    /// </summary>
    private readonly Type[] dependenciesArray;

    /// <summary>
    /// Initializes a new instance of the <see cref="TypeProvider"/> class.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="dependencyFinder">The dependency finder.</param>
    /// <exception cref="ManyConstructorsException">Type contains more than one constructor.</exception>
    public TypeProvider(Type type, IDependencyFinder dependencyFinder)
    {
      this.constructorInfo = dependencyFinder.FindConstructor(type);
      this.dependenciesArray = dependencyFinder.FindDependencies(this.constructorInfo);
    }

    /// <summary>
    /// Gets the instance.
    /// </summary>
    /// <param name="container">The container.</param>
    /// <param name="dependecyStack">The dependency stack.</param>
    /// <returns>An instance.</returns>
    /// <exception cref="NotRegisteredException">Type is not registered.</exception>
    public abstract object GetInstance(Container container, DependencyStack dependecyStack);

    /// <summary>
    /// Generates the instance.
    /// </summary>
    /// <param name="container">The container.</param>
    /// <param name="dependencyStack">The dependency stack.</param>
    /// <returns>An instance.</returns>
    /// <exception cref="NotRegisteredException">Type is not registered.</exception>
    protected object GenerateInstance(Container container, DependencyStack dependencyStack)
    {
      var parameters = this.dependenciesArray.Select(x => container.Resolve(x, dependencyStack)).ToArray();
      return this.constructorInfo.Invoke(parameters);
    }
  }
}