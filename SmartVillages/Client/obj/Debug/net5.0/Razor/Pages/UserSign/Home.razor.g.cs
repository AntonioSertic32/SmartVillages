#pragma checksum "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55ffbbcefaf66393c166345799ce71a4a41ff3e0"
// <auto-generated/>
#pragma warning disable 1591
namespace SmartVillages.Client.Pages.UserSign
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
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(UserSignLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Home : HomeBase
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
            __builder.AddAttribute(7, "class", "parent-container");
            __builder.AddAttribute(8, "b-317gdq97dd");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "col home home-left-side");
            __builder.AddAttribute(11, "b-317gdq97dd");
#nullable restore
#line 15 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
         if (leftSignInOpened)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<SmartVillages.Client.Pages.UserSign.SignIn>(12);
            __builder.AddAttribute(13, "isLeftOpened", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 17 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
                                  isLeftOpened

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(14, "OpenSignUp", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 17 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
                                                            OpenSignUp

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(15, "goBack", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 17 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
                                                                                GoBackPressed

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
#nullable restore
#line 18 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
        }
        else if (leftSignUpOpened)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<SmartVillages.Client.Pages.UserSign.SignUp>(16);
            __builder.AddAttribute(17, "IsLeftOpened", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 21 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
                                  isLeftOpened

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(18, "OpenSignIn", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 21 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
                                                            OpenSignIn

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(19, "GoBack", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 21 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
                                                                                GoBackPressed

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
#nullable restore
#line 22 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(20, "<section id=\"top-contact\" b-317gdq97dd></section>\r\n            <img class=\"home-img\" src=\"./img/illustrations/DarkWatering.png\" b-317gdq97dd>\r\n            ");
            __builder.OpenElement(21, "div");
            __builder.AddAttribute(22, "class", "home-container container text-center");
            __builder.AddAttribute(23, "b-317gdq97dd");
            __builder.AddMarkupContent(24, "<h1 b-317gdq97dd>Nastavi kao poljoprivrednik</h1>\r\n                ");
            __builder.OpenElement(25, "div");
            __builder.AddAttribute(26, "style", "width: 100%");
            __builder.AddAttribute(27, "b-317gdq97dd");
            __builder.OpenElement(28, "button");
            __builder.AddAttribute(29, "type", "button");
            __builder.AddAttribute(30, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 30 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
                                                    OpenRightSignIn

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(31, "class", "btn btn-lg btn-block");
            __builder.AddAttribute(32, "b-317gdq97dd");
            __builder.AddContent(33, "Prijava");
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n                    ");
            __builder.OpenElement(35, "button");
            __builder.AddAttribute(36, "type", "button");
            __builder.AddAttribute(37, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 31 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
                                                    OpenRightSignUp

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(38, "class", "btn btn-lg btn-block");
            __builder.AddAttribute(39, "b-317gdq97dd");
            __builder.AddContent(40, "Registracija");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 34 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\r\n\r\n    ");
            __builder.OpenElement(42, "div");
            __builder.AddAttribute(43, "class", "col home home-right-side");
            __builder.AddAttribute(44, "b-317gdq97dd");
#nullable restore
#line 38 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
         if (rightSignInOpened)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<SmartVillages.Client.Pages.UserSign.SignIn>(45);
            __builder.AddAttribute(46, "isLeftOpened", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 40 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
                                  isLeftOpened

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(47, "OpenSignUp", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 40 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
                                                            OpenSignUp

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(48, "goBack", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 40 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
                                                                                GoBackPressed

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
#nullable restore
#line 41 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
        }
        else if (rightSignUpOpened)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<SmartVillages.Client.Pages.UserSign.SignUp>(49);
            __builder.AddAttribute(50, "IsLeftOpened", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 44 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
                                  isLeftOpened

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(51, "OpenSignIn", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 44 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
                                                            OpenSignIn

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(52, "GoBack", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 44 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
                                                                                GoBackPressed

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
#nullable restore
#line 45 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(53, "<img class=\"home-img\" src=\"./img/illustrations/DarkNotifications.png\" b-317gdq97dd>\r\n            ");
            __builder.OpenElement(54, "div");
            __builder.AddAttribute(55, "class", "home-container container text-center");
            __builder.AddAttribute(56, "b-317gdq97dd");
            __builder.AddMarkupContent(57, "<h1 b-317gdq97dd>Nastavi kao kupac</h1>\r\n                ");
            __builder.OpenElement(58, "div");
            __builder.AddAttribute(59, "style", "width: 100%");
            __builder.AddAttribute(60, "b-317gdq97dd");
            __builder.OpenElement(61, "button");
            __builder.AddAttribute(62, "type", "button");
            __builder.AddAttribute(63, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 52 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
                                                    OpenLeftSignIn

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(64, "class", "btn btn-lg btn-block");
            __builder.AddAttribute(65, "b-317gdq97dd");
            __builder.AddContent(66, "Prijava");
            __builder.CloseElement();
            __builder.AddMarkupContent(67, "\r\n                    ");
            __builder.OpenElement(68, "button");
            __builder.AddAttribute(69, "type", "button");
            __builder.AddAttribute(70, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 53 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
                                                    OpenLeftSignUp

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(71, "class", "btn btn-lg btn-block");
            __builder.AddAttribute(72, "b-317gdq97dd");
            __builder.AddContent(73, "Registracija");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(74, "\r\n            <section id=\"bottom-contact\" b-317gdq97dd></section>");
#nullable restore
#line 57 "E:\asertic\Documents\GitHub\SmartVillages\SmartVillages\Client\Pages\UserSign\Home.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
