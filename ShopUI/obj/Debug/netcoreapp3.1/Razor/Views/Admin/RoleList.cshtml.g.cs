#pragma checksum "C:\Users\Enes Tunahan\Desktop\Shop\ShopUI\Views\Admin\RoleList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9521ad6ef06c4ca2f88f6180124d22f95e4f8511"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_RoleList), @"mvc.1.0.view", @"/Views/Admin/RoleList.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Enes Tunahan\Desktop\Shop\ShopUI\Views\Admin\RoleList.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9521ad6ef06c4ca2f88f6180124d22f95e4f8511", @"/Views/Admin/RoleList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e64fc2bac986d07314ec7836962de9aa15adefbe", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_RoleList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IdentityRole>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""container"">
    <div class=""row"">    
        <div class=""col-12"">
            <br/>
            <a href=""/Admin/CreateRole"" class=""btn btn-success"">Rol Oluştur</a>
            <table class=""table table-bordered"" style=""margin-top:25px;"">
                <tr>
                    <th>ID</th>
                    <th>Role</th>
                    <th>Düzenle</th>
                   
                </tr>
");
#nullable restore
#line 16 "C:\Users\Enes Tunahan\Desktop\Shop\ShopUI\Views\Admin\RoleList.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 19 "C:\Users\Enes Tunahan\Desktop\Shop\ShopUI\Views\Admin\RoleList.cshtml"
                       Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"width:350px;\">");
#nullable restore
#line 20 "C:\Users\Enes Tunahan\Desktop\Shop\ShopUI\Views\Admin\RoleList.cshtml"
                                            Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td> \r\n                        <td  style=\"width:350px;\"><a");
            BeginWriteAttribute("href", " href=\"", 757, "\"", 788, 2);
            WriteAttributeValue("", 764, "/Admin/EditRole/", 764, 16, true);
#nullable restore
#line 21 "C:\Users\Enes Tunahan\Desktop\Shop\ShopUI\Views\Admin\RoleList.cshtml"
WriteAttributeValue("", 780, item.Id, 780, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning\">Düzenle</a></td>                     \r\n                    </tr>\r\n");
#nullable restore
#line 23 "C:\Users\Enes Tunahan\Desktop\Shop\ShopUI\Views\Admin\RoleList.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IdentityRole>> Html { get; private set; }
    }
}
#pragma warning restore 1591
