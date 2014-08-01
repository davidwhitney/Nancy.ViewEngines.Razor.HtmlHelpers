using System;
using System.Collections.Generic;
using Nancy.Helpers;

namespace Nancy.ViewEngines.Razor.HtmlHelpers
{
    public static class HtmlHelpersLabelExtensions
    {
        public static IHtmlString Label<TModel>(this HtmlHelpers<TModel> helper, string labelText)
        {
            return Label(helper, labelText, null, null);
        }

        public static IHtmlString Label<TModel>(this HtmlHelpers<TModel> helper, string labelText, string labelFor)
        {
            return Label(helper, labelText, labelFor, null);
        }

        public static IHtmlString Label<TModel>(this HtmlHelpers<TModel> helper, string labelText, object attributes)
        {
            return Label(helper, labelText, null, TypeHelper.ObjectToDictionary(attributes));
        }

        public static IHtmlString Label<TModel>(this HtmlHelpers<TModel> helper, string labelText, string labelFor, object attributes)
        {
            return Label(helper, labelText, labelFor, TypeHelper.ObjectToDictionary(attributes));
        }

        public static IHtmlString Label<TModel>(this HtmlHelpers<TModel> helper, string labelText, string labelFor, IDictionary<string, object> attributes)
        {
            if (String.IsNullOrEmpty(labelText))
            {
                throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "labelText");
            }

            labelFor = labelFor ?? labelText;

            var tag = new TagBuilder("label")
            {
                InnerHtml = String.IsNullOrEmpty(labelText) ? String.Empty : HttpUtility.HtmlEncode(labelText)
            };

            if (!String.IsNullOrEmpty(labelFor))
            {
                tag.MergeAttribute("for", labelFor);
            }
            tag.MergeAttributes(attributes, false);

            return tag.ToHtmlString(TagRenderMode.Normal);
        }
    }
}
