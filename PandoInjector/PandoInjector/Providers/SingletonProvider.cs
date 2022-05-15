// Licensed under the MIT license.

namespace PandoInjector.Providers
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using PandoInjector.Dependencies;
  using PandoInjector.Exceptions;

  /// <summary>
  /// The singleton provider class.
  /// </summary>
  internal class SingletonProvider
    : TypeProvider
  {
    /// <summary>
    /// Cached instance.
    /// </summary>
    private object? cachedInstance;

    /// <summary>
    /// Initializes a new instance of the <see cref="SingletonProvider"/> class.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="dependencyFinder">The dependency finder.</param>
    /// <exception cref="ManyConstructorsException">Type contains more than one constructor.</exception>
    public SingletonProvider(Type type, IDependencyFinder dependencyFinder)
      : base(type, dependencyFinder)
    {
    }

    /// <inheritdoc/>
    public override object GetInstance(Container container, DependencyStack dependencyStack)
    {
      if (this.cachedInstance is null)
      {
        this.cachedInstance = this.GenerateInstance(container, dependencyStack);
      }

      return this.cachedInstance;
    }
  }
}