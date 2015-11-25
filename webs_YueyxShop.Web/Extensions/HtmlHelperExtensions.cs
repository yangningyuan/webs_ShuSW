using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;


public static class HtmlHelperExtensions
{
    public static MvcHtmlString CheckBoxList(this HtmlHelper helper, string name, object value, IEnumerable<SelectListItem> selectList)
    {
        return CheckBoxList(helper, name, value, selectList, new { });
    }
    public static MvcHtmlString CheckBoxList(this HtmlHelper helper, string name, object value, IEnumerable<SelectListItem> selectList, object htmlAttributes)
    {
        IDictionary<string, object> HtmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

        HashSet<string> set = new HashSet<string>();
        List<SelectListItem> list = new List<SelectListItem>();
        // string selectedValues = Convert.ToString((selectList as SelectList).SelectedValue);
        string selectedValues = Convert.ToString(value);
        if (!string.IsNullOrEmpty(selectedValues))
        {
            if (selectedValues.Contains(","))
            {
                string[] tempStr = selectedValues.Split(',');
                for (int i = 0; i < tempStr.Length; i++)
                {
                    set.Add(tempStr[i]);
                }

            }
            else
            {
                set.Add(selectedValues);
            }
        }

        foreach (SelectListItem item in selectList)
        {
            item.Selected = (item.Value != null) ? set.Contains(item.Value) : set.Contains(item.Text);
            list.Add(item);
        }
        selectList = list;

        HtmlAttributes.Add("type", "checkbox");
        HtmlAttributes.Add("id", name);
        HtmlAttributes.Add("name", name);
        HtmlAttributes.Add("style", "margin:0 0 0 0;line-height:30px; vertical-align:-8px;border:none;");

        StringBuilder stringBuilder = new StringBuilder();

        foreach (SelectListItem selectItem in selectList)
        {
            IDictionary<string, object> newHtmlAttributes = HtmlAttributes.DeepCopy();
            newHtmlAttributes.Add("value", selectItem.Value);
            if (selectItem.Selected)
            {
                newHtmlAttributes.Add("checked", "checked");
            }

            TagBuilder tagBuilder = new TagBuilder("input");
            tagBuilder.MergeAttributes<string, object>(newHtmlAttributes);
            string inputAllHtml = tagBuilder.ToString(TagRenderMode.SelfClosing);
            stringBuilder.AppendFormat(@"<label class=""CheckBoxList"" style=""margin:0 10px 0 0;""> {0}  {1}</label>",
               inputAllHtml, selectItem.Text);
        }
        return MvcHtmlString.Create(stringBuilder.ToString());

    }
}
