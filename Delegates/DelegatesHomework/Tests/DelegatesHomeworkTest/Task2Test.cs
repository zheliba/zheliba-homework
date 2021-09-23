using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DelegatesHomeworkTest
{
    [TestClass]
    public class Task2Test
    {
        [TestMethod]
        public void CountCharactersTestValid()
        {
            //--Arrange
            char c = 'k';
            string text = "keks";
            int expected = 2;

            //--Act
            int actual = Task2.Program.CountCharacters(c, text);

            //--Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CountCharactersTestValidNoChar()
        {
            //--Arrange
            char c = 'w';
            string text = "keks";
            int expected = 0;

            //--Act
            int actual = Task2.Program.CountCharacters(c, text);

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindCharacterTestValid()
        {
            //--Arrange
            char c = 'a';
            string text = "babushka";
            int expected = 2;

            //--Act
            int actual = Task2.Program.FindCharacter(c, text);
            Assert.AreEqual(expected, actual);

        }
    }
}
