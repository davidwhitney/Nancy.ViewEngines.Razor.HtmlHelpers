namespace Nancy.ViewEngines.Razor.HtmlHelpersUnofficial
{
    public class SelectListItem
    {
        public SelectListItem()
        {
        }

        public SelectListItem(string text, string value, bool selected = false)
        {
            Text = text;
            Value = value;
            Selected = selected;
        }

        public SelectListItem(SelectListItem item)
        {
            Text = item.Text;
            Value = item.Value;
            Selected = item.Selected;
        }

        public string Text { get; set; }

        public string Value { get; set; }

        public bool Selected { get; set; }
    }
}