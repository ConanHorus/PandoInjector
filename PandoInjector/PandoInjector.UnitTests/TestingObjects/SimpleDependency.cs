namespace PandoInjector.UnitTests.TestingObjects
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// The simple dependency class.
  /// </summary>
  internal class SimpleDependency
    : ISimpleDependency
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="SimpleDependency"/> class.
    /// </summary>
    /// <param name="simple">The simple interface.</param>
    public SimpleDependency(ISimple simple)
    {
    }
  }
}