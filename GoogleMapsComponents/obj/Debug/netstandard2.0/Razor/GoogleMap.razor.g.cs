#pragma checksum "C:\Users\emzar\source\BlazorGoogleMaps\GoogleMapsComponents\GoogleMap.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5560a6f6e9f894bcab1b2151e49721047dc6c9f7"
// <auto-generated/>
#pragma warning disable 1591
namespace GoogleMapsComponents
{
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
#nullable restore
#line 1 "C:\Users\emzar\source\BlazorGoogleMaps\GoogleMapsComponents\GoogleMap.razor"
using System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\emzar\source\BlazorGoogleMaps\GoogleMapsComponents\GoogleMap.razor"
using Maps;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\emzar\source\BlazorGoogleMaps\GoogleMapsComponents\GoogleMap.razor"
using System.Threading.Tasks;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\emzar\source\BlazorGoogleMaps\GoogleMapsComponents\GoogleMap.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
    public partial class GoogleMap : MapComponent, System.IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "id", 
#nullable restore
#line 9 "C:\Users\emzar\source\BlazorGoogleMaps\GoogleMapsComponents\GoogleMap.razor"
                          Id

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(2, "class", 
#nullable restore
#line 9 "C:\Users\emzar\source\BlazorGoogleMaps\GoogleMapsComponents\GoogleMap.razor"
                                      CssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(3, "style", 
#nullable restore
#line 9 "C:\Users\emzar\source\BlazorGoogleMaps\GoogleMapsComponents\GoogleMap.razor"
                                                        StyleStr

#line default
#line hidden
#nullable disable
            );
            __builder.AddElementReferenceCapture(4, (__value) => {
#nullable restore
#line 9 "C:\Users\emzar\source\BlazorGoogleMaps\GoogleMapsComponents\GoogleMap.razor"
            Element = __value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 11 "C:\Users\emzar\source\BlazorGoogleMaps\GoogleMapsComponents\GoogleMap.razor"
       
    #nullable enable

    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public MapOptions? Options { get; set; }

    [Parameter]
    public EventCallback OnAfterInit { get; set; }

    [Parameter]
    public string? CssClass { get; set; }

    private string _height = "500px";

    /// <summary>
    /// Default height 500px
    /// Used as style atribute "height: {Height}"
    /// </summary>
    [Parameter]
    public string Height
    {
        get => _height;
        set => _height = value ?? "500px";
    }

    private string StyleStr => $"height: {Height};";

    private ElementReference Element { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {

        await InitAsync(Element, Options);

        //Debug.WriteLine("Init finished");

        await OnAfterInit.InvokeAsync(null);
    }

    protected override bool ShouldRender()
    {
        return false;
    }



#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
