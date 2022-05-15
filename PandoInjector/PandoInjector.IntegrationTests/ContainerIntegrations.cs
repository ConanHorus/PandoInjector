namespace PandoInjector.IntegrationTests
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using NUnit.Framework;
  using PandoInjector.Exceptions;
  using PandoInjector.IntegrationTests.TestingObjects;

  /// <summary>
  /// The container integrations.
  /// </summary>
  [TestFixture]
  internal class ContainerIntegrations
  {
    /// <summary>
    /// Cow says moo.
    /// </summary>
    [Test]
    public void CowMoos()
    {
      var container = new Container();
      container.Register<IMoo, Moo>(LifeCycleType.Singleton);
      container.Register<ICow, Cow>();
      container.Build();

      var cow = container.Resolve<ICow>();

      Assert.AreEqual("moo", cow.MakeAnimalNoise());
    }

    /// <summary>
    /// Asking for interface that's not registered throws exception.
    /// </summary>
    [Test]
    public void NotRegistered()
    {
      var container = new Container();
      container.Register<ICow, Cow>();
      container.Build();

      Assert.Throws<NotRegisteredException>(() => container.Resolve<ICow>());
    }

    /// <summary>
    /// Resolving circular dependencies throws exception.
    /// </summary>
    [Test]
    public void CircularDependencies()
    {
      var container = new Container();
      container.Register<ICircularA, CircularA>();
      container.Register<ICircularB, CircularB>();
      container.Register<ICircularC, CircularC>();
      container.Build();

      Assert.Throws<CircularDependenciesException>(() => container.Resolve<ICircularA>());
    }
  }
}