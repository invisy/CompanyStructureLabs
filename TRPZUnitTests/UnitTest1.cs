using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using TRPZ;

namespace TRPZUnitTests
{
    [TestFixture]
    public class Tests
    {
        private Company company = new Company();
        [SetUp]
        public void Setup()
        {
            Director dir = new Director()
            {
                FullName = "Test Director",
                Position = "Test position",
                Wage = 123

            };
            Manager manager = new Manager()
            {
                FullName = " Test Manager",
                Position = " Test manager position",
                Wage = 321
            };
            Worker worker1 = new Worker()
            {
                FullName = "Test worker",
                Position = "Test worker position",
                Wage = 12321
            };

            Worker worker2 = new Worker()
            {
                FullName = "Test worker 2",
                Position = "Test worker position 2",
                Wage = 12321
            };
            List<ICommandable> dirSub = new List<ICommandable>();
            dirSub.Add(manager);
            dirSub.Add(worker2);
            dir.DirectSubordinates = dirSub;
            List<ICommandable> manSub = new List<ICommandable>();
            manSub.Add(worker1);
            manager.DirectSubordinates = manSub;
            company.Director = dir;
        }

        [Test]
        public void CanBeLoaded()
        {
            //Arrange
            var path = "D:/Study/TRPZ/Test.txt";
            var expected = company;
            //Act
            var actual = LoadSave.Load(path);
            //Assert
            expected.Should().BeEquivalentTo(actual);
        }
    }
}