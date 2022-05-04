using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel
{
    public sealed partial class Surface
    {
        public Surface(string name, IEnumerable<Artboard> artboards, IEnumerable<Layer> layers)
        {
            name_ = name;
            artboards_.AddRange(artboards);
            layers_.AddRange(layers);
        }
    }
}
