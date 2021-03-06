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
  /// The transient provider.
  /// </summary>
  internal class TransientProvider
    : TypeProvider
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="TransientProvider"/> class.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="dependencyFinder">The dependency finder.</param>
    /// <exception cref="ManyConstructorsException">Type contains more than one constructor.</exception>
    public TransientProvider(Type type, IDependencyFinder dependencyFinder)
      : base(type, dependencyFinder)
    {
    }

    /// <inheritdoc/>
    public override object GetInstance(Container container, DependencyStack dependencyStack)
    {
      return this.GenerateInstance(container, dependencyStack);
    }
  }
}