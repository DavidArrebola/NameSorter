using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter.Classes;

namespace NameSorterTests
{
    [TestClass]
    public class SortByNameTests
    {
        [TestMethod]
        public void TestThatNamesAreSortedBySurname()
        {
            // Arrange
            var unsortedNames = new List<string>() { "Joe Blow", "Anna Versary", "Paul Ivy" };
            var expectedNamesSortedBySurname = new List<string>() { "Joe Blow", "Paul Ivy", "Anna Versary" };

            // Act
            var actualNamesSortedBySurname = SortByName.SortNamesBySurname(unsortedNames);

            // Assert
            var actualAndExpectedAreEqual = expectedNamesSortedBySurname.Zip(actualNamesSortedBySurname, (e, a) => e.SequenceEqual(a)).All(x => x);
            Assert.IsTrue(actualAndExpectedAreEqual);
        }

        [TestMethod]
        public void TestThatNamesWithSameSurnameAreSortedCorrectly()
        {
            // Arrange
            var unsortedNames = new List<string>() { "Lindsay Bluth", "Michael Bluth", "Buster Bluth" };
            var expectedNamesSortedBySurname = new List<string>() { "Buster Bluth", "Lindsay Bluth", "Michael Bluth" };

            // Act
            var actualNamesSortedBySurname = SortByName.SortNamesBySurname(unsortedNames);

            // Assert
            var actualAndExpectedAreEqual = expectedNamesSortedBySurname.Zip(actualNamesSortedBySurname, (e, a) => e.SequenceEqual(a)).All(x => x);
            Assert.IsTrue(actualAndExpectedAreEqual);
        }
    }
}