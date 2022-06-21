using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCExample.Models;
using System.Text.Encodings.Web;


namespace MVCExample.Helper
{
  public static class ProductHelper
  {
    public static HtmlString CreateListProductTagHelper(this IHtmlHelper html, List<Product> products)
    {
      TagBuilder table = new TagBuilder("table");
      TagBuilder tr = new TagBuilder("tr");
      TagBuilder td = new TagBuilder("td");
      tr.InnerHtml.AppendHtml(td.InnerHtml.Append("Name")); 
      tr.InnerHtml.AppendHtml(td.InnerHtml.Append("Price")); 
      tr.InnerHtml.AppendHtml(td.InnerHtml.Append("CategoryName"));
      tr.InnerHtml.AppendHtml(new TagBuilder("br"));
      foreach(Product product in products){
        TagBuilder newTd = new TagBuilder("td");
        newTd.InnerHtml.Append(product.Name);
        newTd.InnerHtml.Append(product.Price.ToString());
        newTd.InnerHtml.Append(product.category.Name);
        tr.InnerHtml.AppendHtml(newTd);
      }
      table.InnerHtml.AppendHtml(tr);
      var writer = new StringWriter();
      table.WriteTo(writer, HtmlEncoder.Default);
      return new HtmlString(writer.ToString());
    }

  }
}
