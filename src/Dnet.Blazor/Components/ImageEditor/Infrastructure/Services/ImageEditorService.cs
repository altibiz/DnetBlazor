using System.Collections.Generic;
using Dnet.Blazor.Components.ImageEditor.Infrastructure.Constants;
using Dnet.Blazor.Components.ImageEditor.Infrastructure.Models;

namespace Dnet.Blazor.Components.ImageEditor.Infrastructure.Services
{
    public class ImageEditorService : IImageEditorService
    {
        public void UpdateResizersData(ResizerData resizer, double top, double left, double width, double height)
        {
            if (resizer.ResizerType == ResizerType.TopCenter)
            {
                resizer.Top = top - resizer.Height / 2;
                resizer.Left = left + (width / 2 - resizer.Width / 2);
            }
            else if (resizer.ResizerType == ResizerType.BottomCenter)
            {
                resizer.Top = top + height - resizer.Height / 2;
                resizer.Left = left + ((width / 2) - (resizer.Width / 2));
            }
            else if (resizer.ResizerType == ResizerType.LeftCenter)
            {
                resizer.Top = top + ((height / 2) - (resizer.Height / 2));
                resizer.Left = left - resizer.Width / 2;
            }
            else if (resizer.ResizerType == ResizerType.RightCenter)
            {
                resizer.Top = top + ((height / 2) - (resizer.Height / 2));
                resizer.Left = left + width - resizer.Width / 2;
            }
            else if (resizer.ResizerType == ResizerType.TopLeft)
            {
                resizer.Top = top - resizer.Height / 2;
                resizer.Left = left - resizer.Width / 2;
            }
            else if (resizer.ResizerType == ResizerType.TopRight)
            {
                resizer.Top = top - resizer.Height / 2;
                resizer.Left = left + width - resizer.Width / 2;
            }
            else if (resizer.ResizerType == ResizerType.BottomLeft)
            {
                resizer.Top = top + height - resizer.Height / 2;
                resizer.Left = left - resizer.Width / 2;
            }
            else if (resizer.ResizerType == ResizerType.BottomRight)
            {
                resizer.Top = top + height - resizer.Height / 2;
                resizer.Left = left + width - resizer.Width / 2;
            }
        }

        public List<ResizerData> InitializeResizers()
        {
            var resizerHeight = 8;
            var resizerWidth = 8;

            var resizerData = new List<ResizerData>
            {
                new() {
                    ResizerType = ResizerType.TopCenter,
                    Cursor = "n-resize",
                    Height = resizerHeight,
                    Width = resizerWidth,
                },
                new() {
                    ResizerType = ResizerType.BottomCenter,
                    Cursor = "s-resize",
                    Height = resizerHeight,
                    Width = resizerWidth,
                },
                new() {
                    ResizerType = ResizerType.LeftCenter,
                    Cursor = "e-resize",
                    Height = resizerHeight,
                    Width = resizerWidth,
                },
                new() {
                    ResizerType = ResizerType.RightCenter,
                    Cursor = "w-resize",
                    Height = resizerHeight,
                    Width = resizerWidth,
                },
                new() {
                    ResizerType = ResizerType.TopLeft,
                    Cursor = "nw-resize",
                    Height = resizerHeight,
                    Width = resizerWidth,
                },
                new() {
                    ResizerType = ResizerType.TopRight,
                    Cursor = "ne-resize",
                    Height = resizerHeight,
                    Width = resizerWidth,
                },
                new() {
                    ResizerType = ResizerType.BottomLeft,
                    Cursor = "sw-resize",
                    Height = resizerHeight,
                    Width = resizerWidth,
                },
                new() {
                    ResizerType = ResizerType.BottomRight,
                    Cursor = "se-resize",
                    Height = resizerHeight,
                    Width = resizerWidth,
                }
            };

            return resizerData;
        }

        public List<MaskData> PlaceMasks(double imgWidth, double imgHeight, double top, double left, double width, double height)
        {
            var maskDataData = new List<MaskData>
            {
                new() {
                    Top = 0,
                    Left = 0,
                    Width = imgWidth,
                    Height = top,
                    Class = "dnet-crop-box-mask-top"
                },
                new() {
                    Top = top + height,
                    Left = 0,
                    Width = imgWidth,
                    Height = imgHeight - (top + height),
                    Class = "dnet-crop-box-mask-bottom"
                },
                new() {
                    Top = top,
                    Left = 0,
                    Width = left,
                    Height = height,
                    Class = "dnet-crop-box-mask-left"
                },
                new() {
                    Top = top,
                    Left = left + width,
                    Width = imgWidth - (left + width),
                    Height = height,
                    Class = "dnet-crop-box-mask-right"
                }
            };

            return maskDataData;
        }
    }
}
