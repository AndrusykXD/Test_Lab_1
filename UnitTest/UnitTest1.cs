using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Linq;
using System.Data.SqlClient;
using AnalaizerClassLibrary;

namespace YourNamespace.Tests
{
    [TestClass]
    public class AnalyzerTests
    {
        public TestContext TestContext { get; set; }

        [DataSource("System.Data.SqlClient", "Server = DESKTOP-RGMI6T0;Integrated Security = True;Database = Test", "TestData", DataAccessMethod.Sequential)]

        [TestMethod]
        public void TestCreateStack()
        {
            {
                {
                    string expression = (string)TestContext.DataRow["expression"];
                    string expected = (string)TestContext.DataRow["expected"];

                    // Act
                    AnalaizerClass.expression = expression;
                    ArrayList result = AnalaizerClass.CreateStack();

                    // Assert
                    ArrayList expectedList = new ArrayList(expected.Split(' '));
                    CollectionAssert.AreEqual(expectedList.ToArray(), result.ToArray(), GetAssertionMessage(expectedList, result));
                }
            }
        }




        private string GetAssertionMessage(ArrayList expected, ArrayList actual)
        {
            return $"Expected: [{string.Join(", ", expected.Cast<string>())}], Actual: [{string.Join(", ", actual.Cast<string>())}]";
        }
    }
}