using System;
using System.Collections.Generic;
using FnsComposite.Monads;
using NUnit.Framework;
using System.Xml.Linq;

namespace CompositeTests
{
    [TestFixture]
    public class MonadTests
    {
        [Test]
        public void BasicMonad()
        {
            var monad = new Monad<int>(1);
            var monad2 = monad.Bind(v => new Monad<int>(v));
            Assert.AreEqual(monad, monad2);
            Assert.AreNotSame(monad, monad2);
        }

        [Test]
        public void BasicMonadWithFactory()
        {
            var monad = Monad.Create(1);
            var monad2 = monad.Bind(v => Monad.Create(v));
            Assert.AreEqual(monad, monad2);
            Assert.AreNotSame(monad, monad2);
        }

        [Test]
        public void CreateIdentity()
        {
            var identity = Monad.Create(1);
            Assert.AreNotEqual(default(Monad<int>), identity);
        }

        [Test]
        public void IdentityEquivilence()
        {
            var x = Monad.Create(1);
            var y = Monad.Create(1);
            Assert.AreEqual(x, y);
            Assert.AreNotSame(x, y);
        }

        [Test]
        public void IdentityIdentityProjectionEquivilence()
        {
            var x = Monad.Create(1);
            var y = x.Select(v => v);
            var z = y.Select(a => a + 1);
            Assert.AreEqual(x, y);
            Assert.AreNotEqual(y, z);
            Assert.AreNotSame(x, y);
        }

        [Test]
        public void IdentityNonIdentityProjectionInequality()
        {
            var x = Monad.Create(1);
            var y = x.Select(v => v + 1);
            Assert.AreNotEqual(x, y);
        }

        [Test]
        public void SelectQuery()
        {
            var result = from x in Monad.Create(1)
                         select x.ToString();

            Assert.AreEqual("1", result.Value);
        }

        [Test]
        public void SelectManyQuery()
        {
            var result = from x in Monad.Create(2)
                         from y in Monad.Create(3)
                         select x + y;

            Assert.AreEqual(5, result.Value);
        }


        [Test]
        public void TestTryGetTuple()
        {
            var nameValues = new Dictionary<int, string>
                                 {
                                     {1, "One"},
                                     {2, "Two"},
                                     {3, "Three"},
                                     {4, "Four"},
                                     {5, "Five"}
                                 };

            Assert.IsNotNull(nameValues.TryGetTuple(3).Second);
            Assert.IsTrue(nameValues.TryGetTuple(5).First);
            Assert.IsFalse(nameValues.TryGetTuple(6).First);

            for (var i = 0; i <= nameValues.Count; ++i )
                Console.WriteLine(nameValues.TryGetTuple(i).Second ?? "(null)");
        }

        /// <summary>
        /// Tests the tuple.
        /// </summary>
        [Test]
        public void TestTuple()
        {
            var prague = new FnsComposite.Monads.Tuple<string, int>("Prague", 1188000);
            var seattle = new FnsComposite.Monads.Tuple<string, int>("Seattle", 12121212);

            PrintCity(prague);
            PrintCity(seattle);

            PrintCity(seattle.WithSecond(seattle.Second + 25));
        }

        static void PrintCity(FnsComposite.Monads.Tuple<string, int> cityInfo)
        {
            Console.WriteLine("Population of {0} is {1}.",
                cityInfo.First, cityInfo.Second);
        }

        [Test]
        public void TestCombinator()
        {
            Func<int, int> addOne = a => a + 1;
            Assert.IsTrue(addOne.Compose(addOne)(0) == 2);
            Func<int, int> minusOne = a => a - 1;
            Assert.IsTrue(addOne.Compose(minusOne)(0) == 0);
            var addSubtractOne = addOne.Compose(minusOne);
            foreach (var i in new[] {0,1,2,3,4,5})
                Assert.IsTrue(addSubtractOne(i) == i);

            foreach (var i in new[] { 0, 1, 2, 3, 4, 5 })
            {
                // test Left Identity
                Assert.IsTrue(i.Identity() == addSubtractOne(i));
                // test right Identity
                Assert.IsTrue(addSubtractOne(i.Identity()) == i);
            }
        }

		[Test]
		public void TestMaybeMonadWith()
		{
			Console.WriteLine("Default(string) = {0}", default(string));
			Console.WriteLine("Default(int) = {0}", default(int));
			Console.WriteLine("Default(DateTime) = {0}", default(DateTime));
			Console.WriteLine("Default(XElement) = {0}", default(XElement));

			var address = default(object);
			var person = new
			             	{
			             		Name = "John J Gwynn",
								Address = address,
			             		Phone = "6178862064"
			             	};

			const XElement node = null;

			Assert.AreEqual(person.With(a => a.Address) ?? "null",
				node
				.With(a => a.FirstNode )
				.Return(a => a.ToString(), "null"));

			Assert.AreEqual(person.With(a => a.Address) , address.With(a => a.ToString()));
			Console.WriteLine(person);
			Console.WriteLine("Address = {0}", person.Return(a => a.Address, "null"));


		}
    }
}
