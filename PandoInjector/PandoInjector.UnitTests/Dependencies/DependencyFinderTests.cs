namespace PandoInjector.UnitTests.Dependencies
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using NUnit.Framework;
  using PandoInjector.Dependencies;
  using PandoInjector.Exceptions;
  using PandoInjector.UnitTests.TestingObjects;

  /// <summary>
  /// The dependency finder tests.
  /// </summary>
  [TestFixture]
  internal class DependencyFinderTests
  {
    /// <summary>
    /// Finds the dependencies on object with no dependencies.
    /// </summary>
    [Test]
    public void FindDependenciesWithNoDependencies()
    {
      var finder = new DependencyFinder();
      var dependencies = finder.FindDependencies(typeof(Simple));

      Assert.AreEqual(0, dependencies.Length);
    }

    /// <summary>
    /// Finds the dependencies on object with dependencies.
    /// </summary>
    [Test]
    public void FindDependenciesWithDependencies()
    {
      var finder = new DependencyFinder();
      var dependencies = finder.FindDependencies(typeof(SimpleDependency));

      Assert.AreEqual(1, dependencies.Length);
    }

    /// <summary>
    /// Finds the dependencies and checks that correct type is returned.
    /// </summary>
    [Test]
    public void FindDependenciesReturnsCorrectTypes()
    {
      var finder = new DependencyFinder();
      var dependencies = finder.FindDependencies(typeof(SimpleDependency));

      Assert.AreEqual(typeof(ISimple), dependencies[0]);
    }

    /// <summary>
    /// Finds the dependencies and throws exception with many constructors.
    /// </summary>
    [Test]
    public void FindDependenciesThrowsExceptionWithManyConstructors()
    {
      var finder = new DependencyFinder();
      Assert.Throws<ManyConstructorsException>(() => finder.FindDependencies(typeof(ManyConstructors)));
    }
  }
}