namespace PandoInjector.IntegrationTests.TestingObjects
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// The moo class.
  /// </summary>
  internal class Moo
    : IMoo
  {
    /// <inheritdoc/>
    public string MakeNoise()
    {
      return "moo";
    }
  }
}