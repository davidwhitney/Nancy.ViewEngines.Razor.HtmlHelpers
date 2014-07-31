using System;
using System.Collections.Generic;
using System.Net.Mime;

namespace Nancy.ViewEngines.Razor.HtmlHelpers
{
    public static class HtmlHelpersCheckBoxExtensions
    {
        public static IHtmlString CheckBox<TModel>(this HtmlHelpers<TModel> helper, string name)
        {
            return CheckBox(helper, name, null);
        }

        public static IHtmlString CheckBox<TModel>(this HtmlHelpers<TModel> helper, string name, object htmlAttributes)
        {
            return CheckBox(helper, name, TypeHelper.ObjectToDictionary(htmlAttributes));
        }

        public static IHtmlString CheckBox<TModel>(this HtmlHelpers<TModel> helper, string name, IDictionary<string, object> htmlAttributes)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
            }

            return BuildCheckBox(name, null, htmlAttributes);
        }

        public static IHtmlString CheckBox<TModel>(this HtmlHelpers<TModel> helper, string name, bool isChecked)
        {
            return CheckBox(helper, name, isChecked, null);
        }

        public static IHtmlString CheckBox<TModel>(this HtmlHelpers<TModel> helper, string name, bool isChecked, object htmlAttributes)
        {
            return CheckBox(helper, name, isChecked, TypeHelper.ObjectToDictionary(htmlAttributes));
        }

        public static IHtmlString CheckBox<TModel>(this HtmlHelpers<TModel> helper, string name, bool isChecked, IDictionary<string, object> htmlAttributes)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
            }
            return BuildCheckBox(name, isChecked, htmlAttributes);
        }

        private static IHtmlString BuildCheckBox(string name, bool? isChecked, IDictionary<string, object> attributes)
        {
            var builder = new TagBuilder("input");
            builder.MergeAttribute("type", "checkbox", true);
            builder.GenerateId(name);
            builder.MergeAttributes(attributes, true);
            builder.MergeAttribute("name", name, true);

            //var model = ModelState[name];
            //if (model != null && model.Value != null)
            {
            //    var modelValue = Convert.ToBoolean(model.Value);
                isChecked = isChecked; //?? modelValue;
            }
            if (isChecked.HasValue)
            {
                if (isChecked.Value == true)
                {
                    builder.MergeAttribute("checked", "checked", true);
                }
                else
                {
                    builder.Attributes.Remove("checked");
                }
            }

            return new NonEncodedHtmlString((builder.ToHtmlString(TagRenderMode.SelfClosing).ToHtmlString()));
        }
    }
}
