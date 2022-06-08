using BlazorExtensions.Viewports;

namespace BlazorExtensions.Commands.Context
{
    public interface IExecutionContext
    {
        public IViewport Viewport { get; }
    }
}
