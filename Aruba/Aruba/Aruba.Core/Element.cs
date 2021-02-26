using static Aruba.Core.ElementTypes;

namespace Aruba.Core
{
    public class Element
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AtomicNumber { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public ElementType Type { get; set; }
        public StoreUser User { get; set; }
    }
}