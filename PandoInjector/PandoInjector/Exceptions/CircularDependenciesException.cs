// Licensed under the MIT license.

namespace PandoInjector.Exceptions
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Runtime.Serialization;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// The circular dependencies exception.
  /// </summary>
  public class CircularDependenciesException
    : Exception
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CircularDependenciesException"/> class.
    /// </summary>
    public CircularDependenciesException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CircularDependenciesException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    public CircularDependenciesException(string? message)
      : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CircularDependenciesException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="innerException">The inner exception.</param>
    public CircularDependenciesException(string? message, Exception? innerException)
      : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CircularDependenciesException"/> class.
    /// </summary>
    /// <param name="info">The info.</param>
    /// <param name="context">The context.</param>
    protected CircularDependenciesException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}