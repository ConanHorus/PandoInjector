namespace PandoInjector.IntegrationTests.TestingObjects
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// The circular class part C.
  /// </summary>
  internal class CircularC
    : ICircularC
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CircularC"/> class.
    /// </summary>
    /// <param name="circularA">The circular a.</param>
    public CircularC(ICircularA circularA)
    {
    }
  }
}