using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MoodAnalyser;

namespace MoodAnalyserTest
{
    [TestClass]
    public class AnalyseMoodTestCases
    {
        MoodAnalyserFactory factory;
        [TestInitialize]
        public void Setup()
        {
            factory = new MoodAnalyserFactory();
        }

        [TestCategory("Sad Mood")]
        [TestMethod]
        public void TestIamInSadMoodShouldReturnSad()//AAA
        {
            //Arrange
            string message = "I am in Sad mood";
            string expected = "SAD";
            MoodAnalysis moodAnalysis = new MoodAnalysis(message);
            //Act
            string actual = moodAnalysis.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("Happy Mood")]
        [TestMethod]
        public void TestIamInAnyMoodShouldReturnHappy()
        {

            string message = "I am in Any mood";
            string expected = "HAPPY";
            MoodAnalysis moodAnalysis = new MoodAnalysis(message);

            string actual = moodAnalysis.AnalyseMood();

            Assert.AreEqual(expected, actual);
        }
        //[TestCategory("Null Exception")]
        //[TestMethod]
        //public void GivenNullMessageShouldReturnHappy()
        //{
        //    string message = null;
        //    string expected = "HAPPY";
        //    MoodAnalysis moodAnalysis = new MoodAnalysis(message);

        //    string actual = moodAnalysis.AnalyseMood();

        //    Assert.AreEqual(expected, actual);
        //}
        [TestCategory("Custom Exception")]
        [TestMethod]
        public void GivenNullMoodShouldThrowMoodAnalysisException()
        {
            string message = null;
            string expected = "Mood should not be null";
            try
            {
                MoodAnalysis moodAnalysis = new MoodAnalysis(message);
                string actual = moodAnalysis.AnalyseMood();
                Assert.AreEqual(expected, actual);
            }
            catch (CustomException msg)
            {
                Assert.AreEqual(expected, msg.Message);
            }
        }
        [TestCategory("Custom Exception")]
        [TestMethod]
        public void GivenEmptyMoodShouldThrowMoodAnalysisException()
        {
            string message = "";
            string expected = "Mood should not be empty";
            try
            {
                MoodAnalysis moodAnalysis = new MoodAnalysis(message);
                string actual = moodAnalysis.AnalyseMood();
                Assert.AreEqual(expected, actual);
            }
            catch(CustomException msg)
            {
                Assert.AreEqual(expected, msg.Message);
            }
        }
        //TC 4.1 - Proper class details are provided and expected to return the MoodAnalyser Object
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("MoodAnalyser.MoodAnalysis", "MoodAnalysis")]
        public void GivenMoodAnalyzerClassName_ReturnMoodAnalysisObject(string className,string constructorName)
        {
            MoodAnalysis expected = new MoodAnalysis();
            object obj;

            obj = factory.CreatemoodAnalyse(className, constructorName);
            expected.Equals(obj);
        }
        //TC 4.2 - improper class details are provided and expected to throw exception Class not found
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("Mood.MoodAnalysis", "MoodAnalysis", "class not found")]
        public void GivenImproperClassName_ShouldThrowCustomException(string className, string constructorName,string expected)
        {
            try
            {
                object actual = factory.CreatemoodAnalyse(className, constructorName);
            }
            catch(CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        //TC 4.3 - improper constructor details are provided and expected to throw exception Constructor not found
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("MoodAnalyser.MoodAnalysis", "Mood", "constructor not found")]
        public void GivenImproperConstructorName_ShouldThrowCustomException(string className, string constructorName, string expected)
        {
            try
            {
                object actual = factory.CreatemoodAnalyse(className, constructorName);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        //TC 5.1 - Method to test moodanalyser class with parameter constructor to check if two objects are equal
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("I am in sad mood")]
        [DataRow("I am in any mood")]
        public void GivenMoodAnalyserWhenProperShouldReturnMoodAnalyserObject(string message)
        {
            MoodAnalysis expected = new MoodAnalysis(message);
            object obj = null;
            try
            {
                obj = factory.CreateMoodAnalyseParameterObject("MoodAnalysis", "MoodAnalysis", message);
            }
            catch (CustomException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
            obj.Equals(expected);
        }
        //TC 5.2 - Method to test moodanalyser with diff class with parameter constructor to throw error
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("Mood", "I am in Happy mood", "could not find class")]
        public void GIvenClassNmaeWhenImproperShouldThrowException(string className, string message, string expexted)
        {
            MoodAnalysis expected = new MoodAnalysis(message);
            object obj = null;
            try
            {
                obj = factory.CreateMoodAnalyseParameterObject(className, "MoodAnalysis", message);

            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expexted, ex.Message);
            }
        }
        //TC 5.3 - Method to test moodanalyser with diff constructor with parameter constructor to throw error
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("Mood", "I am in Happy mood", "could not find constructor")]
        public void GIvenConstructorNameWhenImproperShouldThrowException(string construtorName, string message, string expexted)
        {
            MoodAnalysis expected = new MoodAnalysis(message);
            object obj;
            try
            {
                obj = factory.CreateMoodAnalyseParameterObject("MoodAnalysis", construtorName, message);

            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expexted, ex.Message);
            }
        }
        //UC 6.1,6.2 - Method to invoke analyse mood method to return happy or sad or invalid method
        [TestCategory("Reflection")]
        [TestMethod]
        [DataRow("HAPPY")]
        [DataRow("Method not found")]
        public void ReflectionReturnMethod(string expected)
        {
            try
            {
                string actual = factory.InvokeAnalyseMood("happy", "AnalyseMood");
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
}