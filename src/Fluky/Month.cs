using System;

namespace Fluky
{
  public class Month : IEquatable<Month>
  {
    public Month()
    {
    }

    public Month(string name, string shortName, int numeric)
    {
      Name = name;
      ShortName = shortName;
      Numeric = numeric;
    }

    public string Name { get; private set; }
    public string ShortName { get; private set; }
    public int Numeric { get; private set; }

    public bool Equals(Month other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return string.Equals(Name, other.Name) && string.Equals(ShortName, other.ShortName) && Numeric == other.Numeric;
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      return obj.GetType() == GetType() && Equals((Month) obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        var hashCode = Name?.GetHashCode() ?? 0;
        hashCode = (hashCode * 397) ^ (ShortName?.GetHashCode() ?? 0);
        hashCode = (hashCode * 397) ^ Numeric;
        return hashCode;
      }
    }
  }
}