using Dnet.Blazor.Components.Overlay.Infrastructure.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Dnet.Blazor.Components.Overlay.Infrastructure.Services
{
    public class DnetOverlayInterop(IJSRuntime jsRuntime)
    {
        public ValueTask<object> AddKeyDownEventListener(ElementReference element)
        {
            return jsRuntime.InvokeAsync<object>("dnetoverlay.addKeyDownEventListener", element);
        }

        public ValueTask<ViewportScrollPosition> GetViewportScrollPosition()
        {
            return jsRuntime.InvokeAsync<ViewportScrollPosition>("dnetoverlay.getViewportScrollPosition");
        }

        public ValueTask<Models.Size> GetViewportSize()
        {
            return jsRuntime.InvokeAsync<Models.Size>("dnetoverlay.getViewportSize");
        }

        public ValueTask<Models.Size> GetViewportSizeNoScroll()
        {
            return jsRuntime.InvokeAsync<Models.Size>("dnetoverlay.getViewportSizeNoScroll");
        }

        public ValueTask<FlexibleConnectedPositionStrategyOrigin> GetBoundingClientRect(ElementReference element)
        {
            return jsRuntime.InvokeAsync<FlexibleConnectedPositionStrategyOrigin>("dnetoverlay.getBoundingClientRect", element);
        }

        public ValueTask<FlexibleConnectedPositionStrategyOrigin> GetDocumentBoundingClientRect()
        {
            return jsRuntime.InvokeAsync<FlexibleConnectedPositionStrategyOrigin>("dnetoverlay.getDocumentBoundingClientRect");
        }

        public ValueTask<int> GetDocumentClientHeight()
        {
            return jsRuntime.InvokeAsync<int>("dnetoverlay.getDocumentClientHeight");
        }

        public ValueTask<int> GetDocumentClientWidth()
        {
            return jsRuntime.InvokeAsync<int>("dnetoverlay.getDocumentClientWidth");
        }
    }
}
