#pragma checksum "C:\Users\Antonio\source\repos\SmartVillages\SmartVillages\Client\Pages\UserSign\EmailConfirmation.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "778253cb115955574310bea1fab2e6ef192ce5fc"
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
#line 1 "C:\Users\Antonio\source\repos\SmartVillages\SmartVillages\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Antonio\source\repos\SmartVillages\SmartVillages\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Antonio\source\repos\SmartVillages\SmartVillages\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Antonio\source\repos\SmartVillages\SmartVillages\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Antonio\source\repos\SmartVillages\SmartVillages\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Antonio\source\repos\SmartVillages\SmartVillages\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Antonio\source\repos\SmartVillages\SmartVillages\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Antonio\source\repos\SmartVillages\SmartVillages\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Antonio\source\repos\SmartVillages\SmartVillages\Client\_Imports.razor"
using SmartVillages.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Antonio\source\repos\SmartVillages\SmartVillages\Client\_Imports.razor"
using SmartVillages.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Antonio\source\repos\SmartVillages\SmartVillages\Client\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/emailconfirmation/{code}/{oib}")]
    public partial class EmailConfirmation : EmailConfirmationBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>EmailConfirmation</h3>\r\n");
            __builder.OpenElement(1, "p");
            __builder.AddContent(2, "Your code is: ");
            __builder.AddContent(3, 
#nullable restore
#line 5 "C:\Users\Antonio\source\repos\SmartVillages\SmartVillages\Client\Pages\UserSign\EmailConfirmation.razor"
                  Code

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(4, "\r\n");
            __builder.OpenElement(5, "p");
            __builder.AddContent(6, "Your email is: ");
            __builder.AddContent(7, 
#nullable restore
#line 6 "C:\Users\Antonio\source\repos\SmartVillages\SmartVillages\Client\Pages\UserSign\EmailConfirmation.razor"
                   Oib

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 8 "C:\Users\Antonio\source\repos\SmartVillages\SmartVillages\Client\Pages\UserSign\EmailConfirmation.razor"
 if (IsValid)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(8, "p");
            __builder.AddContent(9, 
#nullable restore
#line 10 "C:\Users\Antonio\source\repos\SmartVillages\SmartVillages\Client\Pages\UserSign\EmailConfirmation.razor"
        Message

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 11 "C:\Users\Antonio\source\repos\SmartVillages\SmartVillages\Client\Pages\UserSign\EmailConfirmation.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(10, "<p>Validateing..</p>");
#nullable restore
#line 15 "C:\Users\Antonio\source\repos\SmartVillages\SmartVillages\Client\Pages\UserSign\EmailConfirmation.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
