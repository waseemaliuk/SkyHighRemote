#pragma checksum "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c72fd65c37c300eb61928dfff8fb81d021afbd6a"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SkyHighRemote.Client.Pages
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
#nullable restore
#line 10 "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\Pages\Index.razor"
using SkyHighRemote.Client.Components;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 63 "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\Pages\Index.razor"
       

    protected override void OnInitialized()
    {
        Console.WriteLine($"Hosting Environment : {HostEnvironment.Environment}");

        if (AppConfig == null)
        {
            NavManager.NavigateTo("/configuration");
        }
        else
        {
            if (String.IsNullOrEmpty(AppConfig.SkyBoxIP))
            {
                NavManager.NavigateTo("/configuration");
            }

        }
    }

    /// <summary>
    /// Sends command to the box defined in AppConfig
    /// </summary>
    /// <param name="command"></param>
    private async Task SendCommand(string command)
    {
        try
        {
            //Output any feedback
            await JsRuntime.InvokeVoidAsync("feedback", AppConfig.Vibrate, AppConfig.PlaySound, AppConfig.ShowVisual);

            HttpResponseMessage response = await Http.PostAsync($"skyremote/sendcommand/{AppConfig.SkyBoxIP}/{command}", null);

            if (HostEnvironment.IsDevelopment())
            {
                Console.WriteLine(response);
            }

            if (!response.IsSuccessStatusCode)
            {
                await JsRuntime.InvokeVoidAsync("alert", $"There was a problem : {response.ReasonPhrase}");
            }

        }
        catch (Exception ex)
        {
            await JsRuntime.InvokeVoidAsync("alert", $"There was a problem : {ex}");
        }

    }

    /// <summary>
    /// Sends the PIN to the service for passing to box
    /// </summary>
    /// <returns></returns>
    private async Task SendPIN()
    {
        if (String.IsNullOrEmpty(AppConfig.SkyPIN))
        {
            await JsRuntime.InvokeVoidAsync("alert", "No PIN has been set.  Set one in Configuration.");
            NavManager.NavigateTo("/configuration");
        }
        else
        {
            try
            {
                //Output any feedback
                await JsRuntime.InvokeVoidAsync("feedback", AppConfig.Vibrate, AppConfig.PlaySound, AppConfig.ShowVisual);

                HttpResponseMessage response = await Http.PostAsync($"skyremote/sendpin/{AppConfig.SkyBoxIP}/{AppConfig.SkyPIN}", null);

                if (HostEnvironment.IsDevelopment())
                {
                    Console.WriteLine(response);
                }

                if (!response.IsSuccessStatusCode)
                {
                    await JsRuntime.InvokeVoidAsync("alert", $"There was a problem : {response.ReasonPhrase}");
                }

            }
            catch (Exception ex)
            {
                await JsRuntime.InvokeVoidAsync("alert", $"There was a problem : {ex}");
            }
        }
    }

    /// <summary>
    /// Shows SendTextPopup in a modal window
    /// </summary>
    /// <returns></returns>
    private void ShowKeyboardModal()
    {
        Modal.Show<SendTextPopup>("Send Text");
    }

    /// <summary>
    /// Throws up a popup when a button isn't implemented
    /// </summary>
    /// <param name="button">The name of the button</param>
    private async Task NotImplemented(string button)
    {
        await JsRuntime.InvokeVoidAsync("alert", $"Button '{button}' is not implemented.");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IModalService Modal { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private SkyHighRemote.Client.IAppConfiguration AppConfig { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JsRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IWebAssemblyHostEnvironment HostEnvironment { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
