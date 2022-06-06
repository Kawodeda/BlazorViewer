﻿using Blazor.Extensions.Canvas.Canvas2D;
using Aurigma.Design;

namespace BlazorExtensions.Strategies
{
    internal class RectangleDrawStrategy : ElementDrawStrategy
    {
        public RectangleDrawStrategy(Element element) : base(element)
        {
        }

        public override async Task Draw(Canvas2DContext context)
        {
            var x = element.Content.ClosedVector.Controls.Rectangle.Corner1.X;
            var y = element.Content.ClosedVector.Controls.Rectangle.Corner1.Y;
            var width = element.Content.ClosedVector.Controls.Rectangle.Corner2.X - element.Content.ClosedVector.Controls.Rectangle.Corner1.X;
            var height = element.Content.ClosedVector.Controls.Rectangle.Corner2.Y - element.Content.ClosedVector.Controls.Rectangle.Corner1.Y;
            var r = element.Content.ClosedVector.Fill.Solid.Color.Process.Rgb.R;
            var g = element.Content.ClosedVector.Fill.Solid.Color.Process.Rgb.G;
            var b = element.Content.ClosedVector.Fill.Solid.Color.Process.Rgb.B;
            var a = element.Content.ClosedVector.Fill.Solid.Color.Process.Alpha;

            Console.WriteLine($"{x} {y} {r} {g} {b}");
            Console.WriteLine($"rgba({r},{g},{b},1.0)");
            await context.SetFillStyleAsync($"rgb({r},{g},{b})");
            await context.FillRectAsync(x, y, width, height);
            //await context.SetFillStyleAsync("red");
            //await context.FillRectAsync(10, 10, 200, 100);
            Console.WriteLine("Отрисовано");
        }
    }
}
