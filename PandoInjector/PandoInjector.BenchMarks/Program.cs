namespace PandoInjector.BenchMarks
{
  using System;
  using BenchmarkDotNet.Running;

  /// <summary>
  /// The benchmarking program.
  /// </summary>
  internal static class Program
  {
    /// <summary>
    /// Entry point.
    /// </summary>
    private static void Main()
    {
      BenchmarkRunner.Run<Benchies>();

      Console.WriteLine("Press enter to quit");
      Console.ReadLine();
    }
  }
}