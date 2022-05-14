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
  }
}