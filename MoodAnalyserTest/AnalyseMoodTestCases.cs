using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MoodAnalyser;

namespace MoodAnalyserTest
{
    [TestClass]
    public class AnalyseMoodTestCases
    {
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

            MoodAnalyserFactory factory = new MoodAnalyserFactory();
            obj = factory.CreatemoodAnalyse(className, constructorName);
            expected.Equals(obj);
        }
        //TC 4.2 - improper class details are provided and expected to throw exception Class not found
        [TestMethod]
        [TestCategory("Reflection")]
        [DataRow("Mood.MoodAnalysis", "MoodAnalysis", "class not found")]
        public void GivenImproperClassName_ShouldThrowCustomException(string className, string constructorName,string expected)
        {
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                object actual = factory.CreatemoodAnalyse(className, constructorName);
            }
            catch(CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        //TC 4.3 - improper constructor details are provided and expected to throw exception Constructor not found
        [TestMethod]
        [TestCategory("Reflection")]
        [DataRow("MoodAnalyser.MoodAnalysis", "Mood", "constructor not found")]
        public void GivenImproperConstructorName_ShouldThrowCustomException(string className, string constructorName, string expected)
        {
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                object actual = factory.CreatemoodAnalyse(className, constructorName);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }

    }
}