using System.ComponentModel;
using System.Reflection;

namespace Lurnyx.Resources.Helpers
{
    /// <summary>
    /// Provides extension methods for enum types.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the string value from the Description attribute of an enum value.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns>The description string, or the enum's name if no description is found.</returns>
        public static string GetDescription(this System.Enum value)
        {
            FieldInfo? fi = value.GetType().GetField(value.ToString());

            if (fi != null)
            {
                DescriptionAttribute[] attributes =
                    (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

                if (attributes != null && attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
            }

            return value.ToString();
        }
    }
}
