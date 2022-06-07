using BlazorExtensions.Viewports;

namespace BlazorExtensions.Commands.Context
{
    public class ExecutionContext : IExecutionContext
    {
        public IViewport Viewport { get; set; }

        public ExecutionContext(IViewport viewport)
        {
            Viewport = viewport;
        }
    }
}
