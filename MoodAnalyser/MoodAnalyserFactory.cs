using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MoodAnalyser
{
    public class MoodAnalyserFactory
    {
        public object CreatemoodAnalyse(string className,string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            
            if(result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch(ArgumentNullException)
                {
                    throw new CustomException(CustomException.ExceptionType.NO_SUCH_CLASS, "class not found");
                }
            }
            else
            {
                throw new CustomException(CustomException.ExceptionType.NO_SUCH_METHOD, "constructor not found");
            }
        }
    }
}