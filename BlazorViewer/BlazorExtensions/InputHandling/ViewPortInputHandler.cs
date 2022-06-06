using BlazorExtensions.Commands;
using BlazorExtensions.Commands.Parameters;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorExtensions.InputHandling
{
    public enum ViewPortState
    {
        Default = 0,
        ScrollX = 1,
        ScrollY = 2
    }

    public class ViewPortInputHandler : InputHandlerBase
    {
        private IViewPort _viewPort;
        private ViewPortState _state;
        private float _prevMouseX;
        private float _prevMouseY;

        public ViewPortInputHandler(IViewPort viewPort)
        {
            _viewPort = viewPort;
            _state = ViewPortState.Default;
        }

        public override ICommand OnMouseDown(MouseEventArgs e)
        {
            ICommand result = new EmptyCommandResult();
            float mouseX = (float)e.OffsetX;
            float mouseY = (float)e.OffsetY;

            // To Do: implement individual handlers to handle scrollbars
            ICommand? horResult = HandleHorizontalScrollbarMouseDown(e);
            if (horResult != null)
            {
                return horResult;
            }

            ICommand? vertResult = HandleVerticalScrollbarMouseDown(e);
            if (vertResult != null)
            {
                return vertResult;
            }

            ICommand? nextResult = Next?.OnMouseDown(e);
            if (nextResult != null)
            {
                result = nextResult;
            }

            return result;
        }

        public override ICommand OnMouseMove(MouseEventArgs e)
        {
            ICommand result = new EmptyCommandResult();

            switch (_state)
            {
                case ViewPortState.ScrollX:
                    float dx = (float)(e.OffsetX - _prevMouseX);
                    result = new ScrollbarDragCommand(
                        new ScrollbarDragCommandParams(_viewPort, dx, 0f));
                    break;

                case ViewPortState.ScrollY:
                    float dy = (float)(e.OffsetY - _prevMouseY);
                    result = new ScrollbarDragCommand(
                        new ScrollbarDragCommandParams(_viewPort, 0f, dy));
                    break;

                default:
                    ICommand? nextResult = Next?.OnMouseDown(e);
                    if (nextResult != null)
                    {
                        result = nextResult;
                    }
                    break;
            }

            _prevMouseX = (float)e.OffsetX;
            _prevMouseY = (float)e.OffsetY;

            return result;
        }

        public override ICommand OnMouseOut(MouseEventArgs e)
        {
            _state = ViewPortState.Default;

            return HandleByDefault(() => Next?.OnMouseOut(e));
        }

        public override ICommand OnMouseUp(MouseEventArgs e)
        {
            _state = ViewPortState.Default;

            return HandleByDefault(() => Next?.OnMouseUp(e));
        }

        public override ICommand OnWheel(WheelEventArgs e)
        {
            const float zoomFactor = -0.0008f;
            const float scrollFactor = 0.08f;

            if (e.ShiftKey)
            {
                float deltaZoom = (float)e.DeltaY * zoomFactor;
                return new ZoomCommand(
                    new ZoomCommandParams(_viewPort, deltaZoom));
            }

            float yShift = (float)e.DeltaY * scrollFactor;
            return new ScrollbarDragCommand(
                new ScrollbarDragCommandParams(_viewPort, 0f, yShift));
        }

        private ICommand? HandleHorizontalScrollbarMouseDown(MouseEventArgs e)
        {
            ICommand? result = null;
            float mouseX = (float)e.OffsetX;
            float mouseY = (float)e.OffsetY;

            if (e.Button == 0)
            {
                if (_viewPort.IsHorizontalScrollbarShown
                    && IsWithinHorizontalScrollbar(mouseX, mouseY))
                {
                    _state = ViewPortState.ScrollX;
                    _prevMouseX = mouseX;

                    if (IsWithinHorizontalScrollbarBody(mouseX, mouseY) == false)
                    {
                        float xShift = mouseX - _viewPort.HorizontalScrollbarBodyPos;
                        var @params
                            = new ScrollbarDragCommandParams(_viewPort, xShift, 0f);

                        result = new ScrollbarDragCommand(@params);
                        return result;
                    }
                }
            }

            return result;
        }

        private ICommand? HandleVerticalScrollbarMouseDown(MouseEventArgs e)
        {
            ICommand? result = null;
            float mouseX = (float)e.OffsetX;
            float mouseY = (float)e.OffsetY;

            if (e.Button == 0)
            {
                if (_viewPort.IsVerticalScrollbarShown
                    && IsWithinVerticalScrollbar(mouseX, mouseY))
                {
                    _state = ViewPortState.ScrollY;
                    _prevMouseY = mouseY;

                    if (IsWithinVerticalScrollbarBody(mouseX, mouseY) == false)
                    {
                        float yShift = mouseY - _viewPort.VerticalScrollbarBodyPos;
                        var @params
                            = new ScrollbarDragCommandParams(_viewPort, 0f, yShift);

                        result = new ScrollbarDragCommand(@params);
                        return result;
                    }
                }
            }

            return result;
        }

        private bool IsWithinHorizontalScrollbar(float x, float y)
        {
            return x >= 0
                && x <= _viewPort.ViewPortWidth - _viewPort.ScrollbarSize
                && y > _viewPort.ViewPortHeight - _viewPort.ScrollbarSize
                && y < _viewPort.ViewPortHeight;
        }

        private bool IsWithinVerticalScrollbar(float x, float y)
        {
            return x >= _viewPort.ViewPortWidth - _viewPort.ScrollbarSize
                && x <= _viewPort.ViewPortWidth
                && y > 0
                && y < _viewPort.ViewPortHeight - _viewPort.ScrollbarSize;
        }

        private bool IsWithinHorizontalScrollbarBody(float x, float y)
        {
            return x >= _viewPort.HorizontalScrollbarBodyPos
                && x <= _viewPort.HorizontalScrollbarBodyPos + _viewPort.HorizontalScrollbarBodyWidth
                && y > _viewPort.ViewPortHeight - _viewPort.ScrollbarSize
                && y < _viewPort.ViewPortHeight;
        }

        private bool IsWithinVerticalScrollbarBody(float x, float y)
        {
            return x >= _viewPort.ViewPortWidth - _viewPort.ScrollbarSize
                && x <= _viewPort.ViewPortWidth
                && y > _viewPort.VerticalScrollbarBodyPos
                && y < _viewPort.VerticalScrollbarBodyPos + _viewPort.VerticalScrollbarBodyHeight;
        }
    }
}
