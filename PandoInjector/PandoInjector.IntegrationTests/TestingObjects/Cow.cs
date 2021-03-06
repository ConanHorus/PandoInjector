namespace PandoInjector.IntegrationTests.TestingObjects
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// The cow class.
  /// </summary>
  internal class Cow
    : ICow
  {
    /// <summary>
    /// The moo instance.
    /// </summary>
    private IMoo moo;

    /// <summary>
    /// Initializes a new instance of the <see cref="Cow"/> class.
    /// </summary>
    /// <param name="moo">The moo.</param>
    public Cow(IMoo moo) => this.moo = moo;

    /// <inheritdoc/>
    public string MakeAnimalNoise()
    {
      return this.moo.MakeNoise();
    }
  }
}