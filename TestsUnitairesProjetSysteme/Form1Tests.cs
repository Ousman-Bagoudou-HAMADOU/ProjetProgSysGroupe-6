using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;
using System;

namespace Test_TDD
{
    [TestClass]
    public class Form1Tests
    {
        [TestMethod]
        public void button5_Click_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var form1 = new Form1();
            object sender = null;
            EventArgs e = null;

            // Act
            form1.button5_Click(
                sender,
                e);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void envoinapp_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var form1 = new Form1();

            // Act
            form1.envoinapp();

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void Form1_Paint_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var form1 = new Form1();
            object sender = null;
            PaintEventArgs e = null;

            // Act
            form1.Form1_Paint(
                sender,
                e);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void timer1_Tick_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var form1 = new Form1();
            object sender = null;
            EventArgs e = null;

            // Act
            form1.timer1_Tick(
                sender,
                e);

            // Assert
            Assert.Fail();
        }
    }
}
