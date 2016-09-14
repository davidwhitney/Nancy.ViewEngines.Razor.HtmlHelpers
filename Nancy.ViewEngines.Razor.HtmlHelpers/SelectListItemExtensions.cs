using System;
using System.Collections.Generic;

namespace Nancy.ViewEngines.Razor.HtmlHelpersUnofficial
{
    public static class SelectListItemExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(this Enum src, Enum selectedValue = null)
        {
            var selectListItems = new List<SelectListItem>();
            foreach (var item in Enum.GetValues(src.GetType()))
            {
                var isDefault = selectedValue != null && item.ToString() == selectedValue.ToString();
                selectListItems.Add(new SelectListItem(item.ToString(), item.ToString(), isDefault));
            }
            return selectListItems;
        }
    }
}