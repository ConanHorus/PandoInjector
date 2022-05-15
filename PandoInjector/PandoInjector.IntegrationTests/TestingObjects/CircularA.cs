namespace PandoInjector.IntegrationTests.TestingObjects
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// The circular class part A.
  /// </summary>
  internal class CircularA
    : ICircularA
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CircularA"/> class.
    /// </summary>
    /// <param name="circularB">The circular b.</param>
    public CircularA(ICircularB circularB)
    {
    }
  }
}