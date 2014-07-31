using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq.Expressions;

namespace Nancy.ViewEngines.Razor.HtmlHelpers
{
    public static class HtmlHelperInputExtensions
    {
        public static IHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var value = expression.Compile()(helper.Model);
            return TextBox(helper, name, value, htmlAttributes);
        }

        public static IHtmlString TextBox<TModel>(this HtmlHelpers<TModel> helper, string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
            }

            return BuildInputField(name, InputType.Text, null, false, null);
        }

        public static IHtmlString TextBox<TModel>(this HtmlHelpers<TModel> helper, string name, object value)
        {
            return TextBox(helper, name, value, null);
        }

        public static IHtmlString TextBox<TModel>(this HtmlHelpers<TModel> helper, string name, object value, object htmlAttributes)
        {
            return TextBox(helper, name, value, TypeHelper.ObjectToDictionary(htmlAttributes));
        }

        public static IHtmlString TextBox<TModel>(this HtmlHelpers<TModel> helper, string name, object value, IDictionary<string, object> htmlAttributes)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
            }

            return BuildInputField(name, InputType.Text, value, true, htmlAttributes);
        }

        public static IHtmlString Hidden<TModel>(this HtmlHelpers<TModel> helper, string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
            }

            return BuildInputField(name, InputType.Hidden, null, false, null);
        }

        public static IHtmlString Hidden<TModel>(this HtmlHelpers<TModel> helper, string name, object value)
        {
            return Hidden(helper, name, value, null);
        }

        public static IHtmlString Hidden<TModel>(this HtmlHelpers<TModel> helper, string name, object value, object htmlAttributes)
        {
            return Hidden(helper, name, value, TypeHelper.ObjectToDictionary(htmlAttributes));
        }

        public static IHtmlString Hidden<TModel>(this HtmlHelpers<TModel> helper, string name, object value, IDictionary<string, object> htmlAttributes)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
            }

            return BuildInputField(name, InputType.Hidden, GetHiddenFieldValue(value), true, htmlAttributes);
        }

        private static object GetHiddenFieldValue(object value)
        {
            var binaryValue = value as Binary;
            if (binaryValue != null)
            {
                value = binaryValue.ToArray();
            }

            byte[] byteArrayValue = value as byte[];
            if (byteArrayValue != null)
            {
                value = Convert.ToBase64String(byteArrayValue);
            }

            return value;
        }

        public static IHtmlString Password<TModel>(this HtmlHelpers<TModel> helper, string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
            }

            return BuildInputField(name, InputType.Password, null, false, null);
        }

        public static IHtmlString Password<TModel>(this HtmlHelpers<TModel> helper, string name, object value)
        {
            return Password(helper, name, value, null);
        }

        public static IHtmlString Password<TModel>(this HtmlHelpers<TModel> helper, string name, object value, object htmlAttributes)
        {
            return Password(helper, name, value, TypeHelper.ObjectToDictionary(htmlAttributes));
        }

        public static IHtmlString Password<TModel>(this HtmlHelpers<TModel> helper, string name, object value, IDictionary<string, object> htmlAttributes)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
            }

            return BuildInputField(name, InputType.Password, value, true, htmlAttributes);
        }

        private static IHtmlString BuildInputField(string name, InputType type, object value, bool isExplicitValue,
            IDictionary<string, object> attributes)
        {
            var tagBuilder = new TagBuilder("input");
            // Implicit parameters
            tagBuilder.MergeAttribute("type", GetInputTypeString(type));
            tagBuilder.GenerateId(name);

            // Overwrite implicit
            tagBuilder.MergeAttributes(attributes, true);

            //if (UnobtrusiveJavaScriptEnabled)
            //{
            //    // Add validation attributes
            //    var validationAttributes = _validationHelper.GetUnobtrusiveValidationAttributes(name);
            //    tagBuilder.MergeAttributes(validationAttributes, replaceExisting: false);
            //}

            // Function arguments
            tagBuilder.MergeAttribute("name", name, true);
            //var modelState = ModelState[name];
            //if ((type != InputType.Password) && modelState != null)
            {
                // Don't use model values for passwords
                value = value; //?? modelState.Value ?? String.Empty;
            }

            if ((type != InputType.Password) || ((type == InputType.Password) && (value != null)))
            {
                // Review: Do we really need to be this pedantic about sticking to mvc?
                tagBuilder.MergeAttribute("value", Convert.ToString(value), isExplicitValue);
            }
                        //AddErrorClass(tagBuilder, name);
            return tagBuilder.ToHtmlString(TagRenderMode.SelfClosing);
        }

        private static string GetInputTypeString(InputType inputType)
        {
            if (!Enum.IsDefined(typeof(InputType), inputType))
            {
                inputType = InputType.Text;
            }
            return inputType.ToString().ToLowerInvariant();
        }
    }
}