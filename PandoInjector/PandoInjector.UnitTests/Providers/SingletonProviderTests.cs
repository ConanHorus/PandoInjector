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
  /// The singleton provider tests.
  /// </summary>
  [TestFixture]
  internal class SingletonProviderTests
  {
    /// <summary>
    /// Inherits the type provider.
    /// </summary>
    [Test]
    public void InheritsTypeProvider()
    {
      var provider = new SingletonProvider(typeof(Simple), new Mock<IDependencyFinder>().Object);
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

      var provider = new SingletonProvider(typeof(Simple), new DependencyFinder());
      var instance = provider.GetInstance(container, new DependencyStack());

      Assert.IsNotNull(instance);
    }

    /// <summary>
    /// Resolve generates same instance each time.
    /// </summary>
    [Test]
    public void ResolveGeneratesSameInstanceEachTime()
    {
      var container = new Container();
      container.Build();

      var provider = new SingletonProvider(typeof(Simple), new DependencyFinder());
      var instance1 = provider.GetInstance(container, new DependencyStack());
      var instance2 = provider.GetInstance(container, new DependencyStack());

      Assert.IsTrue(ReferenceEquals(instance1, instance2));
    }
  }
}