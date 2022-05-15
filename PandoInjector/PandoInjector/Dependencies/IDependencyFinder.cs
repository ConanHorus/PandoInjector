// Licensed under the MIT license.

namespace PandoInjector.Dependencies
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Reflection;
  using System.Text;
  using System.Threading.Tasks;
  using PandoInjector.Exceptions;

  /// <summary>
  /// The dependency finder interface.
  /// </summary>
  public interface IDependencyFinder
  {
    /// <summary>
    /// Finds the dependencies from object type.
    /// </summary>
    /// <param name="type">The type to find dependencies for.</param>
    /// <returns>An array of Types.</returns>
    /// <exception cref="ManyConstructorsException">Type contains more than one constructor.</exception>
    Type[] FindDependencies(Type type);

    /// <summary>
    /// Finds the dependencies from construct info.
    /// </summary>
    /// <param name="constructorInfo">The constructor info to find dependencies from.</param>
    /// <returns>An array of Types.</returns>
    Type[] FindDependencies(ConstructorInfo constructorInfo);

    /// <summary>
    /// Finds the constructor.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>A ConstructorInfo.</returns>
    /// <exception cref="ManyConstructorsException">Type contains more than one constructor.</exception>
    ConstructorInfo FindConstructor(Type type);
  }
}