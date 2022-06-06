﻿using BlazorExtensions.Commands.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExtensions.Commands
{
    public class ZoomCommand : ICommand
    {
        private readonly ZoomCommandParams _params;

        public ZoomCommand(ZoomCommandParams @params)
        {
            _params = @params;
        }

        public bool CanExecute()
        {
            return true;
        }

        public void Execute()
        {
            _params.Zoomable.Zoom += _params.DeltaZoom;
        }
    }
}
