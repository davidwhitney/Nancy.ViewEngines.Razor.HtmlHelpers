using System.ComponentModel;

namespace Nancy.ViewEngines.Razor.HtmlHelpers
{
    public static class TypeHelper
    {
        public static RouteValueDictionary ObjectToDictionary(object htmlAttributes)
        {
            var result = new RouteValueDictionary();

            if (htmlAttributes != null)
            {
                foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(htmlAttributes))
                {
                    result.Add(property.Name.Replace('_', '-'), property.GetValue(htmlAttributes));
                }
            }

            return result;
        }
    }
}