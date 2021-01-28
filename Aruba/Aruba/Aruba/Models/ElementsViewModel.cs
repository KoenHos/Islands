using System;
using System.Collections.Generic;
using Aruba.Core;

namespace Aruba.Models
{
    public class ElementsViewModel
    {
        public IEnumerable<ElementType> ElementTypes { get; set; }
        public IEnumerable<Element> Elements { get; set; }
    }
}
