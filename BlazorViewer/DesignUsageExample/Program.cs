using DesignModel;
using DesignModel.AppearanceTypes;
using DesignModel.ContentTypes;
using DesignModel.ContentTypes.Controls;
using DesignModel.MathTypes;
using Google.Protobuf;

Design design = new Design();
design.Surfaces.AddRange(new List<Surface>()
    {
    new Surface("front", new List<Artboard>()
    {
        new Artboard()
        {
            Name = "artboard1front",
            Background = new Fill(),
            Basis = new Affine2DMatrix(3, 3, new List<float>() { 1f, 1f, 0f, 1f, 1f, 1f, 0f, 0f, 1f}),
            Size = new Size()
            {
                Width = 100f,
                Height = 120f
            },
            TrimSettings = new TrimSettings()
            {
                Bleed = new Sides(4f),
                Slug = new Sides(1f, 0f, 2f, 1.5f)
            }
        }
    }, new List<Layer>()
    {
        new Layer("layer1front", new List<Element>()
        {
            new Element()
            {
                Position = new Point(24f, 15f),
                Transform = new Affine2DMatrix(3, 3, new List<float>() { 0.5f, 1f, 14f, 0.14f, 0.5f, 5.8f, 0f, 0f, 1f}),
                ReferencePoint = ReferencePointType.TopLeftCorner,
                Content = new ElementContent()
                {
                    ClosedVector = new ClosedVector()
                    {
                        Fill = new Fill(),
                        Stroke = new Stroke(),
                        ClosedVectorControls = new ClosedVectorControls()
                        {
                            RectangleControls = new RectangleControls()
                            {
                                Corner1 = new Point(0f, 0f),
                                Corner2 = new Point(32f, 24f)
                            }
                        }
                    }
                }
            },
            new Element()
            {
                Position = new Point(1f, 3.6f),
                Transform = new Affine2DMatrix(3, 3, new List<float>() { 0.5f, 1f, 10f, 0.32f, 0.6f, 6.4f, 0f, 0f, 1f}),
                ReferencePoint = ReferencePointType.Center,
                Content = new ElementContent()
                {
                    OpenedVector = new OpenedVector()
                    {
                        Stroke = new Stroke(),
                        Controls = new OpenedVectorControls()
                        {
                            LineControls = new LineControls()
                            {
                                Start = new Point(-10f, -5.8f),
                                End = new Point(20f, 16f)
                            }
                        }
                    }
                }
            }
        })
    }),
    new Surface("back", new List<Artboard>()
    {
        new Artboard()
        {
            Name = "artboard1back",
            Background = new Fill(),
            Basis = new Affine2DMatrix(3, 3, new List<float>() { 1f, 1f, 0f, 1f, 1f, 1f, 0f, 0f, 1f}),
            Size = new Size()
            {
                Width = 80f,
                Height = 80f
            },
            TrimSettings = new TrimSettings()
            {
                Bleed = new Sides(10f, 10f, 5f, 5f),
                Slug = new Sides(10f)
            }
        }
    }, new List<Layer>()
    {
        new Layer("layer1back", new List<Element>()
        {
            new Element()
            {
                Position = new Point(40f, 40f),
                Transform = new Affine2DMatrix(3, 3, new List<float>() { 1f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 1f}),
                ReferencePoint = ReferencePointType.Center,
                Content = new ElementContent()
                {
                    OpenedVector = new OpenedVector()
                    {
                        Stroke = new Stroke(),
                        Controls = new OpenedVectorControls()
                        {
                            PathControls = new PathControls(new List<Point>
                            {
                                new Point(-20f, -25f),
                                new Point(30f, -20f),
                                new Point(34f, 1f),
                                new Point(-13f, -10f),
                                new Point(0f, 0f)
                            })
                        }
                    }
                }
            }
        })
    })
});

string filename = "design.dat";
using (FileStream output = File.Create(filename))
{
    design.WriteTo(output);
    Console.WriteLine($"Design was successfully saved to {filename}");
}

using (FileStream input = File.OpenRead(filename))
{
    Design retrievedDesign = Design.Parser.ParseFrom(input);
    Console.WriteLine($"Design:\n{retrievedDesign.ToString()}");
}
