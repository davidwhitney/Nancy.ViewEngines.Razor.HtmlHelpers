using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Nancy.ViewEngines.Razor.HtmlHelpersUnofficial
{
    public class ModelMetadata
    {
        public const int DefaultOrder = 10000;

        public virtual Dictionary<string, object> AdditionalValues { get; set; }

        public Type ContainerType { get; set; }
        public virtual bool ConvertEmptyStringToNull { get; set; }
        public virtual string DataTypeName { get; set; }
        public virtual string Description { get; set; }
        public virtual string DisplayFormatString { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string EditFormatString { get; set; }
        public virtual bool HideSurroundingHtml { get; set; }
        public virtual bool IsComplexType { get; set; }
        public bool IsNullableValueType { get; set; }
        public virtual bool IsReadOnly { get; set; }
        public virtual bool IsRequired { get; set; }
        public object Model { get; set; }
        public Type ModelType { get; set; }
        public virtual string NullDisplayText { get; set; }
        public virtual int Order { get; set; }
        public virtual IEnumerable<ModelMetadata> Properties { get; set; }
        public string PropertyName { get; set; }
        internal Type RealModelType { get; set; }
        public virtual bool RequestValidationEnabled { get; set; }
        public virtual string ShortDisplayName { get; set; }
        public virtual bool ShowForDisplay { get; set; }
        public virtual bool ShowForEdit { get; set; }
        public virtual string SimpleDisplayText { get; set; }
        public virtual string TemplateHint { get; set; }
        public virtual string Watermark { get; set; }
        
        public string GetDisplayName()
        {
            return DisplayName ?? PropertyName ?? ModelType.Name;
        }

        protected virtual string GetSimpleDisplayText()
        {
            if (Model == null)
            {
                return NullDisplayText;
            }

            var toStringResult = Convert.ToString(Model, CultureInfo.CurrentCulture);

            if (!toStringResult.Equals(Model.GetType().FullName, StringComparison.Ordinal))
            {
                return toStringResult;
            }

            var firstProperty = Properties.FirstOrDefault();
            if (firstProperty == null)
            {
                return String.Empty;
            }

            if (firstProperty.Model == null)
            {
                return firstProperty.NullDisplayText;
            }

            return Convert.ToString(firstProperty.Model, CultureInfo.CurrentCulture);
        }
    }
}