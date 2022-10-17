namespace Components.Inputs.Models
{
    public enum InputTypes
    {
        CheckBox = 0,
        Hidden = 1,
        Password = 2,
        Radio = 3,
        Text = 4,
        Email = 5,
        Number = 6
    }

    public static class InputTypeExtension
    {
        public static string ToString(this InputTypes e)
        {
            return e switch
            {
                InputTypes.CheckBox => "checkbox",
                InputTypes.Hidden => "hidden",
                InputTypes.Password => "password",
                InputTypes.Radio => "radio",
                InputTypes.Text => "text",
                InputTypes.Email => "email",
                InputTypes.Number => "number",
                _ => "text",
            };
        }
    }
}
