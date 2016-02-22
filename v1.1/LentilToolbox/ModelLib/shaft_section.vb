
'The MIT License (MIT)
'Copyright(c) 2016 Lentil Sun

'Permission Is hereby granted, free Of charge, to any person obtaining a copy of this software And associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, And/Or sell copies of the Software, And to permit persons to whom the Software Is furnished to do so, subject to the following conditions:

'The above copyright notice And this permission notice shall be included In all copies Or substantial portions Of the Software.

'THE SOFTWARE Is PROVIDED "AS IS", WITHOUT WARRANTY Of ANY KIND, EXPRESS Or IMPLIED, INCLUDING BUT Not LIMITED To THE WARRANTIES Of MERCHANTABILITY, FITNESS For A PARTICULAR PURPOSE And NONINFRINGEMENT. In NO Event SHALL THE AUTHORS Or COPYRIGHT HOLDERS BE LIABLE For ANY CLAIM, DAMAGES Or OTHER LIABILITY, WHETHER In AN ACTION Of CONTRACT, TORT Or OTHERWISE, ARISING FROM, OUT Of Or In CONNECTION With THE SOFTWARE Or THE USE Or OTHER DEALINGS In THE SOFTWARE.


Imports INFITF
Imports MECMOD
Imports HybridShapeTypeLib
Imports PARTITF

Public Class shaftsection
    Function shaft_sectionModel(H As Double, B As Double, d As Double, oPartDoc As PartDocument) As Boolean

        Dim partdoc1 = oPartDoc
        Dim part1 = partdoc1.Part
        Dim body1 = part1.MainBody


        Dim reference1 As Reference
        reference1 = part1.OriginElements.PlaneZX

        Dim hybridShapeFactory1 As HybridShapeFactory
        hybridShapeFactory1 = part1.HybridShapeFactory
        Dim hybridShapePlaneOffset1 As HybridShapePlaneOffset
        hybridShapePlaneOffset1 = hybridShapeFactory1.AddNewPlaneOffset(reference1, H, False)
        body1.InsertHybridShape(hybridShapePlaneOffset1)

        Dim sketches1 As Sketches
        sketches1 = body1.Sketches
        Dim sketch1 = sketches1.Add(hybridShapePlaneOffset1)
        Dim arrayOfVariantOfDouble1(8)
        arrayOfVariantOfDouble1(0) = 0#
        arrayOfVariantOfDouble1(1) = 20.0#
        arrayOfVariantOfDouble1(2) = 0#
        arrayOfVariantOfDouble1(3) = -1.0#
        arrayOfVariantOfDouble1(4) = 0#
        arrayOfVariantOfDouble1(5) = 0#
        arrayOfVariantOfDouble1(6) = 0#
        arrayOfVariantOfDouble1(7) = -0#
        arrayOfVariantOfDouble1(8) = 1.0#
        Dim sketch1Variant = sketch1
        sketch1Variant.SetAbsoluteAxisData(arrayOfVariantOfDouble1)

        part1.InWorkObject = sketch1

        Dim factory2D1 As Factory2D
        factory2D1 = sketch1.OpenEdition()
        Dim point2D1 As Point2D
        point2D1 = sketch1.AbsoluteAxis.GetItem("Origin")
        Dim circle2D1 As Circle2D
        circle2D1 = factory2D1.CreateClosedCircle(0#, 0#, 61.5)
        Dim constraints1 As Constraints
        constraints1 = sketch1.Constraints

        Dim constraint1 As Constraint
        constraint1 = constraints1.AddMonoEltCst(CatConstraintType.catCstTypeRadius, circle2D1)
        constraint1.Dimension.Value = d / 2

        circle2D1.CenterPoint = factory2D1.CreatePoint(0#, 0#)
        Dim constraint2 As Constraint
        constraint2 = constraints1.AddBiEltCst(CatConstraintType.catCstTypeDistance, circle2D1.CenterPoint, point2D1)
        constraint2.Dimension.Value = 0#
        sketch1.CloseEdition()

        Dim ShapeFactory1 As ShapeFactory
        ShapeFactory1 = part1.ShapeFactory
        Dim pad1 As Pad
        pad1 = ShapeFactory1.AddNewPad(sketch1, B)


        part1.Update()

        shaft_sectionModel = True
    End Function

End Class
