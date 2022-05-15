namespace PandoInjector.IntegrationTests.TestingObjects
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// The circular class part B.
  /// </summary>
  internal class CircularB
    : ICircularB
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CircularB"/> class.
    /// </summary>
    /// <param name="circularC">The circular c.</param>
    public CircularB(ICircularC circularC)
    {
    }
  }
}