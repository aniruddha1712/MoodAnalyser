﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}