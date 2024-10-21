using System.Text.RegularExpressions;

namespace BugRanking.Core.ValueObjects.Exceptions;

public partial class InvalidEmailException : Exception
{
  private const string DefaultErrorMessage = "Invalid email";

  public InvalidEmailException(string message = DefaultErrorMessage)
    : base(message) { }

  public static void ThrowIfInvalid(string address, string message = DefaultErrorMessage)
  {
    if (string.IsNullOrEmpty(address))
      throw new InvalidEmailException(message);

    if (!EmailRegex().IsMatch(address))
      throw new InvalidEmailException();
  }

  [GeneratedRegex("^[a-zA-Z0-9.!#$%&'*+\\=?^_`{|}~-]+(?:\\.[a-zA-Z0-9.!#$%&'*+\\=?^_`{|}~-]+)*@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z]{2,})+$")]
  private static partial Regex EmailRegex();
}