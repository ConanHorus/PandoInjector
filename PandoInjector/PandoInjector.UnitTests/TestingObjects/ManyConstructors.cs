namespace PandoInjector.UnitTests.TestingObjects
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// The many constructors class.
  /// </summary>
  internal class ManyConstructors
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ManyConstructors"/> class.
    /// </summary>
    /// <param name="simple">The simple instance.</param>
    public ManyConstructors(ISimple simple)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ManyConstructors"/> class.
    /// </summary>
    /// <param name="simple">The simple instance.</param>
    /// <param name="simpleDependency">The simple dependency instance.</param>
    public ManyConstructors(ISimple simple, ISimpleDependency simpleDependency)
    {
    }
  }
}