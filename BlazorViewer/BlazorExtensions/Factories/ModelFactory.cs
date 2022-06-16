using BlazorExtensions.Strategies;
using Aurigma.Design;
using Aurigma.Design.Content;

namespace BlazorExtensions.Factories
{
    public class ModelFactory
    {
        public static IElementDrawStrategy Build(Element element)
        {
            Console.WriteLine("Build");
            switch (element.Content.ElementContentCase)
            {
                case ElementContent.ElementContentOneofCase.ClosedVector:
                    {
                        switch (element.Content.ClosedVector.Controls.ControlsCase)
                        {
                            case Aurigma.Design.Content.Controls.ClosedVectorControls.ControlsOneofCase.Rectangle:
                                Console.WriteLine("Стратегия прямоугольника");
                                return new RectangleDrawStrategy(element);
                                break;
                            default:
                                return null; 
                        }
                    }
                    break;

                default:
                    return null;
            }
        }
    }

}
