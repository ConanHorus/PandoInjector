// Licensed under the MIT license.

namespace PandoInjector.Dependencies
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using PandoInjector.Exceptions;

  /// <summary>
  /// The dependency stack.
  /// </summary>
  internal class DependencyStack
  {
    /// <summary>
    /// Internal stack.
    /// </summary>
    private readonly Stack<Type> stack = new Stack<Type>();

    /// <summary>
    /// Gets the count.
    /// </summary>
    public int Count => this.stack.Count;

    /// <summary>
    /// Pushes the type onto this stack.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <exception cref="CircularDependenciesException">Circular dependency detected.</exception>
    public void Push(Type type)
    {
      bool isCircular = this.stack.Contains(type);
      this.stack.Push(type);

      if (isCircular)
      {
        throw new CircularDependenciesException($"A circular dependency was detected in chain: {this.GenerateExceptionString()}");
      }
    }

    /// <summary>
    /// Pops off and returns last item on the stack.
    /// </summary>
    /// <returns>A Type.</returns>
    public Type Pop()
    {
      return this.stack.Pop();
    }

    /// <summary>
    /// Generates the exception string.
    /// </summary>
    /// <returns>An object.</returns>
    internal string GenerateExceptionString()
    {
      var stringBuilder = new StringBuilder();
      foreach ((var type, int index) in this.stack.Select((x, i) => (x, i)))
      {
        if (index > 0)
        {
          stringBuilder.Insert(0, " -> ");
        }

        stringBuilder.Insert(0, type.Name);
      }

      return stringBuilder.ToString();
    }
  }
}