using System;
namespace Aruba.Core
{
    public class ElementOccurrence
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; } 
        public Element Element { get; set; }
    }
}
