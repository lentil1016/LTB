Imports MECMOD
Imports INFITF
Imports PARTITF
Imports KnowledgewareTypeLib
Imports HybridShapeTypeLib
Imports ProductStructureTypeLib
Imports System.Math



Public Class CylGear
    Public B As Double

    Public P_LuoJu As Double

    Public Flag_β As Integer

    Public R As Double
    Public Ra As Double
    Public Rf As Double
    Public Rb As Double
    Public T_arc As Double
    Public S As Double
    Public pf As Double

    Public Const PI = 3.14159265358979

    Sub Class_Initialize()
    End Sub

    Sub Class_Terminate()
    End Sub

    Function GearModel(m As Integer, z As Integer, α As Double, B As Double, β As Double, Flag_β As Integer) As Boolean
        α = α / 180 * PI
        β = β / 180 * PI
        If Flag_β = 0 Then
            R = m * z / 2                               '分度圆半径
            Rb = R * Cos(α)                            '基圆半径
            Rf = R - 1.25 * m                           '齿根圆半径
            Ra = R + m                                  '齿顶圆半径
            S = m * PI / 2                              '分度圆处齿槽宽厚
            pf = 0.38 * m                               '齿根圆角
        Else
            R = (m / Cos(β)) * z / 2                   '分度圆半径
            Rb = R * Cos(α)                            '基圆半径
            Rf = R - 1.25 * m                           '齿根圆半径
            Ra = R + m                                  '齿顶圆半径
            S = m * PI / 2                              '分度圆处齿槽宽厚
            pf = 0.35 * m                               '齿根圆角
            P_LuoJu = PI * Ra * 2 / Tan(β)             '齿顶圆上螺旋线螺距
        End If
        '--------------------------计算参数完毕---------------
        On Error Resume Next
        Dim CATIA As Application
        CATIA = GetObject(, "CATIA.Application")
        If Err.Number <> 0 Then
            CATIA = CreateObject("CATIA.Application")
            CATIA.Visible = True
        End If
        '-----------------------启动CATIA程序完毕-------------------
        Dim t_Value(14) As Double
        Dim t_point(14) As HybridShapePointCoord

        t_Value(0) = 0
        For k = 0 To 13
            t_Value(k + 1) = t_Value(k) + 0.05
        Next

        Dim docs As Documents
        docs = CATIA.Documents

        Dim partDoc As PartDocument
        partDoc = docs.Add("Part")

        Dim part1 As Part
        part1 = partDoc.Part

        Dim hybridBodies1 As HybridBodies
        hybridBodies1 = part1.HybridBodies

        Dim hybridBody1 As HybridBody
        hybridBody1 = hybridBodies1.Add()

        Dim hybridShapeFactory1 As HybridShapeFactory
        hybridShapeFactory1 = part1.HybridShapeFactory

        Dim hybridShapeSpline1 As HybridShapeSpline
        hybridShapeSpline1 = hybridShapeFactory1.AddNewSpline()

        Dim hybridShapePointCoord1 As HybridShapePointCoord
        hybridShapePointCoord1 = hybridShapeFactory1.AddNewPointCoord(0#, 0#, 0#)

        hybridBody1.AppendHybridShape(hybridShapePointCoord1)
        hybridShapePointCoord1.Name = "原点"

        Dim point_x As Double, point_y As Double

        For i = 0 To 14
            T_arc = Rb * t_Value(i)
            point_x = Rb * Sin(t_Value(i)) - T_arc * Cos(t_Value(i))
            point_y = Rb * Cos(t_Value(i)) + T_arc * Sin(t_Value(i))
            t_point(i) = hybridShapeFactory1.AddNewPointCoord(point_x, point_y, 0#)

            hybridBody1.AppendHybridShape(t_point(i))
            t_point(i).Name = "point_T" & i
        Next

        For i = 0 To 14
            hybridShapeSpline1.AddPointWithConstraintExplicit(t_point(i), Nothing, -1.0#, 1, Nothing, 0#)
        Next

        hybridBody1.AppendHybridShape(hybridShapeSpline1)

        part1.InWorkObject = hybridShapePointCoord1

        part1.Update()

        Dim reference1 As Reference
        reference1 = part1.CreateReferenceFromObject(hybridShapePointCoord1)

        Dim originElements1 As OriginElements
        originElements1 = part1.OriginElements

        Dim hybridShapePlaneExplicit1 As HybridShapePlaneExplicit
        hybridShapePlaneExplicit1 = originElements1.PlaneXY

        Dim reference2 As Reference
        reference2 = part1.CreateReferenceFromObject(hybridShapePlaneExplicit1)

        Dim hybridShapeCircleCtrRad1 = hybridShapeFactory1.AddNewCircleCtrRad(reference1, reference2, False, Rf)
        hybridShapeCircleCtrRad1.Name = "齿根圆_Rf"
        hybridShapeCircleCtrRad1.SetLimitation(1)
        hybridBody1.AppendHybridShape(hybridShapeCircleCtrRad1)

        Dim hybridShapeCircleCtrRad2 = hybridShapeFactory1.AddNewCircleCtrRad(reference1, reference2, False, Ra)
        hybridShapeCircleCtrRad2.Name = "齿顶圆_Ra"
        hybridShapeCircleCtrRad2.SetLimitation(1)
        hybridBody1.AppendHybridShape(hybridShapeCircleCtrRad2)

        Dim hybridShapeCircleCtrRad3 = hybridShapeFactory1.AddNewCircleCtrRad(reference1, reference2, False, R)
        hybridShapeCircleCtrRad3.Name = "分度圆_R"
        hybridShapeCircleCtrRad3.SetLimitation(1)
        hybridBody1.AppendHybridShape(hybridShapeCircleCtrRad3)

        Dim hybridShapeCircleCtrRad4 = hybridShapeFactory1.AddNewCircleCtrRad(reference1, reference2, False, Rb)
        hybridShapeCircleCtrRad4.Name = "基圆_Rb"
        hybridShapeCircleCtrRad4.SetLimitation(1)
        hybridBody1.AppendHybridShape(hybridShapeCircleCtrRad4)

        Dim hybridShapeIntersection1 = hybridShapeFactory1.AddNewIntersection(hybridShapeSpline1, hybridShapeCircleCtrRad3)
        hybridShapeIntersection1.PointType = 0
        hybridBody1.AppendHybridShape(hybridShapeIntersection1)

        Dim hybridShapePointOnCurve1 = hybridShapeFactory1.AddNewPointOnCurveWithReferenceFromDistance(hybridShapeCircleCtrRad3, hybridShapeIntersection1, S, False)
        hybridShapePointOnCurve1.DistanceType = 1
        hybridBody1.AppendHybridShape(hybridShapePointOnCurve1)

        Dim hybridShapeLinePtPt1 = hybridShapeFactory1.AddNewLinePtPt(hybridShapeIntersection1, hybridShapePointOnCurve1)
        hybridBody1.AppendHybridShape(hybridShapeLinePtPt1)
        hybridShapeLinePtPt1.Name = "齿厚弦长"

        Dim hybridShapePointOnCurve2 = hybridShapeFactory1.AddNewPointOnCurveFromPercent(hybridShapeLinePtPt1, 0.5, False)
        hybridBody1.AppendHybridShape(hybridShapePointOnCurve2)
        hybridShapePointOnCurve2.Name = "齿厚弦长的中点"

        Dim hybridShapeLinePtPt2 = hybridShapeFactory1.AddNewLinePtPt(hybridShapePointCoord1, hybridShapePointOnCurve2)
        hybridBody1.AppendHybridShape(hybridShapeLinePtPt2)
        hybridShapeLinePtPt2.Name = "齿厚对称线"

        Dim hybridShapeLineTangency1 = hybridShapeFactory1.AddNewLineTangencyOnSupport(hybridShapeSpline1, t_point(0), reference2, 0#, Abs(Rb - Rf) + 10, True)
        hybridBody1.AppendHybridShape(hybridShapeLineTangency1)
        hybridShapeLineTangency1.Name = "0点处切线"

        Dim hybridShapeCorner1 As HybridShapeCorner
        If Rb > Rf + pf Then

            hybridShapeCorner1 = hybridShapeFactory1.AddNewCorner(hybridShapeLineTangency1, hybridShapeCircleCtrRad1, Nothing, pf, -1, 1, False)
            hybridShapeCorner1.DiscriminationIndex = 1
            hybridShapeCorner1.BeginOfCorner = 1
            hybridShapeCorner1.FirstTangentOrientation = -1
            hybridShapeCorner1.SecondTangentOrientation = 1

        ElseIf Rb > Rf Then

            hybridShapeCorner1 = hybridShapeFactory1.AddNewCorner(hybridShapeSpline1, hybridShapeCircleCtrRad1, Nothing, pf, 1, -1, False)
            hybridShapeCorner1.DiscriminationIndex = 1
            hybridShapeCorner1.BeginOfCorner = 2
            hybridShapeCorner1.FirstTangentOrientation = 1
            hybridShapeCorner1.SecondTangentOrientation = -1

        Else

            hybridShapeCorner1 = hybridShapeFactory1.AddNewCorner(hybridShapeSpline1, hybridShapeCircleCtrRad1, Nothing, pf, -1, 1, False)
            hybridShapeCorner1.DiscriminationIndex = 1
            hybridShapeCorner1.BeginOfCorner = 1
            hybridShapeCorner1.FirstTangentOrientation = -1
            hybridShapeCorner1.SecondTangentOrientation = 1

        End If

        hybridBody1.AppendHybridShape(hybridShapeCorner1)
        hybridShapeCorner1.Name = "齿根圆角"

        Dim hybridShapeSymmetry1 = hybridShapeFactory1.AddNewSymmetry(hybridShapeSpline1, hybridShapeLinePtPt2)
        hybridShapeSymmetry1.VolumeResult = False
        hybridBody1.AppendHybridShape(hybridShapeSymmetry1)
        hybridShapeSymmetry1.Name = "样条线的对称线"

        Dim hybridShapeSymmetry2 = hybridShapeFactory1.AddNewSymmetry(hybridShapeCorner1, hybridShapeLinePtPt2)
        hybridShapeSymmetry2.VolumeResult = False
        hybridBody1.AppendHybridShape(hybridShapeSymmetry2)
        hybridShapeSymmetry2.Name = "齿根圆角镜像"

        Dim hybridShapeCircleCtrRad6 = hybridShapeFactory1.AddNewCircleCtrRadWithAngles(hybridShapePointCoord1, reference2, False, Rf, 0#, 180.0#)
        hybridShapeCircleCtrRad6.SetLimitation(0)
        hybridBody1.AppendHybridShape(hybridShapeCircleCtrRad6)
        hybridShapeCircleCtrRad6.Name = "齿根半圆"

        Dim hybridShapeSplit2 = hybridShapeFactory1.AddNewHybridSplit(hybridShapeCircleCtrRad6, hybridShapeCorner1, -1)
        hybridShapeFactory1.GSMVisibility(hybridShapeCircleCtrRad6, 0)
        hybridBody1.AppendHybridShape(hybridShapeSplit2)

        Dim hybridShapeSplit3 = hybridShapeFactory1.AddNewHybridSplit(hybridShapeSplit2, hybridShapeSymmetry2, 1)
        hybridShapeFactory1.GSMVisibility(hybridShapeSplit2, 0)
        hybridBody1.AppendHybridShape(hybridShapeSplit3)
        hybridShapeSplit3.Name = "齿根弧长"


        Dim hybridShapeCircleCtrRad7 = hybridShapeFactory1.AddNewCircleCtrRadWithAngles(hybridShapePointCoord1, reference2, False, Ra, 0#, 180.0#)
        hybridShapeCircleCtrRad7.SetLimitation(0)
        hybridBody1.AppendHybridShape(hybridShapeCircleCtrRad7)
        hybridShapeCircleCtrRad6.Name = "齿顶半圆"

        Dim hybridShapeIntersection3 = hybridShapeFactory1.AddNewIntersection(hybridShapeSpline1, hybridShapeCircleCtrRad7)
        hybridShapeIntersection3.PointType = 0
        hybridBody1.AppendHybridShape(hybridShapeIntersection3)
        hybridShapeIntersection3.Name = "样条与齿顶圆交点_1"

        Dim reference_222 = part1.CreateReferenceFromBRepName("BorderFVertex:(BEdge:(Brp:(GSMSymmetry.1;(Brp:(GSMCurve.1;2)));None:(Limits1:();Limits2:();-1);Cf11:());WithPermanentBody;WithoutBuildError;WithSelectingFeatureSupport;MFBRepVersion_CXR15)", hybridShapeSymmetry1)
        Dim hybridShapeLinePtPt3 = hybridShapeFactory1.AddNewLinePtPt(t_point(14), reference_222)
        hybridBody1.AppendHybridShape(hybridShapeLinePtPt3)
        hybridShapeLinePtPt3.Name = "齿槽顶直线"

        Dim hybridShapeSplit6 As HybridShapeSplit
        Dim hybridShapeAssemble1 As HybridShapeAssemble
        Dim hybridShapeSplit7 As HybridShapeSplit
        Dim hybridShapeSymmetry3 As HybridShapeSymmetry
        Dim hybridShapeSplit1 As HybridShapeSplit

        If Rb < Rf + pf Then
            hybridShapeSplit6 = hybridShapeFactory1.AddNewHybridSplit(hybridShapeSpline1, hybridShapeCorner1, -1)
            hybridShapeFactory1.GSMVisibility(hybridShapeSpline1, 0)
            hybridBody1.AppendHybridShape(hybridShapeSplit6)
            hybridShapeSplit6.Name = "右侧齿面"
            hybridShapeSplit7 = hybridShapeFactory1.AddNewHybridSplit(hybridShapeSymmetry1, hybridShapeSymmetry2, -1)
            hybridShapeFactory1.GSMVisibility(hybridShapeSymmetry1, 0)
            hybridBody1.AppendHybridShape(hybridShapeSplit7)
            hybridShapeSplit7.Name = "左侧齿面"
            hybridShapeAssemble1 = hybridShapeFactory1.AddNewJoin(hybridShapeSplit6, hybridShapeLinePtPt3)
            hybridShapeAssemble1.AddElement(hybridShapeSplit7)
        Else
            hybridShapeSplit1 = hybridShapeFactory1.AddNewHybridSplit(hybridShapeLineTangency1, hybridShapeCorner1, -1)
            hybridShapeFactory1.GSMVisibility(reference1, 0)
            hybridBody1.AppendHybridShape(hybridShapeSplit1)
            hybridShapeSplit1.Name = "过度线"
            hybridShapeAssemble1 = hybridShapeFactory1.AddNewJoin(hybridShapeSpline1, hybridShapeLinePtPt3)
            hybridShapeAssemble1.AddElement(hybridShapeSymmetry1)
            hybridShapeSymmetry3 = hybridShapeFactory1.AddNewSymmetry(hybridShapeSplit1, hybridShapeLinePtPt2)
            hybridShapeSymmetry3.VolumeResult = False
            hybridBody1.AppendHybridShape(hybridShapeSymmetry3)
            hybridShapeSymmetry3.Name = "过度线的对称线"
            hybridShapeAssemble1.AddElement(hybridShapeSymmetry3)
            hybridShapeAssemble1.AddElement(hybridShapeSplit1)
        End If

        hybridShapeAssemble1.AddElement(hybridShapeSymmetry2)
        hybridShapeAssemble1.AddElement(hybridShapeSplit3)
        hybridShapeAssemble1.AddElement(hybridShapeCorner1)
        hybridShapeAssemble1.SetConnex(1)
        hybridShapeAssemble1.SetManifold(1)
        hybridShapeAssemble1.SetSimplify(0)
        hybridShapeAssemble1.SetSuppressMode(0)
        hybridShapeAssemble1.SetDeviation(0.001)
        hybridShapeAssemble1.SetAngularToleranceMode(0)
        hybridShapeAssemble1.SetAngularTolerance(0.5)
        hybridShapeAssemble1.SetFederationPropagation(0)
        hybridBody1.AppendHybridShape(hybridShapeAssemble1)
        hybridShapeAssemble1.Name = "齿形"

        Dim hybridShapeDirection1 = hybridShapeFactory1.AddNewDirectionByCoord(0#, 0#, 1.0#)
        Dim hybridShapeLinePtDir1 = hybridShapeFactory1.AddNewLinePtDir(reference1, hybridShapeDirection1, 0#, B, True)
        hybridBody1.AppendHybridShape(hybridShapeLinePtDir1)
        hybridShapeLinePtDir1.Name = "齿轮轴线"

        part1.InWorkObject = hybridShapeCircleCtrRad1

        part1.Update()

        '--------------------------齿廓曲线建立完毕-----------------------

        Dim bodies1 As Bodies
        bodies1 = part1.Bodies

        Dim body1 As Body
        body1 = part1.MainBody()

        part1.InWorkObject = body1

        Dim shapeFactory1 As ShapeFactory
        shapeFactory1 = part1.ShapeFactory

        Dim reference3 As Reference
        reference3 = part1.CreateReferenceFromName("")

        Dim pad1 As Pad
        pad1 = shapeFactory1.AddNewPadFromRef(reference3, B)

        Dim reference4 As Reference
        reference4 = part1.CreateReferenceFromObject(hybridShapeCircleCtrRad2)
        pad1.SetProfileElement(reference4)
        Dim limit1 As Limit
        limit1 = pad1.FirstLimit
        Dim length1 As Length
        length1 = limit1.Dimension
        length1.Value = B


        Dim reference5 As Reference
        reference5 = part1.CreateReferenceFromName("")

        Dim reference6 As Reference
        reference6 = part1.CreateReferenceFromName("")

        Dim slot1 As Slot, Pocket1 As Pocket, circPattern1 As CircPattern
        If Flag_β <> 0 Then

            Dim Helix_LuoXuanXian As HybridShapeHelix
            If Flag_β = 1 Then
                Helix_LuoXuanXian = hybridShapeFactory1.AddNewHelix(hybridShapeLinePtDir1, True, hybridShapeIntersection3, P_LuoJu, 10.0#, True, 0#, 0#, False)
            Else
                Helix_LuoXuanXian = hybridShapeFactory1.AddNewHelix(hybridShapeLinePtDir1, True, hybridShapeIntersection3, -P_LuoJu, 10.0#, True, 0#, 0#, False)
            End If

            Helix_LuoXuanXian.PitchLawType = 0
            Helix_LuoXuanXian.SetStartingAngle(0#)
            Helix_LuoXuanXian.SetHeight(3 * B)
            hybridBody1.AppendHybridShape(Helix_LuoXuanXian)
            Helix_LuoXuanXian.Name = "齿顶圆上螺旋线"
            slot1 = shapeFactory1.AddNewSlotFromRef(hybridShapeAssemble1, Helix_LuoXuanXian)
            slot1.ReferenceSurfaceElement = hybridShapePlaneExplicit1
            circPattern1 = shapeFactory1.AddNewCircPattern(slot1, 1, 2, 20.0#, 45.0#, 1, 1, reference5, reference6, True, 0#, True)
        Else

            Pocket1 = shapeFactory1.AddNewPocketFromRef(hybridShapeAssemble1, B)
            Dim limit_111 = Pocket1.FirstLimit
            limit_111.LimitMode = CatLimitMode.catUpThruNextLimit
            circPattern1 = shapeFactory1.AddNewCircPattern(Pocket1, 1, 2, 20.0#, 45.0#, 1, 1, reference5, reference6, True, 0#, True)
        End If

        circPattern1.CircularPatternParameters = CatCircularPatternParameters.catInstancesandAngularSpacing

        Dim angularRepartition1 As AngularRepartition
        angularRepartition1 = circPattern1.AngularRepartition

        Dim intParam1 As IntParam
        intParam1 = angularRepartition1.InstancesCount

        intParam1.Value = z

        Dim angularRepartition2 As AngularRepartition
        angularRepartition2 = circPattern1.AngularRepartition

        Dim angle1 As Angle
        angle1 = angularRepartition2.AngularSpacing

        angle1.Value = 360 / z

        intParam1.Value = z

        circPattern1.SetRotationAxis(hybridShapeDirection1)

        part1.Update()

        Dim selection1 As Selection
        selection1 = partDoc.Selection

        Dim visPropertySet1 As VisPropertySet
        visPropertySet1 = selection1.VisProperties
        selection1.Add(hybridBody1)
        visPropertySet1 = visPropertySet1.Parent
        visPropertySet1.SetShow(1)
        selection1.Clear()

        Dim product1 As Product
        product1 = partDoc.GetItem("Part1")

        Dim parameters1 As Parameters
        parameters1 = product1.UserRefProperties

        Dim strParam1 As StrParam, strParam2 As StrParam
        strParam1 = parameters1.CreateString("设计", "")
        strParam2 = parameters1.CreateString("单位", "")


        strParam1.Value = "Lentil"
        strParam2.Value = "The MIA of CUST"

        GearModel = 1
    End Function
End Class
