using BlazorExtensions.Commands;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorExtensions.InputHandling
{
    public class DesignViewerInputHandler : InputHandlerBase, IInputHandlingBuilder
    {
        private IViewer _viewer;

        public DesignViewerInputHandler(IViewer viewer)
        {
            _viewer = viewer;
        }

        public void UseHandler<T>() where T : InputHandlerBase
        {
            Next = (T?)Activator.CreateInstance(typeof(T), new object[] { _viewer});
        }
    }
}
