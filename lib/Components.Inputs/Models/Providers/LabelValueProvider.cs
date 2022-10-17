using System.ComponentModel.DataAnnotations;

namespace Components.Inputs.Models.Providers
{
    public sealed class LabelValueProvider
    {
        public static string GetLabelValue(string propertyName, Type objectType)
        {
            var labelValue = "";
            if (string.IsNullOrEmpty(propertyName))
                throw new NullReferenceException(nameof(propertyName));

            if (objectType == null)
                throw new NullReferenceException(nameof(objectType));

            var property = objectType.GetProperty(propertyName);

            if (property != null)
            {
                var member = objectType.GetMember(property.Name);

                var attributes = member[0]?.GetCustomAttributes(typeof(DisplayAttribute), false);

                if (attributes is not null)
                    labelValue = attributes.Length > 0 ? ((DisplayAttribute)attributes[0]).Name : "";
            }
            return labelValue ?? string.Empty;
        }        
    }

    public static class LabelValueProviderExtensions
    {
        public static string GetDisplayValue(this Type objectType, string propertyName)
        {
            var labelValue = "";
            if (string.IsNullOrEmpty(propertyName))
                throw new NullReferenceException(nameof(propertyName));

            if (objectType == null)
                throw new NullReferenceException(nameof(objectType));

            var property = objectType.GetProperty(propertyName);
            if (property != null)
            {
                var member = objectType.GetMember(property.Name);

                var attributes = member[0]?.GetCustomAttributes(typeof(DisplayAttribute), false);

                if (attributes is not null)
                    labelValue = attributes.Length > 0 ? ((DisplayAttribute)attributes[0]).Name : "";
            }
            return labelValue ?? string.Empty;
        }
    }
}
