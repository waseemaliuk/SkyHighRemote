#pragma checksum "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b1cacaa09580cb06c7643631f93f95fb1992cb8"
// <auto-generated/>
#pragma warning disable 1591
namespace SkyHighRemote.Client.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\_Imports.razor"
using SkyHighRemote.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\_Imports.razor"
using SkyHighRemote.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\_Imports.razor"
using SkyHighRemote.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\_Imports.razor"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\_Imports.razor"
using Blazored.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\_Imports.razor"
using Blazored.Modal.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\_Imports.razor"
using System.Text.RegularExpressions;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "sidebar");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenComponent<SkyHighRemote.Client.Shared.NavMenu>(3);
            __builder.CloseComponent();
            __builder.AddMarkupContent(4, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(5, "\r\n\r\n");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "main");
            __builder.AddMarkupContent(8, "\r\n    ");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "content px-4");
            __builder.AddMarkupContent(11, "\r\n        ");
            __builder.AddContent(12, 
#nullable restore
#line 9 "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\Shared\MainLayout.razor"
         Body

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(13, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
