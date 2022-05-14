// Licensed under the MIT license.

namespace PandoInjector.Dependencies
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// The dependency finder interface.
  /// </summary>
  public interface IDependencyFinder
  {
    /// <summary>
    /// Finds the dependencies.
    /// </summary>
    /// <param name="type">The type to find dependencies for.</param>
    /// <returns>An array of Types.</returns>
    Type[] FindDependencies(Type type);
  }
}