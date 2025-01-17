﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Autodesk.Revit.DB;
using 唐僧解瓦.BinLibrary.Helpers;

namespace 唐僧解瓦.BinLibrary.Extensions
{
    public static class CreationExtension
    {
        public static void NewLine(this Document doc, Line line)
        {
            var dir = line.Direction;
            var origin = line.Origin;
            var norm = default(XYZ);

            if (dir.IsParallel(XYZ.BasisX))
            {
                norm = dir.CrossProduct(XYZ.BasisY).Normalize();
                //MessageBox.Show("X");
            }
            else if (dir.IsParallel(XYZ.BasisY))
            {
                norm = dir.CrossProduct(XYZ.BasisX).Normalize();
                //MessageBox.Show("Y");
            }
            else if (dir.IsParallel(XYZ.BasisZ))
            {
                norm = dir.CrossProduct(XYZ.BasisX);
                //MessageBox.Show("Z");
            }
            else
            {
                norm = dir.CrossProduct(XYZ.BasisX);
            }

            var plan = Plane.CreateByNormalAndOrigin(norm, origin);

            doc.Invoke(m => {
                var sketchplane = SketchPlane.Create(doc, plan);
                doc.Create.NewModelCurve(line, sketchplane);
            },"aa");
        }
    }
}
