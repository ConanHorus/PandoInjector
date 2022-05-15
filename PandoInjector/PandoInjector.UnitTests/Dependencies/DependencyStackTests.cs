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
  /// The dependency stack tests.
  /// </summary>
  [TestFixture]
  internal class DependencyStackTests
  {
    /// <summary>
    /// Pushes the dependency.
    /// </summary>
    [Test]
    public void PushDependency()
    {
      var dependencyStack = new DependencyStack();

      dependencyStack.Push(typeof(ISimple));

      Assert.AreEqual(1, dependencyStack.Count);
    }

    /// <summary>
    /// Pops the dependency.
    /// </summary>
    [Test]
    public void PopDependency()
    {
      var dependencyStack = new DependencyStack();
      dependencyStack.Push(typeof(ISimple));

      dependencyStack.Pop();

      Assert.AreEqual(0, dependencyStack.Count);
    }

    /// <summary>
    /// Generates the exception string.
    /// </summary>
    [Test]
    public void GenerateExceptionString()
    {
      var dependencyStack = new DependencyStack();
      dependencyStack.Push(typeof(ISimpleDependency));
      dependencyStack.Push(typeof(ISimple));

      var exceptionString = dependencyStack.GenerateExceptionString();

      Assert.AreEqual("ISimpleDependency -> ISimple", exceptionString);
    }

    /// <summary>
    /// Circular dependency throws exception.
    /// </summary>
    [Test]
    public void CircularDependencyThrowsException()
    {
      var dependencyStack = new DependencyStack();
      dependencyStack.Push(typeof(ISimpleDependency));
      dependencyStack.Push(typeof(ISimple));
      Assert.Throws<CircularDependenciesException>(() => dependencyStack.Push(typeof(ISimple)));
    }
  }
}