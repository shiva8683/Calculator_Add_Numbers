using System.ServiceModel;
using Calculator_Add_Numbers_Service_Test.CalculatorService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator_Add_Numbers_Service_Test
{
    [TestClass]
    public class Calculator_Service_Test
    {
        /// <summary>
        /// Testing "Add" Service using default delimiters
        /// </summary>
        [TestMethod]
        public void Add_With_CommonDelimiter_Success()
        {
            CalculatorClient calculatorClient = new CalculatorClient();
            var result = calculatorClient.Add("1\n2,3");
            Assert.AreEqual(6, result);
        }

        /// <summary>
        ///  Testing "Add" Service using default delimiters with incorrect input resulting service throws FaultException
        /// </summary>
        [TestMethod]
        public void Add_With_CommonDelimiter_Exception()
        {
            CalculatorClient calculatorClient = new CalculatorClient();
            Assert.ThrowsException<FaultException>(() => calculatorClient.Add("1,\n2,3"));
        }

        /// <summary>
        ///  Testing "Add" Service using custom delimiter ";" and with the sum of 1,2,3,4
        /// </summary>
        [TestMethod]
        public void Add_With_CustomDelimiter_Success()
        {
            CalculatorClient calculatorClient = new CalculatorClient();
            var result = calculatorClient.Add("//;\n1;2;3;4");
            Assert.AreEqual(10, result);
        }

        /// <summary>
        /// Testing "Add" Service using custom delimiter ";" and passing incorrect input resulting service throws FaultException
        /// </summary>
        [TestMethod]
        public void Add_With_CustomDelimiter_Exception()
        {
            CalculatorClient calculatorClient = new CalculatorClient();
            Assert.ThrowsException<FaultException>(() => calculatorClient.Add("//;\n1;2;3$4"));
        }

        /// <summary>
        /// Testing "Add" Service using Negative Numbers and expecting FaultException
        /// </summary>
        [TestMethod]
        public void Add_With_Negative_Numbers_Exception()
        {
            CalculatorClient calculatorClient = new CalculatorClient();
            Assert.ThrowsException<FaultException>(() =>
            {
                calculatorClient.Add("-1,-2,-3");
            });
        }

        /// <summary>
        /// Testing "Add" Service using Negative Numbers and expecting FaultException with expected message "negatives not allowed: -1,-2,-3"
        /// </summary>
        [TestMethod]
        public void Add_With_Negative_Numbers_Exception_With_Message()
        {
            CalculatorClient calculatorClient = new CalculatorClient();
            var exceptionMessage = string.Empty;
            try
            {
                calculatorClient.Add("-1,-2,-3");
            }
            catch (System.Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            Assert.AreEqual(exceptionMessage, "negatives not allowed: -1,-2,-3");
        }
    }
}
