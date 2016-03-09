using grade_scores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for MyFileTest and is intended
    ///to contain all MyFileTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MyFileTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Work: to read a vallid file
        ///</summary>
        [TestMethod()]
        public void WorkTest1()
        {
            string strPath = string.Empty; // TODO: Initialize to an appropriate value
            MyFile target = new MyFile(strPath); // TODO: Initialize to an appropriate value
            string strPath1 = "F:\\Temp\\names.txt"; // TODO: Initialize to an appropriate value
            bool expected = System.IO.File.Exists(strPath1); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Work(strPath1);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Work: to read an invalid file
        ///</summary>
        [TestMethod()]
        public void WorkTest2()
        {
            string strPath = string.Empty; // TODO: Initialize to an appropriate value
            MyFile target = new MyFile(strPath); // TODO: Initialize to an appropriate value
            string strPath1 = "abc"; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Work(strPath1);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test valid data
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest1()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "BUNDY, TERESSA, 88"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = new MyStudent("BUNDY", "TERESSA", 88); // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.Surname, expected.Surname);
            Assert.AreEqual(actual.Score, expected.Score);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test invalid line number
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest2()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "BUNDY, TERESSA, 88"; // TODO: Initialize to an appropriate value
            int nLineNumber = 0; // TODO: Initialize to an appropriate value
            MyStudent expected = null; // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual, expected);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test invalid data - 4 columns
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest3()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "BUNDY, TERESSA, 88, ?"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = null; // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual, expected);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test invalid data - 2 columns
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest4()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "BUNDY, TERESSA"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = null; // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual, expected);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test invalid data - empty line
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest5()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = ""; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = null; // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual, expected);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test invalid data - space line
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest6()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "  "; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = null; // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual, expected);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test invalid data - invalid name
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest7()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "BU*NDY, TERESSA, 88"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = null; // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual, expected);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test invalid data - invalid surname
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest8()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "BUNDY, TERE8SSA, 88"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = null; // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual, expected);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test invalid data - invalid score not a number
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest9()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "BUNDY, TERESSA, score"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = null; // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual, expected);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test invalid data - invalid score smaller than 0
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest10()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "BUNDY, TERESSA, -1"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = null; // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual, expected);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test invalid data - invalid score bigger than 100
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest11()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "BUNDY, TERESSA, 101"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = null; // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual, expected);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test valid data - score 0
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest12()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "BUNDY, TERESSA, 0"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = new MyStudent("BUNDY", "TERESSA", 0); // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.Surname, expected.Surname);
            Assert.AreEqual(actual.Score, expected.Score);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test valid data - score 100
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest13()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "BUNDY, TERESSA, 100"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = new MyStudent("BUNDY", "TERESSA", 100); // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.Surname, expected.Surname);
            Assert.AreEqual(actual.Score, expected.Score);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test invalid data - score with +
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest14()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "BUNDY, TERESSA, +95"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = null; // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual, expected);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test invalid data - missing name
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest15()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = " , TERESSA, 88"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = null; // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual, expected);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test invalid data - missing surname
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest16()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "BUNDY, , 88"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = null; // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual, expected);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test invalid data - missing score
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest17()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "BUNDY, TERESSA, "; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = null; // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual, expected);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test invalid data - missing name trimmed
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest18()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = ",TERESSA,88"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = null; // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual, expected);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test invalid data - missing surname trimmed
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest19()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "BUNDY,,88"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = null; // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual, expected);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test invalid data - missing score trimmed
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest20()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "BUNDY,TERESSA,"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = null; // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual, expected);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test valid data - trimmed
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest21()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "BUNDY,TERESSA,88"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = new MyStudent("BUNDY", "TERESSA", 88); // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.Surname, expected.Surname);
            Assert.AreEqual(actual.Score, expected.Score);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test valid data - duplicated spaces
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest22()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "  BUNDY   ,  TERESSA , 88  "; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = new MyStudent("BUNDY", "TERESSA", 88); // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.Surname, expected.Surname);
            Assert.AreEqual(actual.Score, expected.Score);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test valid data - middle name (name contains space)
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest23()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "  BUN DY   ,  TERESSA , 88  "; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = new MyStudent("BUN DY", "TERESSA", 88); // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.Surname, expected.Surname);
            Assert.AreEqual(actual.Score, expected.Score);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test valid data - middle name (name contains space) trimmed
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest24()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "BU N DY,TERESSA,88"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = new MyStudent("BU N DY", "TERESSA", 88); // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.Surname, expected.Surname);
            Assert.AreEqual(actual.Score, expected.Score);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test valid data - casing
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest25()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "Bundy,TeRESSA,88"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = new MyStudent("Bundy", "TeRESSA", 88); // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.Surname, expected.Surname);
            Assert.AreEqual(actual.Score, expected.Score);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test invalid score 00
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest26()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "BUNDY, TERESSA, 00"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = null; // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual, expected);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test valid data - long string
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest27()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "BUNDYBUNDYBUNDYBUNDYBUNDYBUNDY, TERESSATERESSATERESSATERESSATERESSATERESSA, 88"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = new MyStudent("BUNDYBUNDYBUNDYBUNDYBUNDYBUNDY", "TERESSATERESSATERESSATERESSATERESSATERESSA", 88); // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.Surname, expected.Surname);
            Assert.AreEqual(actual.Score, expected.Score);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Public_CheckLine: to test invalid data - middle name (name contains tab)
        ///</summary>
        [TestMethod()]
        public void Public_CheckLineTest28()
        {
            MyFile target = new MyFile(); // TODO: Initialize to an appropriate value
            string strLine = "BUN	DY, TERESSA, 88"; // TODO: Initialize to an appropriate value
            int nLineNumber = 1; // TODO: Initialize to an appropriate value
            MyStudent expected = null; // TODO: Initialize to an appropriate value
            MyStudent actual;
            actual = target.Public_CheckLine(strLine, nLineNumber);
            Assert.AreEqual(actual, expected);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
