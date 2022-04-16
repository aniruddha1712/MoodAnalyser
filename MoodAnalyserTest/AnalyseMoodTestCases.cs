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
            string actual = moodAnalysis.AnalyseMood(message);
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

            string actual = moodAnalysis.AnalyseMood(message);
            
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("Happy Mood")]
        [TestMethod]
        public void TestHappyMoodMessageWithNoParamsShouldReturnHappy()
        {

            string message = "I am in happy mood";
            string expected = "HAPPY";
            MoodAnalysis moodAnalysis = new MoodAnalysis(message);

            string actual = moodAnalysis.AnalyseMood();

            Assert.AreEqual(expected, actual);
        }
        [TestCategory("Sad Mood")]
        [TestMethod]
        public void TestSadMoodMessageWithNoParamsShouldReturnSad()
        {

            string message = "I am in sad mood";
            string expected = "SAD";
            MoodAnalysis moodAnalysis = new MoodAnalysis(message);

            string actual = moodAnalysis.AnalyseMood();

            Assert.AreEqual(expected, actual);
        }
    }
}
