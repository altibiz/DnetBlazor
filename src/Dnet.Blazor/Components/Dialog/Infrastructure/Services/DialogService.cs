﻿using Dnet.Blazor.Components.Dialog.Infrastructure.Interfaces;
using Dnet.Blazor.Components.Dialog.Infrastructure.Models;
using Dnet.Blazor.Components.Overlay.Infrastructure.Interfaces;
using Dnet.Blazor.Components.Overlay.Infrastructure.Models;
using Dnet.Blazor.Components.Overlay.Infrastructure.Services;
using Microsoft.AspNetCore.Components;

namespace Dnet.Blazor.Components.Dialog.Infrastructure.Services
{
    public class DialogService(IOverlayService overlayService) : IDialogService
    {
        public OverlayReference Open(Type componentType, IDictionary<string, object> parameters, DialogConfig dialogConfig)
        {
            if (!typeof(ComponentBase).IsAssignableFrom(componentType))
            {
                throw new ArgumentException($"{componentType.FullName} must be a Blazor Component");
            }

            var globalPositionStrategy = new GlobalPositionStrategyBuilder();

            globalPositionStrategy.CenterVertically("");
            globalPositionStrategy.CenterHorizontally("");

            var overlayConfig = new OverlayConfig()
            {
                HasBackdrop = dialogConfig.HasBackdrop,
                HasTransparentBackdrop = dialogConfig.HasTransparentBackdrop,
                Width = dialogConfig.Width,
                Height = dialogConfig.Height,
                MaxHeight = dialogConfig.MaxHeight,
                MaxWidth = dialogConfig.MaxWidth,
                GlobalPositionStrategy = globalPositionStrategy
            };

            var dialog = new RenderFragment(x =>
            {
                x.OpenComponent(0, typeof(DnetDialog));
                if (componentType != null) x.AddAttribute(1, "ComponentType", componentType);
                if (componentType != null && parameters.Any()) x.AddAttribute(2, "Parameters", parameters);
                x.AddAttribute(3, "Title", dialogConfig.Title);
                x.AddAttribute(4, "DialogClass", dialogConfig.DialogClass);
                x.CloseComponent();
            });

            var overlayReference = overlayService.Attach(dialog, overlayConfig);

            return overlayReference;
        }

        public void Close(OverlayResult overlayDataResult)
        {
            overlayService.Detach(overlayDataResult);
        }
    }
}
