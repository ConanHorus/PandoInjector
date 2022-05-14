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
  /// The type provider.
  /// </summary>
  internal abstract class TypeProvider
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="TypeProvider"/> class.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="dependencyFinder">The dependency finder.</param>
    public TypeProvider(Type type, IDependencyFinder dependencyFinder)
    {
      var dependenciesList = dependencyFinder.FindDependencies(type);
    }
  }
}