using BlazorExtensions.Factories;
using Aurigma.Design;
using Aurigma.Design.Math;
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
            this.context = context;
            this.design = design;
            this.surfaceIndex = surfaceIndex;
        }

        public async Task Render(Affine2DMatrix basis)
        {
            foreach(Layer layer in design.Surfaces[surfaceIndex].Layers)
            {
                Console.WriteLine("Layer");
                Console.WriteLine(layer.Elements.Count);
                foreach(Element element in layer.Elements)
                {
                    Affine2DMatrix transform = basis.Append(element.Transform); //умножение матриц(basis - слева, transform - справа)
                    await context.SetTransformAsync(
                        transform.M11,
                        transform.M12,
                        transform.M21,
                        transform.M22,
                        transform.D1,
                        transform.D2);

                    Console.WriteLine("Element");
                    await ModelFactory.Build(element).Draw(context);
                }
            }
            await context.SetTransformAsync(
                        basis.M11,
                        basis.M12,
                        basis.M21,
                        basis.M22,
                        basis.D1,
                        basis.D2);
        }
        public async Task RenderSelection(Element element, Affine2DMatrix basis)
        {
            Affine2DMatrix transform = basis.Append(element.Transform); //умножение матриц(basis - слева, transform - справа)
            await context.SetTransformAsync(
                transform.M11,
                transform.M12,
                transform.M21,
                transform.M22,
                transform.D1,
                transform.D2);

            var x = element.Position.X + element.Content.ClosedVector.Controls.Rectangle.Corner1.X;
            var y = element.Position.Y + element.Content.ClosedVector.Controls.Rectangle.Corner1.Y;
            var width = element.Content.ClosedVector.Controls.Rectangle.Corner2.X - element.Content.ClosedVector.Controls.Rectangle.Corner1.X;
            var height = element.Content.ClosedVector.Controls.Rectangle.Corner2.Y - element.Content.ClosedVector.Controls.Rectangle.Corner1.Y;

            var r = element.Content.ClosedVector.Fill.Solid.Color.Process.Rgb.R;
            var g = element.Content.ClosedVector.Fill.Solid.Color.Process.Rgb.G;
            var b = element.Content.ClosedVector.Fill.Solid.Color.Process.Rgb.B;

            var lineWidth = 1;

            await context.SetFillStyleAsync($"rgb({r},{g},{b})");
            await context.FillRectAsync(x, y, width, height);

            await context.SetStrokeStyleAsync("yellow");
            await context.SetLineWidthAsync(lineWidth);
            await context.StrokeRectAsync(x,y,width,height);

            await context.SetTransformAsync(
                        basis.M11,
                        basis.M12,
                        basis.M21,
                        basis.M22,
                        basis.D1,
                        basis.D2);
        }
    }
}
