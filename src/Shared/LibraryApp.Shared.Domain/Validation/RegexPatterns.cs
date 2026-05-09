using System.Text.RegularExpressions;

namespace LibraryApp.Shared.Domain.Validation;


public static partial class RegexPatterns
{
    [GeneratedRegex(@"^[^\s@]+@[^\s@]+\.[^\s@]+$")]
    public static partial Regex Email();
}