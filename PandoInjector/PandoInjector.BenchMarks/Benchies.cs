namespace PandoInjector.BenchMarks
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using BenchmarkDotNet.Attributes;
  using PandoInjector.BenchMarks.TestingObjects;

  /// <summary>
  /// The benchies.
  /// </summary>
  [MemoryDiagnoser]
  public class Benchies
  {
    /// <summary>
    /// Singletons container.
    /// </summary>
    private readonly Container singletonsContainer = new Container();

    /// <summary>
    /// Transients container.
    /// </summary>
    private readonly Container transientsContainer = new Container();

    /// <summary>
    /// Initializes a new instance of the <see cref="Benchies"/> class.
    /// </summary>
    public Benchies()
    {
      this.singletonsContainer.Register<ICow, Cow>(LifeCycleType.Singleton);
      this.singletonsContainer.Register<IMoo, Moo>(LifeCycleType.Singleton);

      this.transientsContainer.Register<ICow, Cow>();
      this.transientsContainer.Register<IMoo, Moo>();
    }

    /// <summary>
    /// Gets the singletons.
    /// </summary>
    [Benchmark]
    public void GetSingletons()
    {
      _ = this.singletonsContainer.Resolve<ICow>();
    }

    /// <summary>
    /// Gets the transients.
    /// </summary>
    [Benchmark]
    public void GetTransients()
    {
      _ = this.transientsContainer.Resolve<ICow>();
    }
  }
}