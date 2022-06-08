using Aurigma.Design;
using Aurigma.Design.Content.Controls;
using Aurigma.Design.Math;
using BlazorExtensions.Commands;
using BlazorExtensions.Commands.Parameters;
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
        private float _prevMouseX;
        private float _prevMouseY;

        public DesignInputHandler(IDesignViewer designViewer)
        {
            _designViewer = designViewer;
            _state = DesignState.Default;
        }

        public override ICommand OnClick(MouseEventArgs e)
        {
            if (e.Button == 0)
            {
                float mouseX = (float)e.OffsetX;
                float mouseY = (float)e.OffsetY;

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

        public override ICommand OnMouseDown(MouseEventArgs e)
        {           
            if (_designViewer.SelectedElement == null)
            {
                return base.OnMouseDown(e);
            }

            float mouseX = (float)e.OffsetX;
            float mouseY = (float)e.OffsetY;
            if (IsWithinElement(_designViewer.SelectedElement, mouseX, mouseY)
                == false)
            {
                return base.OnMouseDown(e);
            }

            _state = DesignState.Translate;
            _prevMouseX = mouseX;
            _prevMouseY = mouseY;

            return new EmptyCommand();
        }

        public override ICommand OnMouseMove(MouseEventArgs e)
        {
            switch (_state)
            {
                case DesignState.Translate:
                    if(_designViewer.SelectedElement == null)
                    {
                        return base.OnMouseMove(e);
                    }

                    float mouseX = (float)e.OffsetX;
                    float mouseY = (float)e.OffsetY;
                    var shift = new Point(
                        (mouseX - _prevMouseX) / _designViewer.Transform.M11, 
                        (mouseY - _prevMouseY) / _designViewer.Transform.M22);

                    _prevMouseX = mouseX;
                    _prevMouseY = mouseY;

                    return new TranslateElementCommand(
                        new TranslateElementCommandParams(
                            _designViewer.SelectedElement,
                            shift));

                default:
                    return base.OnMouseMove(e);
            }
        }

        public override ICommand OnMouseUp(MouseEventArgs e)
        {
            _state = DesignState.Default;

            return base.OnMouseUp(e);
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
