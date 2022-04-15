using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser
{
    public class MoodAnalysis
    {
        public string message;
        public MoodAnalysis(string message)//constructor
        {
            this.message = message;
        }
        public string AnalyseMood() //method to analyse mood
        {
            try
            {
                if (this.message.ToLower().Contains("sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch(NullReferenceException)
            {
                return "HAPPY";
            }
        }      
    }
}
