#pragma checksum "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\Pages\Configuration - Copy.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "de2e463ff37b6418adec9e80d0787f9896bf7d9f"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/configuration")]
    public partial class Configuration___Copy : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 86 "C:\Source\Repos\Automation\SkyHighRemote\SkyHighRemote\Client\Pages\Configuration - Copy.razor"
       

    List<SkyHDBox> boxes = new List<SkyHDBox>();
    private bool loading = false;

    /// <summary>
    /// Gets list of Sky HD boxes from the Server
    /// </summary>
    /// <returns></returns>
    private async Task FindBoxes()
    {

        try
        {
            loading = true;
            boxes = await Http.GetFromJsonAsync<List<SkyHDBox>>("skyremote/findboxes");
        }
        catch (Exception ex)
        {
            await JsRuntime.InvokeVoidAsync("alert", $"There was a problem : {ex}");
        }

        loading = false;
    }

    /// <summary>
    /// Selects the box the user wishes to use in the app
    /// </summary>
    /// <param name="ipAddress"></param>
    private void SelectBox(string ipAddress)
    {
        if (!String.IsNullOrEmpty(ipAddress))
        {
            AppConfig.SkyBoxIP = ipAddress;
            AppConfig.Save();

            boxes.Clear();
        }
    }

    /// <summary>
    /// Clears the IP of the box we are controlling
    /// </summary>
    private void ClearBox()
    {
        AppConfig.SkyBoxIP = String.Empty;
        AppConfig.Save();
    }

    /// <summary>
    /// Sets vibrate setting based on the toggle state
    /// </summary>
    private async Task ToggleVibrate()
    {
        AppConfig.Vibrate = (AppConfig.Vibrate == true ? false : true);
        AppConfig.Save();

        //Fire a vibrate to allow for any permissions popups to be actioned in certain browsers.
        if (AppConfig.Vibrate)
        {
            await JsRuntime.InvokeVoidAsync("feedback", true, false, false);
        }
    }

    /// <summary>
    /// Sets play sound setting based on the toggle state
    /// </summary>
    private async Task TogglePlaySound()
    {
        AppConfig.PlaySound = (AppConfig.PlaySound == true ? false : true);
        AppConfig.Save();

        //Fire a sound to allow for any permissions popups to be actioned in certain browsers.
        if (AppConfig.PlaySound)
        {
            await JsRuntime.InvokeVoidAsync("feedback", false, true, false);
        }
    }


    /// <summary>
    /// Sets showvisual setting based on the toggle state
    /// </summary>
    private void ToggleShowVisual()
    {
        AppConfig.ShowVisual = (AppConfig.ShowVisual == true ? false : true);
        AppConfig.Save();
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JsRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IWebAssemblyHostEnvironment HostEnvironment { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private SkyHighRemote.Client.IAppConfiguration AppConfig { get; set; }
    }
}
#pragma warning restore 1591
