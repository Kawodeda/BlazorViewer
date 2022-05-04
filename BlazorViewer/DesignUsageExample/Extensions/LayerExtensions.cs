
namespace DesignModel
{
    public sealed partial class Layer
    {
        public Layer(string name, IEnumerable<Element> elements)
        {
            name_ = name;
            elements_.AddRange(elements);
        }
    }
}
