using Calculator_Add_Numbers_Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Calculator_Add_Numbers_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Calculator" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Calculator.svc or Calculator.svc.cs at the Solution Explorer and start debugging.
    public class Calculator : ICalculator
    {
        /// <summary>
        /// Taking the input string and checking string null or whitespace if yes returing 0
        /// else checking if input has any custom delimiter if yes spliting string based on the passed delimiter and adding all the values in it.
        /// else spliting string based on "defaultDelimiters" and adding all the values in it.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;
            input = input.Replace(@"\\n", @"\n");
            char[] defaultDelimiters = { '\n', ',' };
            var explicitDelimiter = AddInputHelper.DetermineInputHaveExplicitMentionedDelimiter(input);
            List<int> inputNumbers = new List<int>();
            if (explicitDelimiter != AddInputHelper.EmptyCharacter)
            {
                var saperateCharacters = input.Split('\n')[1].Split(explicitDelimiter);
                return AddInputHelper.AddNumbersList(inputNumbers, saperateCharacters);
            }
            else
            {
                var saperateCharacters = input.Split(defaultDelimiters);
                return AddInputHelper.AddNumbersList(inputNumbers, saperateCharacters);
            }
        }
    }
}
