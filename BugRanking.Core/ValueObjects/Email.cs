using BugRanking.Core.ValueObjects.Exceptions;

namespace BugRanking.Core.ValueObjects;

public class Email : ValueObject
{
  public Email(string address)
  {
    Address = address;
    InvalidEmailException.ThrowIfInvalid(address);
  }
  public string Address { get; }
}