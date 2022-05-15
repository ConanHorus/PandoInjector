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
  /// The many constructors exception.
  /// </summary>
  public class ManyConstructorsException
    : Exception
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ManyConstructorsException"/> class.
    /// </summary>
    public ManyConstructorsException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ManyConstructorsException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    public ManyConstructorsException(string? message)
      : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ManyConstructorsException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="innerException">The inner exception.</param>
    public ManyConstructorsException(string? message, Exception? innerException)
      : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ManyConstructorsException"/> class.
    /// </summary>
    /// <param name="info">The info.</param>
    /// <param name="context">The context.</param>
    protected ManyConstructorsException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}