using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace DatePickerSample.Extensions
{
    public static class HmtlHelpers
    {
        public static MvcHtmlString DatePickerFor<TModel, TProperty> (this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string cssClass)
        {
            var datePickerName = ExpressionHelper.GetExpressionText(expression);
            var datePickerFullName = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(datePickerName);
            var datePickerID = TagBuilder.CreateSanitizedId(datePickerFullName);

            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var datePickerValue = (metadata.Model == null ? DateTime.Now : DateTime.Parse(metadata.Model.ToString()));

            var tag = new TagBuilder("input");
            tag.Attributes.Add("name", datePickerFullName);
            tag.Attributes.Add("id", datePickerID);
            tag.Attributes.Add("type", "text");
            tag.Attributes.Add("value", datePickerValue.ToString());
            tag.Attributes.Add("class", "form-control");

            IDictionary<string, object> validationAttributes = helper.GetUnobtrusiveValidationAttributes(datePickerFullName, metadata);

            foreach (var key in validationAttributes.Keys)
            {
                tag.Attributes.Add(key, validationAttributes[key].ToString());
            }

            var html = new MvcHtmlString(tag.ToString(TagRenderMode.SelfClosing) + "<span class='input-group-addon'><span class='glyphicon glyphicon-calendar'></span></span>");
            
            return html;
        }

    }
}