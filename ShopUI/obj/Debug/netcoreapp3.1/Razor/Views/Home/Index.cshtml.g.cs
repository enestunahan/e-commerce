#pragma checksum "C:\Users\Enes Tunahan\Desktop\Shop\ShopUI\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ddb0ced79af722f837ddb2e6bb85c9888f676b2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Enes Tunahan\Desktop\Shop\ShopUI\Views\_ViewImports.cshtml"
using ShopUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Enes Tunahan\Desktop\Shop\ShopUI\Views\_ViewImports.cshtml"
using ShopUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ddb0ced79af722f837ddb2e6bb85c9888f676b2", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e64fc2bac986d07314ec7836962de9aa15adefbe", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductListViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline my-2 my-lg-0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("align-items:center;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"


<script>
    $(document).ready(function () {

      


        $("".list-group"").on(""click"", "".categoryitem"", function () {
            $("".categoryitem"").css({ color: 'black', backgroundColor: 'white' });
            var categoryid = $(this).data(""id"");
            $(this).css({ color: 'aliceblue', backgroundColor: '#5bc0de'});
            $.ajax({
                type: ""POST"",
                data: { id: categoryid },
                url: ""/Home/ProductsGetByCategory"",
                success: function (data) {
                    $(""#products"").html(data);
                },
                error: function (data) {
                    console.log(data.status);
                }
            })
        })


        $("".form-inline"").on(""click"", "".btn"", function () {
            var search = $(""#searchinput"").val();
            if (search == """") {
                Swal.fire(
                    'Ne Aramıştınız?',
                    'Bu alanı boş geçilemez!!',
               ");
            WriteLiteral(@"     'question'
                )
            }
            else {
                $.ajax({
                    type: ""POST"",
                    data: { searchvalue: search },
                    url: ""/Home/Search"",
                    success: function (data) {
                        $(""#products"").html(data);
                    },
                    error: function (data) {

                    }
                })
            }         
        })

      

    })
</script>



<div class=""container-fluid"" style=""margin:0px; padding:0px;"">
    <div class=""row"">
        <div class=""col-2"">
            <div class=""list-group"" style=""margin-top:30px; margin-left:-15px; width:255px;"" >
");
#nullable restore
#line 64 "C:\Users\Enes Tunahan\Desktop\Shop\ShopUI\Views\Home\Index.cshtml"
                 foreach (var item in Model.Categories)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a data-id=\"");
#nullable restore
#line 66 "C:\Users\Enes Tunahan\Desktop\Shop\ShopUI\Views\Home\Index.cshtml"
                           Write(item.CategoryId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"list-group-item categoryitem \" style=\"cursor:pointer; text-align:center; font-size:25px; width:100%;\">");
#nullable restore
#line 66 "C:\Users\Enes Tunahan\Desktop\Shop\ShopUI\Views\Home\Index.cshtml"
                                                                                                                                                          Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 67 "C:\Users\Enes Tunahan\Desktop\Shop\ShopUI\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            <div class=\"col-12\" style=\"margin-top:60px;margin-left:-30px;\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ddb0ced79af722f837ddb2e6bb85c9888f676b27036", async() => {
                WriteLiteral(@"
                        <input class=""form-control mr-sm-2"" type=""search"" id=""searchinput"" name=""searchvalue"" placeholder=""ürün"" aria-label=""Search"" style=""width:255px; font-size:25px;"">
                        <br />
                        <button class=""btn btn-info my-sm-0 mt-3"" type=""button"" style=""width:300px; font-size:20px; font-weight:bold; margin-left:50px; margin-top:30px;"">Ara <i class=""fas fa-search""></i>  </button>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>           \r\n        </div>\r\n        <div class=\"col-8\" id=\"products\">         \r\n                ");
#nullable restore
#line 78 "C:\Users\Enes Tunahan\Desktop\Shop\ShopUI\Views\Home\Index.cshtml"
           Write(await Html.PartialAsync("_product"));

#line default
#line hidden
#nullable disable
            WriteLiteral("          \r\n        </div>\r\n        <div class=\"col-2\" style=\"margin-top:30px;\">\r\n            \r\n            ");
#nullable restore
#line 82 "C:\Users\Enes Tunahan\Desktop\Shop\ShopUI\Views\Home\Index.cshtml"
       Write(await Component.InvokeAsync("BestSellerProduct"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
