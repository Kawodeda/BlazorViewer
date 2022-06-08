using Aurigma.Design;
using Aurigma.Design.Content.Controls;
using Aurigma.Design.Math;
using BlazorExtensions.Commands;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorExtensions.InputHandling
{
    public enum DesignState
    {
        Default = 0,
        Translate = 1
    }

    public class DesignInputHandler : InputHandlerBase
    {
        private IDesignViewer _designViewer;
        private DesignState _state;

        public DesignInputHandler(IDesignViewer designViewer)
        {
            _designViewer = designViewer;
            _state = DesignState.Default;
        }

        public override ICommand OnClick(MouseEventArgs e)
        {
            float mouseX = (float)e.OffsetX;
            float mouseY = (float)e.OffsetY;

            if (e.Button == 0)
            {
                Element? element = _designViewer.CurrentSurface.Layers
                    .SelectMany(x => x.Elements)
                    .FirstOrDefault(x => IsWithinElement(x, mouseX, mouseY));

                if (element != _designViewer.SelectedElement)
                {
                    return new ChangeSelectionCommand(element);
                }
            }

            return base.OnClick(e);
        }

        public override ICommand OnKeyDown(KeyboardEventArgs e)
        {
            if (e.Code == "Delete")
            {
                if (_designViewer.SelectedElement != null)
                {
                    return new CompositeCommand(
                        new DeleteElementCommand(_designViewer.SelectedElement),
                        new ChangeSelectionCommand(null));
                }
            }

            return base.OnKeyDown(e);
        }

        private bool IsWithinElement(Element element, float x, float y)
        {
            RectangleControls rectangle 
                = element.Content.ClosedVector.Controls.Rectangle;
            Affine2DMatrix transform = _designViewer.Transform;
            Point elementPos = element.Position;
            Point corner1 = (elementPos + rectangle.Corner1) * transform;
            Point corner2 = (elementPos + rectangle.Corner2) * transform;

            return x > corner1.X
                && x < corner2.X
                && y > corner1.Y
                && y < corner2.Y;
        }
    }
}
