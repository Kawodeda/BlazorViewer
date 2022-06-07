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
                    await ModelFactory.Build(element).Draw(context);
                }
            }
        }
        public async Task RenderSelection(Element element)
        {
            Console.WriteLine("Render");

            var x = element.Position.X + element.Content.ClosedVector.Controls.Rectangle.Corner1.X;
            var y = element.Position.Y + element.Content.ClosedVector.Controls.Rectangle.Corner1.Y;
            var width = element.Content.ClosedVector.Controls.Rectangle.Corner2.X - element.Content.ClosedVector.Controls.Rectangle.Corner1.X;
            var height = element.Content.ClosedVector.Controls.Rectangle.Corner2.Y - element.Content.ClosedVector.Controls.Rectangle.Corner1.Y;

            var r = element.Content.ClosedVector.Fill.Solid.Color.Process.Rgb.R;
            var g = element.Content.ClosedVector.Fill.Solid.Color.Process.Rgb.G;
            var b = element.Content.ClosedVector.Fill.Solid.Color.Process.Rgb.B;

            await context.SetFillStyleAsync($"rgb({r},{g},{b})");
            await context.FillRectAsync(x, y, width, height);

            await context.SetStrokeStyleAsync("yellow");
            await context.StrokeRectAsync(x,y,width,height);  
        }
    }
}
