using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Nancy.ViewEngines.Razor.HtmlHelpers
{
    public static class HtmlHelpersRadioExtensions
    {
        public static IHtmlString RadioButtonFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression, object value)
        {
            return RadioButton(helper, ExpressionHelper.GetExpressionText(expression), value);
        }

        public static IHtmlString RadioButton<TModel>(this HtmlHelpers<TModel> helper, string name, object value)
        {
            return RadioButton(helper, name, value, null);
        }

        public static IHtmlString RadioButtonFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression, object value, object htmlAttributes)
        {
            return RadioButton(helper, ExpressionHelper.GetExpressionText(expression), value, htmlAttributes);
        }

        public static IHtmlString RadioButton<TModel>(this HtmlHelpers<TModel> helper, string name, object value, object htmlAttributes)
        {
            return RadioButton(helper, name, value, TypeHelper.ObjectToDictionary(htmlAttributes));
        }

        public static IHtmlString RadioButtonFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression, object value, IDictionary<string, object> htmlAttributes)
        {
            return RadioButton(helper, ExpressionHelper.GetExpressionText(expression), value, htmlAttributes);
        }

        public static IHtmlString RadioButton<TModel>(this HtmlHelpers<TModel> helper, string name, object value, IDictionary<string, object> htmlAttributes)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
            }

            return BuildRadioButton(name, value, null, htmlAttributes);
        }

        public static IHtmlString RadioButtonFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression, object value, bool isChecked)
        {
            return RadioButton(helper, ExpressionHelper.GetExpressionText(expression), value, isChecked);
        }

        public static IHtmlString RadioButton<TModel>(this HtmlHelpers<TModel> helper, string name, object value, bool isChecked)
        {
            return RadioButton(helper, name, value, isChecked, null);
        }

        public static IHtmlString RadioButtonFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression, object value, bool isChecked, object htmlAttributes)
        {
            return RadioButton(helper, ExpressionHelper.GetExpressionText(expression), value, isChecked, htmlAttributes);
        }

        public static IHtmlString RadioButton<TModel>(this HtmlHelpers<TModel> helper, string name, object value, bool isChecked, object htmlAttributes)
        {
            return RadioButton(helper, name, value, isChecked, TypeHelper.ObjectToDictionary(htmlAttributes));
        }

        public static IHtmlString RadioButtonFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression, object value, bool isChecked, IDictionary<string, object> htmlAttributes)
        {
            return RadioButton(helper, ExpressionHelper.GetExpressionText(expression), value, isChecked, htmlAttributes);
        }

        public static IHtmlString RadioButton<TModel>(this HtmlHelpers<TModel> helper, string name, object value, bool isChecked, IDictionary<string, object> htmlAttributes)
        {
            if (name == null)
            {
                throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
            }
            return BuildRadioButton(name, value, isChecked, htmlAttributes);
        }

        private static IHtmlString BuildRadioButton(string name, object value, bool? isChecked, IDictionary<string, object> attributes)
        {
            var valueString = Convert.ToString(value);

            var builder = new TagBuilder("input");
            builder.MergeAttribute("type", "radio", true);
            builder.GenerateId(name);
            builder.MergeAttributes(attributes, true);

            builder.MergeAttribute("value", valueString, true);
            builder.MergeAttribute("name", name, true);

            //if (UnobtrusiveJavaScriptEnabled)
            //{
            //    // Add validation attributes
            //    var validationAttributes = _validationHelper.GetUnobtrusiveValidationAttributes(name);
            //    builder.MergeAttributes(validationAttributes, replaceExisting: false);
            //}

            //var modelState = ModelState[name];
            //string modelValue = null;
            //if (modelState != null)
            //{
            //    modelValue = ConvertTo(modelState.Value, typeof(string)) as string;
            //    isChecked = isChecked ?? String.Equals(modelValue, valueString, StringComparison.OrdinalIgnoreCase);
            //}

            if (isChecked.HasValue)
            {
                // Overrides attribute values
                if (isChecked.Value)
                {
                    builder.MergeAttribute("checked", "checked", true);
                }
                else
                {
                    builder.Attributes.Remove("checked");
                }
            }

            //AddErrorClass(builder, name);

            return builder.ToHtmlString(TagRenderMode.SelfClosing);
        }
    }
}
