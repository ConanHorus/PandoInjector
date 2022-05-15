namespace PandoInjector.UnitTests.Providers
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using Moq;
  using NUnit.Framework;
  using PandoInjector.Dependencies;
  using PandoInjector.Providers;
  using PandoInjector.UnitTests.TestingObjects;

  /// <summary>
  /// The transient provider tests.
  /// </summary>
  [TestFixture]
  internal class TransientProviderTests
  {
    /// <summary>
    /// Inherits the type provider.
    /// </summary>
    [Test]
    public void InheritsTypeProvider()
    {
      var provider = new TransientProvider(typeof(Simple), new Mock<IDependencyFinder>().Object);
      Assert.IsTrue(provider is TypeProvider);
    }

    /// <summary>
    /// Resolves with no dependencies.
    /// </summary>
    [Test]
    public void ResolveWithNoDependencies()
    {
      var container = new Container();
      container.Build();

      var provider = new TransientProvider(typeof(Simple), new DependencyFinder());
      var instance = provider.GetInstance(container, new DependencyStack());

      Assert.IsNotNull(instance);
    }

    /// <summary>
    /// Resolve generates new instance each time.
    /// </summary>
    [Test]
    public void ResolveGeneratesNewInstanceEachTime()
    {
      var container = new Container();
      container.Build();

      var provider = new TransientProvider(typeof(Simple), new DependencyFinder());
      var instance1 = provider.GetInstance(container, new DependencyStack());
      var instance2 = provider.GetInstance(container, new DependencyStack());

      Assert.IsFalse(ReferenceEquals(instance1, instance2));
    }
  }
}