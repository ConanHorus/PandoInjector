// Licensed under the MIT license.

namespace PandoInjector
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// The life cycle type.
  /// </summary>
  public enum LifeCycleType
  {
    /// <summary>
    /// Transient life cycle. New object instance will be returned each time one is requested.
    /// </summary>
    Transient,

    /// <summary>
    /// Singleton life cycle. Same object instance will always be returned.
    /// </summary>
    Singleton,
  }
}