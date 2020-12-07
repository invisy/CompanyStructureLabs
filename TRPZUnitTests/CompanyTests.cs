using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TRPZ;

namespace TRPZUnitTests
{
    [TestFixture]
    public class CompanyTests
    {
        private Company company = new Company();
        private List<Employee> heightOrderTest = new List<Employee>();
        private List<Employee> directOrderTest = new List<Employee>();
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
                Wage = 12
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
            heightOrderTest.Add(dir);
            heightOrderTest.Add(manager);
            heightOrderTest.Add(worker2);
            heightOrderTest.Add(worker1);

            directOrderTest.Add(dir);
            directOrderTest.Add(manager);
            directOrderTest.Add(worker1);
            directOrderTest.Add(worker2);
        }

        [Test]
        public void Load_Company_Success()
        {
            //Arrange
            var path = "D:/Study/TRPZ/Test.txt";
            var expected = company;
            //Act
            var actual = LoadSave.Load(path);
            //Assert
            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void AddSubordinateToManager_Worker_Success()
        {
            //Arrange
            var worker = new Worker()
            {
                FullName = "test",
                Position = "test",
                Wage = 123
            };
            var manager = new Manager();
            List<ICommandable> subordinates = new List<ICommandable>();
            subordinates.Add(worker);
            manager.DirectSubordinates = subordinates;
            var expected = manager;
            //Act
            var actual = new Manager();
            actual.AddSubordinate(worker);
            //Assert
            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void AddSubordinateToDirector_Worker_Success()
        {
            //Arrange
            var worker = new Worker()
            {
                FullName = "test",
                Position = "test",
                Wage = 123
            };
            var director = new Director();
            List<ICommandable> subordinates = new List<ICommandable>();
            subordinates.Add(worker);
            director.DirectSubordinates = subordinates;
            var expected = director;
            //Act
            var actual = new Director();
            actual.AddSubordinate(worker);
            //Assert
            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void SearchByPosition_TestWorkerPosition_ReturnsListOfWorkers()
        {
            var position = "Test worker position";
            Worker worker1 = new Worker()
            {
                FullName = "Test worker",
                Position = "Test worker position",
                Wage = 12
            };
            List<Employee> expected = new List<Employee>();
            expected.Add(worker1);

            var actual = company.SearchByPosition(position);


            expected.Should().BeEquivalentTo(actual);
        }
        [Test]
        public void SearchDirectSubordinates_Director_ReturnsListOfDirectorsSubordinates()
        {
         
            List<ICommandable> subordinates = company.Director.DirectSubordinates;
            var mock = new Mock<ICommander>();
            mock.SetupGet(x => x.DirectSubordinates).Returns(subordinates);
            var expected = subordinates;

            var actual = company.SearchDirectSubordinates(company.Director);


            expected.Should().BeEquivalentTo(actual);
        }
        [Test]
        public void SearchByWage_321_ReturnsListOfEmployeesWithSameWage()
        {
            Manager manager = new Manager()
            {
                FullName = " Test Manager",
                Position = " Test manager position",
                Wage = 321
            };
            var wage = 321;
            List<Employee> expected = new List<Employee>();
            expected.Add(company.Director.DirectSubordinates[0] as Employee);
            expected.Add(company.Director.DirectSubordinates[1] as Employee);
           
            var actual = company.SearchByWage(wage);


            expected.Should().BeEquivalentTo(actual);
        }
        [Test]
        public void DirectOrder_Director_ReturnsListOfEmployeesInDirectOrder()
        {
            var expected = directOrderTest;
            var direct = new DirectOrder();
            var actual = direct.DisplayEmployees(company.Director);
            expected.Should().BeEquivalentTo(actual);
         
        }
        [Test]
        public void OrderByPosition_Director_ReturnsListOfEmployeesByPosition()
        {
            var expected = heightOrderTest;
            var height = new OrderByPosition();
            var actual = height.DisplayEmployees(company.Director);
            expected.Should().BeEquivalentTo(actual);
        }
    }
}