namespace PandoInjector.UnitTests
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using NUnit.Framework;
  using PandoInjector.UnitTests.TestingObjects;

  /// <summary>
  /// The container tests.
  /// </summary>
  [TestFixture]
  internal class ContainerTests
  {
    /// <summary>
    /// Registering takes interface and class.
    /// </summary>
    /// <remarks>
    /// This unit test's implicit assert is that there is an object container and
    /// that it registers a class with its lookup key.
    /// </remarks>
    [Test]
    private void RegisteringTakesInterfaceAndClass()
    {
      var container = new Container();
      bool success = container.Register<ISimple, Simple>();

      Assert.IsTrue(success);
    }

    /// <summary>
    /// Registering the same class twice returns false.
    /// </summary>
    [Test]
    private void RegisteringSameClassTwiceReturnsFalse()
    {
      var container = new Container();
      container.Register<ISimple, Simple>();
      bool success = container.Register<ISimple, Simple>();

      Assert.IsFalse(success);
    }
  }
}