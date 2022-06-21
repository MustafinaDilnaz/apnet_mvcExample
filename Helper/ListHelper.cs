using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace MVCExample.Helper
{
  public static class ListHelper
  {
    public static HtmlString CreateList(this IHtmlHelper html, string[] items)
    {
      string result = "<ul>";
      foreach (string item in items)
      {
        result = $"{result}<li>{item}</li>";
      }
      result = $"{result}</ul> ";
      return new HtmlString(result);
    }


    public static HtmlString CreateListTagHelper(this IHtmlHelper html, string[] items)
    {
      TagBuilder ul = new TagBuilder("ul");
      foreach (string item in items)
      {
        TagBuilder li = new TagBuilder("li");
        li.InnerHtml.Append(item);
        ul.InnerHtml.AppendHtml(li);
      }
      ul.Attributes.Add("class", "itemList");
      var writer = new StringWriter();
      ul.WriteTo(writer, HtmlEncoder.Default);
      return new HtmlString(writer.ToString());

    }
  }
}
