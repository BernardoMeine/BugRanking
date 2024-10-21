using BugRanking.Core.ValueObjects;
using BugRanking.Core.ValueObjects.Exceptions;

namespace BugRanking.Tests.ValueObjects;

[TestClass]
public class EmailTest
{
    [TestMethod]
    [DataRow("test@@email.com", true)]
    [DataRow("test@email,com", true)]
    [DataRow("test@email..com", true)]
    [DataRow(null, true)]
    [DataRow("", true)]
    [DataRow("test@email.com", false)]
    public void Should_return_exception_if_email_is_invalid(string email, bool expectedResult)
    {
        if (expectedResult)
        {
            try
            {
                _ = new Email(email);
                Assert.Fail();
            }
            catch (InvalidEmailException)
            {
                Assert.IsTrue(true);
            }
        }
        else
        {
            _ = new Email(email);
            Assert.IsTrue(true);
        }
    }
}