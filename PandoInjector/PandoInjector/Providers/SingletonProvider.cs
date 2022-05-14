// Licensed under the MIT license.

namespace PandoInjector.Providers
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using PandoInjector.Dependencies;

  /// <summary>
  /// The singleton provider class.
  /// </summary>
  internal class SingletonProvider
    : TypeProvider
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="SingletonProvider"/> class.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="dependencyFinder">The dependency finder.</param>
    public SingletonProvider(Type type, IDependencyFinder dependencyFinder)
      : base(type, dependencyFinder)
    {
    }
  }
}