using System;
using System.Linq.Expressions;

namespace Nancy.ViewEngines.Razor.HtmlHelpers
{
    public class MetaModelBuilder
    {
        public ModelMetadata FromLambdaExpression<TParameter, TValue>(Expression<Func<TParameter, TValue>> expression, object model)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new ModelMetadata
            {
                Model = model,
                
            };
        }

    }
}