using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExtensions.InputHandling
{
    public enum DesignState
    {
        Default = 0,
        Translate = 1
    }

    public class DesignInputHandler : InputHandlerBase
    {
        private IViewer _viewer;
        private DesignState _state;

        public DesignInputHandler(IViewer viewer)
        {
            _viewer = viewer;
            _state = DesignState.Default;
        }
    }
}
