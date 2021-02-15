using System;
using Aruba.Core;

namespace Aruba.Models
{
    public class ElementOccurrenceViewModel
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Location { get; set; }
            public string Description { get; set; }
            public Element Element { get; set; }
    }
}
