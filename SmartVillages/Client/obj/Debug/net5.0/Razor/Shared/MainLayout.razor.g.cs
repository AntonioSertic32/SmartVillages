#pragma checksum "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e8aadcf1c4e0954290b3ac61359fbc3a97b2dae5"
// <auto-generated/>
#pragma warning disable 1591
namespace SmartVillages.Client.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\_Imports.razor"
using SmartVillages.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\_Imports.razor"
using SmartVillages.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : MainLayoutBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<MudBlazor.MudThemeProvider>(0);
            __builder.CloseComponent();
            __builder.AddMarkupContent(1, "\r\n");
            __builder.OpenComponent<MudBlazor.MudDialogProvider>(2);
            __builder.CloseComponent();
            __builder.AddMarkupContent(3, "\r\n");
            __builder.OpenComponent<MudBlazor.MudSnackbarProvider>(4);
            __builder.CloseComponent();
            __builder.AddMarkupContent(5, "\r\n\r\n");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "page");
            __builder.AddAttribute(8, "b-zvhpk9gg6e");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "sidebar");
            __builder.AddAttribute(11, "b-zvhpk9gg6e");
            __builder.OpenComponent<SmartVillages.Client.Shared.NavMenu>(12);
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n\r\n    ");
            __builder.OpenElement(14, "div");
            __builder.AddAttribute(15, "class", "main");
            __builder.AddAttribute(16, "b-zvhpk9gg6e");
            __builder.OpenElement(17, "div");
            __builder.AddAttribute(18, "class", "top-row px-4");
            __builder.AddAttribute(19, "b-zvhpk9gg6e");
            __builder.OpenComponent<MudBlazor.MudMenu>(20);
            __builder.AddAttribute(21, "Label", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 14 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Shared\MainLayout.razor"
                             FullName

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(22, "Variant", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Variant>(
#nullable restore
#line 14 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Shared\MainLayout.razor"
                                                Variant.Filled

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(23, "Color", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Color>(
#nullable restore
#line 14 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Shared\MainLayout.razor"
                                                                       Color.Primary

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(24, "Direction", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Direction>(
#nullable restore
#line 14 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Shared\MainLayout.razor"
                                                                                                 Direction.Bottom

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(25, "OffsetY", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 14 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Shared\MainLayout.razor"
                                                                                                                            true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(26, "FullWidth", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 14 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Shared\MainLayout.razor"
                                                                                                                                              true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(27, "EndIcon", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 14 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Shared\MainLayout.razor"
                                                                                                                                                              Icons.Material.Filled.ArrowDropDown

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(28, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<MudBlazor.MudMenuItem>(29);
                __builder2.AddAttribute(30, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(31, "Profile");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(32, "\r\n                ");
                __builder2.OpenComponent<MudBlazor.MudMenuItem>(33);
                __builder2.AddAttribute(34, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(35, "Settings");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(36, "\r\n                ");
                __builder2.OpenComponent<MudBlazor.MudMenuItem>(37);
                __builder2.AddAttribute(38, "OnClick", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 17 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Shared\MainLayout.razor"
                                      Logout

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(39, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(40, "Logout");
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\r\n\r\n        ");
            __builder.OpenElement(42, "div");
            __builder.AddAttribute(43, "b-zvhpk9gg6e");
            __builder.AddContent(44, 
#nullable restore
#line 22 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Shared\MainLayout.razor"
             Body

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
