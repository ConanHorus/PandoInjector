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
  /// The dependency finder.
  /// </summary>
  internal class DependencyFinder
    : IDependencyFinder
  {
    /// <inheritdoc/>
    public Type[] FindDependencies(Type type)
    {
      var constructor = this.FindConstructor(type);
      return this.FindDependencies(constructor);
    }

    /// <inheritdoc/>
    public Type[] FindDependencies(ConstructorInfo constructorInfo)
    {
      return constructorInfo.GetParameters().Select(p => p.ParameterType).ToArray();
    }

    /// <inheritdoc/>
    public ConstructorInfo FindConstructor(Type type)
    {
      var constructors = type.GetConstructors();
      if (constructors.Length > 1)
      {
        throw new ManyConstructorsException($"The type {type.Name} has more than one constructor");
      }

      return constructors[0];
    }
  }
}