using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using Nancy.Helpers;

namespace Nancy.ViewEngines.Razor.HtmlHelpers
{
    public static class HtmlHelpersTextAreaExtensions
    {
        private const int TextAreaRows = 2;
        private const int TextAreaColumns = 20;

        public static IHtmlString TextAreaFor<TModel>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, string>> expression)
        {
            return TextArea(helper, ExpressionHelper.GetExpressionText(expression), expression.Compile()(helper.Model), null);
        }

        public static IHtmlString TextAreaFor<TModel>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, string>> expression, object htmlAttributes)
        {
            return TextArea(helper, ExpressionHelper.GetExpressionText(expression), expression.Compile()(helper.Model), htmlAttributes);
        }

        public static IHtmlString TextAreaFor<TModel>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, string>> expression, IDictionary<string, object> htmlAttributes)
        {
            return TextArea(helper, ExpressionHelper.GetExpressionText(expression), expression.Compile()(helper.Model), TypeHelper.ObjectToDictionary(htmlAttributes));
        }

        public static IHtmlString TextAreaFor<TModel>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, string>> expression, int rows, int columns, object htmlAttributes)
        {
            return TextArea(helper, ExpressionHelper.GetExpressionText(expression), expression.Compile()(helper.Model), rows, columns, TypeHelper.ObjectToDictionary(htmlAttributes));
        }

        public static IHtmlString TextAreaFor<TModel>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, string>> expression, int rows, int columns, IDictionary<string, object> htmlAttributes)
        {
            return TextArea(helper, ExpressionHelper.GetExpressionText(expression), expression.Compile()(helper.Model), rows, columns, TypeHelper.ObjectToDictionary(htmlAttributes));
        }
        
        public static IHtmlString TextArea<TModel>(this HtmlHelpers<TModel> helper, string name)
        {
            return TextArea(helper, name, null, null);
        }

        public static IHtmlString TextArea<TModel>(this HtmlHelpers<TModel> helper, string name, object htmlAttributes)
        {
            return TextArea(helper, name, null, TypeHelper.ObjectToDictionary(htmlAttributes));
        }

        public static IHtmlString TextArea<TModel>(this HtmlHelpers<TModel> helper, string name, IDictionary<string, object> htmlAttributes)
        {
            return TextArea(helper, name, null, htmlAttributes);
        }

        public static IHtmlString TextArea<TModel>(this HtmlHelpers<TModel> helper, string name, string value)
        {
            return TextArea(helper, name, value, null);
        }

        public static IHtmlString TextArea<TModel>(this HtmlHelpers<TModel> helper, string name, string value, object htmlAttributes)
        {
            return TextArea(helper, name, value, TypeHelper.ObjectToDictionary(htmlAttributes));
        }

        public static IHtmlString TextArea<TModel>(this HtmlHelpers<TModel> helper, string name, string value, IDictionary<string, object> htmlAttributes)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
            }

            return BuildTextArea(name, value, ImplicitRowsAndColumns, htmlAttributes);
        }

        public static IHtmlString TextArea<TModel>(this HtmlHelpers<TModel> helper, string name, string value, int rows, int columns, object htmlAttributes)
        {
            return TextArea(helper, name, value, rows, columns, TypeHelper.ObjectToDictionary(htmlAttributes));
        }

        public static IHtmlString TextArea<TModel>(this HtmlHelpers<TModel> helper, string name, string value, int rows, int columns, IDictionary<string, object> htmlAttributes)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
            }
            return BuildTextArea(name, value, GetRowsAndColumnsDictionary(rows, columns), htmlAttributes);
        }

        private static IHtmlString BuildTextArea(string name, string value, IDictionary<string, object> rowsAndColumnsDictionary, IDictionary<string, object> htmlAttributes)
        {
            var tagBuilder = new TagBuilder("textarea");

            //if (UnobtrusiveJavaScriptEnabled)
            //{
            //    // Add validation attributes
            //    var validationAttributes = _validationHelper.GetUnobtrusiveValidationAttributes(name);
            //    tagBuilder.MergeAttributes(validationAttributes, replaceExisting: false);
            //}

            // Add user specified htmlAttributes
            tagBuilder.MergeAttributes(htmlAttributes);

            tagBuilder.MergeAttributes(rowsAndColumnsDictionary, rowsAndColumnsDictionary != ImplicitRowsAndColumns);

            // Value becomes the inner html of the textarea element
            //var modelState = ModelState[name];
            //if (modelState != null)
            {
                value = value; //?? Convert.ToString(ModelState[name].Value, CultureInfo.CurrentCulture);
            }
            tagBuilder.InnerHtml = String.IsNullOrEmpty(value) ? String.Empty : HttpUtility.HtmlEncode(value);

            //Assign name and id
            tagBuilder.MergeAttribute("name", name);
            tagBuilder.GenerateId(name);

            //AddErrorClass(tagBuilder, name);

            return tagBuilder.ToHtmlString(TagRenderMode.Normal);
        }

        private static readonly IDictionary<string, object> ImplicitRowsAndColumns = new Dictionary<string, object>
        {
            { "rows", TextAreaRows.ToString(CultureInfo.InvariantCulture) },
            { "cols", TextAreaColumns.ToString(CultureInfo.InvariantCulture) },
        };

        private static IDictionary<string, object> GetRowsAndColumnsDictionary(int rows, int columns)
        {
            var result = new Dictionary<string, object>();
            if (rows > 0)
            {
                result.Add("rows", rows.ToString(CultureInfo.InvariantCulture));
            }
            if (columns > 0)
            {
                result.Add("cols", columns.ToString(CultureInfo.InvariantCulture));
            }
            return result;
        }
    }
}
