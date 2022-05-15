namespace PandoInjector.UnitTests
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Reflection;
  using System.Text;
  using System.Threading.Tasks;
  using Moq;
  using NUnit.Framework;
  using PandoInjector.Dependencies;
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
    public void RegisteringTakesInterfaceAndClass()
    {
      var container = new Container();
      bool success = container.Register<ISimple, Simple>();

      Assert.IsTrue(success);
    }

    /// <summary>
    /// Registering the same class twice returns false.
    /// </summary>
    [Test]
    public void RegisteringSameClassTwiceReturnsFalse()
    {
      var container = new Container();
      container.Register<ISimple, Simple>();
      bool success = container.Register<ISimple, Simple>();

      Assert.IsFalse(success);
    }

    /// <summary>
    /// Builds collection with no dependencies.
    /// </summary>
    [Test]
    public void BuildWithNoDependencies()
    {
      var container = new Container();
      container.Register<ISimple, Simple>();
      Assert.DoesNotThrow(() => container.Build());
    }

    /// <summary>
    /// Builds container with dependencies.
    /// </summary>
    public void BuildWithDependencies()
    {
      // Removed test which was testing internal behavior, not results
    }
  }
}