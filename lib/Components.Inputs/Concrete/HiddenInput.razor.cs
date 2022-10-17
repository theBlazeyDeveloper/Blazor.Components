using Microsoft.AspNetCore.Components.Forms;
using System.Globalization;

namespace Components.Inputs.Concrete
{
    public class HiddenInputBase<T> : InputBase<T>
    {
        protected override bool TryParseValueFromString(string? value, out T result, out string validationErrorMessage)
        {
            if (value is not null)
            {
                if (typeof(T) == typeof(string))
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        result = (T)(object)value;
                        validationErrorMessage = null!;

                        return true;
                    }
                }
                else if (typeof(T) == typeof(int))
                {
                    int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsedValue);
                    result = (T)(object)parsedValue;
                    validationErrorMessage = null!;

                    return true;
                }
                else if (typeof(T) == typeof(Guid))
                {
                    _ = Guid.TryParse(value, out var parsedValue);
                    result = (T)(object)parsedValue;
                    validationErrorMessage = null!;

                    return true;
                }
                else if (typeof(T).IsEnum)
                {
                    try
                    {
                        result = (T)Enum.Parse(typeof(T), value);
                        validationErrorMessage = null!;

                        return true;
                    }
                    catch (ArgumentException)
                    {
                        result = default!;
                        validationErrorMessage = $"The {FieldIdentifier.FieldName} field is not valid.";

                        return false;
                    }
                }

                throw new InvalidOperationException($"{GetType()} does not support the type '{typeof(T)}'.");
            }

            throw new ArgumentNullException(value);
        }
    }
}
