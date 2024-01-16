using System;
using Dnet.Blazor.Components.Overlay.Infrastructure.Services;

namespace Dnet.Blazor.Components.Overlay.Infrastructure.Models
{
    public class OverlayReference(int overlayReferenceId)
    {
        public event Action<OverlayResult> Close;

        internal int OverlayReferenceId { get; set; } = overlayReferenceId;

        internal void CloseOverlayReference(OverlayResult overlayDataResult)
        {
            Close?.Invoke(overlayDataResult);
        }

        public int GetOverlayReferenceId()
        {
            return OverlayReferenceId;
        }
    }
}
