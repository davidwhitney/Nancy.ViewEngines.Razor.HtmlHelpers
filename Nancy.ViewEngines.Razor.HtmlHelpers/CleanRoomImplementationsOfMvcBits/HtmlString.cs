namespace Nancy.ViewEngines.Razor.HtmlHelpers
{
    public class HtmlString : NonEncodedHtmlString, IHtmlString
    {
        public HtmlString(string value) : base(value)
        {
        }
    }
}