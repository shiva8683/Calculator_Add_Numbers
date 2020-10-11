using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Calculator_Add_Numbers_Service.Helpers
{
    public static class AddInputHelper
    {
        public static char EmptyCharacter = '\0';

        /// <summary>
        /// Checking if input has any explicit delimiter if yes returing the delimiter
        /// else returning "EmptyCharacter"
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static char DetermineInputHaveExplicitMentionedDelimiter(string input)
        {
            if (input.Substring(0, 2) == "//")
                return Convert.ToChar(input.Substring(2, 1));
            return EmptyCharacter;
        }

        /// <summary>
        /// Checking if list of number has any negative numbers if yes throwing FaultException with all the negative numbers
        /// else returning the sum of all passed int values
        /// </summary>
        /// <param name="inputNumbers"></param>
        /// <param name="saperateCharacters"></param>
        /// <returns></returns>
        public static int AddNumbersList(List<int> inputNumbers, string[] saperateCharacters)
        {
            inputNumbers.AddRange(saperateCharacters.Select(x => Convert.ToInt32(x)));
            var negativeNumbersList = GetNegativeNumbers(inputNumbers);
            if (negativeNumbersList.Any())
                throw new FaultException($"negatives not allowed: {string.Join(",", negativeNumbersList)}");
            return inputNumbers.Sum();
        }

        /// <summary>
        /// Checking and returning if "inputNumbers" has any negative numbers
        /// </summary>
        /// <param name="inputNumbers"></param>
        /// <returns></returns>
        private static List<int> GetNegativeNumbers(List<int> inputNumbers)
        {
            return inputNumbers.Where(x => x < 0).Select(x => x).ToList();
        }
    }
}