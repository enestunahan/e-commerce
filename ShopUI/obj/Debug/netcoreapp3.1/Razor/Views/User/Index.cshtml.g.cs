#pragma checksum "C:\Users\Enes Tunahan\Desktop\Shop\ShopUI\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ffd5e7b5d8640507ecce8d3fa1e7401bf1169a60"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Index), @"mvc.1.0.view", @"/Views/User/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffd5e7b5d8640507ecce8d3fa1e7401bf1169a60", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e64fc2bac986d07314ec7836962de9aa15adefbe", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<script>


    $(document).ready(function () {
        $(""#address"").click(function () {
            $.ajax({
                type: ""GET"",
                url: ""/User/GetUserAddressess"",
                success: function (data) {
                    $(""#userinfo"").html(data);
                },

            })
        })

        //$(""#orders"").click(function () {
        //    $.ajax({
        //        type: ""GET"",
        //        url: ""/User/GetUserOrders"",
        //        success: function (data) {
        //            $(""#userinfo"").html(data);
        //        },
        //        error: function () {
        //            console.log(""Hata oluştu"");
        //        }
        //    })
        //})

        $(""#orders"").click(function () {
            $.get(""/User/GetUserOrders"").done(function (data) {

                $(""#userinfo"").html(data);
            });
        })
    })
</script>


<div class=""container-fluid"">
    <div class=""row"">
        <div ");
            WriteLiteral(@"class=""col-3"" style=""margin-top:50px; margin-left:-3%;"">

            <ul class=""list-group list-group-flush"" style=""text-align:end; cursor:pointer;"">
                <li class=""list-group-item"" style=""font-weight:bold; font-size:25px; background-color:green; color:aliceblue;""><i class=""fas fa-user-tag""></i>  Kişisel Bilgilerim</li>
                <br />
                <li id=""address"" class=""list-group-item"" style=""font-weight:bold; font-size:25px;background-color:green; color:aliceblue;""><i class=""fas fa-location-arrow""></i>  Adres Bilgilerim</li>
                <br />
                <li id=""orders"" class=""list-group-item"" style=""font-weight:bold; font-size:25px; background-color:green; color:aliceblue;""><i class=""fas fa-gift""></i>  Geçmiş Siparişlerim</li>
                <br />
                <li class=""list-group-item"" style=""font-weight:bold; font-size:25px; background-color:green; color:aliceblue;""><i class=""fab fa-cc-visa""></i>  Ödeme Yöntemlerim</li>
            </ul>
        </div>
");
            WriteLiteral("        <div class=\"col-6\" id=\"userinfo\" style=\"margin-top:50px;\">\r\n\r\n        </div>\r\n        <div class=\"col-3\" style=\"margin-top:30px;\">\r\n");
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591