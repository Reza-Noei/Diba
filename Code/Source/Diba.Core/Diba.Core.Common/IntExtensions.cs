namespace Diba.Core.Common
{
    public static class IntExtensions
    {
        public static bool IsNullOrValue(this int? value, int valueToCheck)
        {
            return (value ?? valueToCheck) == valueToCheck;
        }
    }
}