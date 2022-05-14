// Licensed under the MIT license.

namespace PandoInjector
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// The container.
  /// </summary>
  public class Container
  {
    /// <summary>
    /// Container types.
    /// </summary>
    private readonly Dictionary<Type, Type> containerTypes = new Dictionary<Type, Type>();

    /// <summary>
    /// Registers the class with key.
    /// </summary>
    /// <returns>A bool.</returns>
    /// <typeparam name="Tkey">Key that is registering the class.</typeparam>
    /// <typeparam name="Tclass">Class being registered.</typeparam>
    public bool Register<Tkey, Tclass>()
      where Tkey : class
      where Tclass : class, Tkey
    {
      if (this.containerTypes.ContainsKey(typeof(Tkey)))
      {
        return false;
      }

      this.containerTypes.Add(typeof(Tkey), typeof(Tclass));
      return true;
    }
  }
}