using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Reflection;

namespace Components.Inputs.Models
{
    public sealed class ColorEntity
    {
        readonly string _id = string.Empty;
        readonly string _hexValue = string.Empty;        
        readonly Color _color = Color.Empty;
        readonly string _name = string.Empty;

        private ColorEntity() { }

        public ColorEntity(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"{name} cannot be empty or null");

            _name = name;
            _color = FindByName(Name);

            if (!_color.IsEmpty)
                _hexValue = _color.ConvertToHexadecimal() ?? throw new ArgumentException($"{nameof(Name)} is an invalid color name");

            _id = _color.IsEmpty ? "empty" : _hexValue;
        }

        [Key]
        [Column(nameof(Id))]
        [Display(Name = "Id")]
        public string Id { get => _id; }

        [Column(nameof(Name))]
        [Display(Name = "Name")]
        public string Name { get => _name; }

        [Column(nameof(HexValue))]
        [Display(Name = "Color Hex Value")]
        public string HexValue { get => _hexValue; }

        [Display(Name = "Color")]
        public Color Color { get => _color; }

        public static IList<ColorEntity> Colors => GetColors();

        public static Dictionary<string, string> ColorDictionary { get => GetColorDictionary(); }          

        public static Color FindByName(string ColorName)            
            => ColorCollection.FirstOrDefault(c => c.Name.ToUpper() == ColorName.ToUpper());        

        public static ColorEntity? FindById(string ColorId)
            => Colors.FirstOrDefault(c => c.Id.Equals(ColorId)); 

        static IList<ColorEntity> GetColors()
        {
            var colorList = new List<ColorEntity>();
            foreach (var color in GetColorDictionary())
                colorList.Add(new ColorEntity(name: color.Value));

            return colorList;
        }

        static Dictionary<string, string> GetColorDictionary()
        {
            var colorDictionary = new Dictionary<string, string>();

            foreach (var c in ColorCollection)
            {
                var color = new ColorEntity(name: c.Name);
                colorDictionary.TryAdd(color.Id, color.Name);
            }
            return colorDictionary;
        }

        static ICollection<Color> ColorCollection 
            => typeof(Color).GetProperties(BindingFlags.Static |
                BindingFlags.DeclaredOnly | 
                BindingFlags.Public)
            .Select(c => (Color)(c.GetValue(null, null) ?? Color.Empty))
            .OrderBy(a => a.Name)
            .ToList();
    }

    public static class ColorExtensions
    {
        public static string ConvertToRGBA(this string c, decimal opacityValue = 0)
        {
           var color = ColorEntity.FindById(c);

            return color?.Color.ConvertToRGBA(opacityValue) ?? string.Empty;
        }

        public static string ConvertToRGBA(this Color c, decimal opacityValue = 0)
            => $"rgba({c.R}, {c.G},{c.B}, {opacityValue})";

        public static string ConvertToRGB(this Color c)
            => "rgb(" + c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString() + ")";

        public static string ConvertToHexadecimal(this Color c)
            => "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
    }
}
