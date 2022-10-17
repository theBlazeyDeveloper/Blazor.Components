using System.Collections;

namespace Components.Inputs.Models
{
    public readonly struct SelectListItem
    {
        public SelectListItem(string text, object value) 
        {
            Value = value;
            Text = text;
        }

        public object Value { get; init; } = default!;
        public string Text { get; init; } = default!;
    }

    public class SelectList : IEnumerable<SelectListItem>
    {
        readonly IList<SelectListItem> _items = new List<SelectListItem>();

        public SelectList(IEnumerable<object> items, string valueProperty, string textProperty) 
        {
            foreach (var item in items)
            {
                string GetValue(object obj, string property)
                {
                    var type = obj.GetType();
                    var prop = type.GetProperty(property);
                    return prop?.GetValue(item, null) as string ?? string.Empty;
                }
                 
                _items.Add(new SelectListItem
                {
                    Text = GetValue(item, textProperty),
                    Value = GetValue(item, valueProperty)
                });
            }
        }
        
        public IEnumerable<SelectListItem> Items { get => _items; }

        public IEnumerator<SelectListItem> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();        
    }
}
