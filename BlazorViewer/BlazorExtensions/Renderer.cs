using BlazorExtensions.Factories;
using Aurigma.Design;
using Blazor.Extensions.Canvas.Canvas2D;

namespace BlazorExtensions
{
    public class Renderer
    {
        Canvas2DContext context;
        Design design;
        int surfaceIndex;

        public Renderer(Canvas2DContext context, Design design, int surfaceIndex)
        {
            Console.WriteLine("Renderer");
            this.context = context;
            this.design = design;
            this.surfaceIndex = surfaceIndex;
        }

        public async Task Render()
        {
            Console.WriteLine("Render");
            foreach(Layer layer in design.Surfaces[surfaceIndex].Layers)
            {
                Console.WriteLine("Layer");
                Console.WriteLine(layer.Elements.Count);
                foreach(Element element in layer.Elements)
                {
                    Console.WriteLine("Element");
                    ModelFactory.Build(element).Draw(context);
                }
            }
        }
    }
}
