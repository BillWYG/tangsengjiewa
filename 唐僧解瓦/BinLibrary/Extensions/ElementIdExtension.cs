﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace 唐僧解瓦.BinLibrary.Extensions
{
    public static class ElementIdExtension
    {
        public static Element GetElement(this ElementId eleid,Document doc)
        {
            return doc.GetElement(eleid);
        }
    }
}
