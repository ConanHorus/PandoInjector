namespace PandoInjector.IntegrationTests.TestingObjects
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// The cow interface.
  /// </summary>
  internal interface ICow
  {
    /// <summary>
    /// Makes the animal noise.
    /// </summary>
    /// <returns>A string.</returns>
    string MakeAnimalNoise();
  }
}