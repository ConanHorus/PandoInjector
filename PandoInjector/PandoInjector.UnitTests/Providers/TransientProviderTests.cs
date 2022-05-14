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
  }
}