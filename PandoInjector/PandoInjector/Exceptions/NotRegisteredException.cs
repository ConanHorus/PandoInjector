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
  /// The not registered exception.
  /// </summary>
  public class NotRegisteredException
    : Exception
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="NotRegisteredException"/> class.
    /// </summary>
    public NotRegisteredException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotRegisteredException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    public NotRegisteredException(string? message)
      : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotRegisteredException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="innerException">The inner exception.</param>
    public NotRegisteredException(string? message, Exception? innerException)
      : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotRegisteredException"/> class.
    /// </summary>
    /// <param name="info">The info.</param>
    /// <param name="context">The context.</param>
    protected NotRegisteredException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}