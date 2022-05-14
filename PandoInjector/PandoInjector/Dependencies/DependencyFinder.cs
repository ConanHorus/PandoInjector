// Licensed under the MIT license.

namespace PandoInjector.Dependencies
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// The dependency finder.
  /// </summary>
  internal class DependencyFinder
    : IDependencyFinder
  {
    /// <inheritdoc/>
    public Type[] FindDependencies(Type type)
    {
      return Array.Empty<Type>();
    }
  }
}