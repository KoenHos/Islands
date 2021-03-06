﻿using System;
using System.Collections.Generic;
using Aruba.Core;

namespace Aruba.Data
{
    public interface IElementDataService
    {
            IEnumerable<Element> GetByName(string name, bool heavierThanOxygen);
            IEnumerable<Element> GetByUserAndName(string username, string name);
            Element GetById(int id);
            Element Update(Element element);
            Element Add(Element element);
            Element Delete(int id);
            void Truncate();
            int GetCountOfIElements();
            bool Commit();

        IEnumerable<ElementOccurrence> GetOccurrenceByElementId(int id);
        ElementOccurrence Add(ElementOccurrence elementOccurrence);
    }
}
