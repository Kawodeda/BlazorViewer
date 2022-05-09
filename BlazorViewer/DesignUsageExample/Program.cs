using Aurigma.Design;
using Aurigma.Design.Appearance;
using Aurigma.Design.Appearance.Color;
using Aurigma.Design.Content;
using Aurigma.Design.Content.Controls;
using Aurigma.Design.Math;
using Google.Protobuf;

namespace DesignUsageExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Brush redBrush = new Brush()
            {
                Solid = new SolidBrush()
                {
                    Color = new Color()
                    {
                        Process = new ProcessColor()
                        {
                            Alpha = 255,
                            Rgb = new RgbColor()
                            {
                                R = 255,
                                G = 0,
                                B = 0
                            }
                        }
                    }
                }
            };

            Brush blueBrush = new Brush()
            {
                Solid = new SolidBrush()
                {
                    Color = new Color()
                    {
                        Process = new ProcessColor()
                        {
                            Alpha = 255,
                            Rgb = new RgbColor()
                            {
                                R = 0,
                                G = 0,
                                B = 255
                            }
                        }
                    }
                }
            };

            Brush blackBrush = new Brush()
            {
                Solid = new SolidBrush()
                {
                    Color = new Color()
                    {
                        Process = new ProcessColor()
                        {
                            Alpha = 255,
                            Rgb = new RgbColor()
                            {
                                R = 0,
                                G = 0,
                                B = 0
                            }
                        }
                    }
                }
            };

            List<double> dashes = new List<double>()
            {
                0.0,
                1.0,
                1.1
            };

            Pen blackPen = new Pen()
            {
                Color = new Color()
                {
                    Process = new ProcessColor()
                    {
                        Alpha = 255,
                        Rgb = new RgbColor()
                        {
                            R = 0,
                            G = 0,
                            B = 0
                        }
                    }
                },
                DashOffset = 0.1f,
                LineCap = LineCap.Round,
                LineJoin = LineJoin.Round,
                MiterLimit = 2f,
                Width = 3f               
            };
            blackPen.Dashes.AddRange(dashes);

            List<Artboard> artboards = new List<Artboard>()
            {
                new Artboard()
                {
                    Background = blueBrush,
                    Name = "artboard1",
                    Size = new Size()
                    {
                       Width = 100,
                       Height = 150
                    },
                    Basis = Affine2DMatrix.CreateScale(2),
                    TrimSettings = new TrimSettings()
                    {
                       Bleed = new Sides()
                       {
                           Left = 15,
                           Top = 15,
                           Right = 15,
                           Bottom = 15
                       },
                       Slug = new Sides()
                       {
                           Left = 5,
                           Top = 5,
                           Right = 5,
                           Bottom = 5
                       }
                    }
                }
            };

            List<Element> elements = new List<Element>()
            {
                new Element()
                {
                    Content = new ElementContent()
                    {
                        ClosedVector = new ClosedVector()
                        {
                            Controls = new ClosedVectorControls()
                            {
                                Rectangle = new RectangleControls()
                                {
                                    Corner1 = new Point(-10, -10),
                                    Corner2 = new Point(10, 10)
                                }
                            },
                            Fill = redBrush,
                            Stroke = blackPen,
                        }
                    },
                    Position = new Point(15, 13),
                    ReferencePoint = ReferencePointType.TopLeftCorner,
                    Transform = Affine2DMatrix.CreateRotate(MathF.PI / 6)
                },
                new Element()
                {
                    Content = new ElementContent()
                    {
                        ClosedVector = new ClosedVector()
                        {
                            Controls = new ClosedVectorControls()
                            {
                                Rectangle = new RectangleControls()
                                {
                                    Corner1 = new Point(0, -10),
                                    Corner2 = new Point(30, 15)
                                }
                            },
                            Fill = blackBrush,
                            Stroke = blackPen,
                        }
                    },
                    Position = new Point(-10, 11),
                    ReferencePoint = ReferencePointType.TopLeftCorner,
                    Transform = Affine2DMatrix.CreateScale(2).Rotate(-MathF.PI / 3)
                }
            };

            Layer layer = new Layer()
            {
                Name = "layer1"
            };
            layer.Elements.AddRange(elements);

            List<Layer> layers = new List<Layer>
            {
                layer
            };

            Surface surface = new Surface()
            {
                Name = "front",
            };
            surface.Artboards.AddRange(artboards);
            surface.Layers.AddRange(layers);

            List<Surface> surfaces = new List<Surface>()
            {
                surface
            };

            Design design = new Design();
            design.Surfaces.AddRange(surfaces);

            string filename = "data/design.dat";

            SaveTo(design, filename);

            Design? retrievedDesign = ReadFrom(filename, Design.Parser) as Design;

            Console.WriteLine(retrievedDesign?.ToString());
        }

        private static void SaveTo(IMessage message, string path)
        {
            using (FileStream output = File.Create(path))
            {
                message.WriteTo(output);
            }
        }

        private static IMessage ReadFrom(string path, MessageParser parser)
        {
            using (FileStream input = File.OpenRead(path))
            {
                return parser.ParseFrom(input);
            }
        }
    }
}
