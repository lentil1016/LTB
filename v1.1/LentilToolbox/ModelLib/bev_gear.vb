
'The MIT License (MIT)
'Copyright(c) 2016 Lentil Sun

'Permission Is hereby granted, free Of charge, to any person obtaining a copy of this software And associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, And/Or sell copies of the Software, And to permit persons to whom the Software Is furnished to do so, subject to the following conditions:

'The above copyright notice And this permission notice shall be included In all copies Or substantial portions Of the Software.

'THE SOFTWARE Is PROVIDED "AS IS", WITHOUT WARRANTY Of ANY KIND, EXPRESS Or IMPLIED, INCLUDING BUT Not LIMITED To THE WARRANTIES Of MERCHANTABILITY, FITNESS For A PARTICULAR PURPOSE And NONINFRINGEMENT. In NO Event SHALL THE AUTHORS Or COPYRIGHT HOLDERS BE LIABLE For ANY CLAIM, DAMAGES Or OTHER LIABILITY, WHETHER In AN ACTION Of CONTRACT, TORT Or OTHERWISE, ARISING FROM, OUT Of Or In CONNECTION With THE SOFTWARE Or THE USE Or OTHER DEALINGS In THE SOFTWARE.


Imports INFITF
Imports MECMOD
Imports KnowledgewareTypeLib
Imports HybridShapeTypeLib
Imports PARTITF
Imports System.Math





Public Class bevgear
    Public S As Double
    Public pf As Double
    Public R As Double
    Public Ra As Double
    Public Rf As Double
    Public Rb As Double
    Public D_r As Double
    Public T_arc As Double
    Public θa As Double
    Public θf As Double
    Public δa As Double
    Public δf As Double
    Public R_ν As Double
    Public Rb_ν As Double
    Public Rf_ν As Double
    Public Const PI = 3.14159265358979

    Function bev_GearModel(H As Double, m As Integer, z As Integer, α As Double, A As Double, B As Double, C As Double, δ As Double, Dir As Boolean, oPartDoc As PartDocument) As Boolean

        α = α / 180 * PI
        δ = δ / 180 * PI

        R = m * z / 2                               '分度圆半径
        Ra = R + m * Cos(δ)                        '齿顶圆半径
        Rf = R - 1.2 * m * Cos(δ)                  '齿根圆半径

        D_r = m * z / (2 * Sin(δ))                 '外锥距

        θa = Atan(m / D_r)                          '齿顶角
        θf = Atan(1.2 * m / D_r)                    '齿根角
        δa = δ + θa                              '顶锥角
        δf = δ - θf                              '根锥角

        R_ν = R / Cos(δ)                          '当量齿轮分度圆半径
        Rb_ν = R_ν * Cos(α)                      '当量齿轮基圆半径
        Rf_ν = Rf / Sin(PI / 2 - δ)               '当量齿根圆半径

        S = m * PI / 2                              '分度圆处齿槽宽厚
        pf = 0.38 * m                               '齿根圆角

        Dim partdoc1 = oPartDoc
        Dim part1 = partdoc1.Part

        Dim hybridBodies1 = part1.HybridBodies

        Dim hybridBody1 = hybridBodies1.Add()

        Dim hybridShapeFactory1 As HybridShapeFactory
        hybridShapeFactory1 = part1.HybridShapeFactory

        Dim Point_jizhun = hybridShapeFactory1.AddNewPointCoord(0#, 0#, 0#)
        hybridBody1.AppendHybridShape(Point_jizhun)
        Point_jizhun.Name = "基准点"

        Dim Point_DingWeiDian = hybridShapeFactory1.AddNewPointCoord(0#, H, 0#)
        hybridBody1.AppendHybridShape(Point_DingWeiDian)
        Point_DingWeiDian.Name = "定位点"

        Dim originElements1 = part1.OriginElements

        Dim Plane_YZ = originElements1.PlaneYZ
        Dim Plane_XY = originElements1.PlaneXY
        Dim Plane_ZX = originElements1.PlaneZX

        Dim Line_Y = hybridShapeFactory1.AddNewIntersection(Plane_YZ, Plane_XY)
        Line_Y.PointType = 0
        hybridBody1.AppendHybridShape(Line_Y)
        Line_Y.Name = "Y轴"

        Dim Point_FenDuDingDian = hybridShapeFactory1.AddNewPointOnPlane(Plane_YZ, R / Tan(δ), R)
        hybridBody1.AppendHybridShape(Point_FenDuDingDian)
        Point_FenDuDingDian.Name = "分度圆顶点"

        Dim Line_FenDuMuXian = hybridShapeFactory1.AddNewLinePtPt(Point_jizhun, Point_FenDuDingDian)
        hybridBody1.AppendHybridShape(Line_FenDuMuXian)
        Line_FenDuMuXian.Name = "分度圆母线"

        Dim Plane_DaDuanMian = hybridShapeFactory1.AddNewPlaneNormal(Line_FenDuMuXian, Point_FenDuDingDian)
        hybridBody1.AppendHybridShape(Plane_DaDuanMian)
        Plane_DaDuanMian.Name = "齿轮大端面"

        Dim Line_ChiDingMuXian1 = hybridShapeFactory1.AddNewLineAngle(Line_FenDuMuXian, Plane_YZ, Point_jizhun, False, 0#, D_r + 10, θa * 180 / PI, False)
        hybridBody1.AppendHybridShape(Line_ChiDingMuXian1)
        Line_ChiDingMuXian1.Name = "齿顶圆母线_1"

        Dim Point_ChiDingDian = hybridShapeFactory1.AddNewIntersection(Line_ChiDingMuXian1, Plane_DaDuanMian)
        Point_ChiDingDian.PointType = 0
        hybridBody1.AppendHybridShape(Point_ChiDingDian)
        Point_ChiDingDian.Name = "大端面齿顶圆顶点"

        Dim Plane_XiaoDuanMian = hybridShapeFactory1.AddNewPlaneOffset(Plane_DaDuanMian, B, True)
        hybridBody1.AppendHybridShape(Plane_XiaoDuanMian)
        Plane_XiaoDuanMian.Name = "齿轮小端面"

        Dim Point_ChiDingDian1 = hybridShapeFactory1.AddNewIntersection(Line_ChiDingMuXian1, Plane_XiaoDuanMian)
        Point_ChiDingDian1.PointType = 0
        hybridBody1.AppendHybridShape(Point_ChiDingDian1)
        Point_ChiDingDian1.Name = "小端面齿顶圆顶点"

        Dim Point_ChiDingDian2 = hybridShapeFactory1.AddNewProject(Point_ChiDingDian1, Plane_XY)
        Point_ChiDingDian2.SolutionType = 0
        Point_ChiDingDian2.Normal = True
        Point_ChiDingDian2.SmoothingType = 0
        hybridBody1.AppendHybridShape(Point_ChiDingDian2)
        Point_ChiDingDian2.Name = "小端面齿顶圆顶点在XY上的投影点"

        Dim Line_ZuoLunKuo1 = hybridShapeFactory1.AddNewLinePtPtExtended(Point_ChiDingDian1, Point_ChiDingDian2, 1000000.0#, 0#)
        hybridBody1.AppendHybridShape(Line_ZuoLunKuo1)
        Line_ZuoLunKuo1.Name = "左轮廓参考线"

        Dim Line_ZuoLunKuo2 = hybridShapeFactory1.AddNewCurvePar(Line_ZuoLunKuo1, Plane_YZ, C, False, False)
        Line_ZuoLunKuo2.SmoothingType = 0
        hybridBody1.AppendHybridShape(Line_ZuoLunKuo2)
        Line_ZuoLunKuo2.Name = "左轮廓线_2"

        On Error GoTo Error_AAA

        Dim Point_ZuoLunKuoDingDian = hybridShapeFactory1.AddNewIntersection(Line_ZuoLunKuo2, Plane_XiaoDuanMian)
        Point_ZuoLunKuoDingDian.PointType = 0
        hybridBody1.AppendHybridShape(Point_ZuoLunKuoDingDian)
        Point_ZuoLunKuoDingDian.Name = "小端面左轮廓线顶点"

        part1.Update()

        Dim Line_YouLunKuo1 = hybridShapeFactory1.AddNewCurvePar(Line_ZuoLunKuo1, Plane_YZ, A, False, False)
        Line_YouLunKuo1.SmoothingType = 0
        hybridBody1.AppendHybridShape(Line_YouLunKuo1)
        Line_YouLunKuo1.Name = "右轮廓线_1"

        On Error GoTo Error_BBB

        Dim Point_YouLunKuoDingDian = hybridShapeFactory1.AddNewIntersection(Line_YouLunKuo1, Plane_DaDuanMian)
        Point_YouLunKuoDingDian.PointType = 0
        hybridBody1.AppendHybridShape(Point_YouLunKuoDingDian)
        Point_YouLunKuoDingDian.Name = "右轮廓线顶点"


        Dim Point_YiDongDianYou = hybridShapeFactory1.AddNewIntersection(Line_YouLunKuo1, Line_Y)
        Point_YiDongDianYou.PointType = 0
        hybridBody1.AppendHybridShape(Point_YiDongDianYou)
        Point_YiDongDianYou.Name = "右移动参考"

        Dim Point_YiDongDianZuo = hybridShapeFactory1.AddNewIntersection(Line_ZuoLunKuo2, Line_Y)
        Point_YiDongDianZuo.PointType = 0
        hybridBody1.AppendHybridShape(Point_YiDongDianZuo)
        Point_YiDongDianZuo.Name = "左移动参考"

        part1.Update()

        On Error GoTo Error_CCC

        Dim Line_ChiDingLunKuo = hybridShapeFactory1.AddNewLinePtPt(Point_ChiDingDian, Point_ChiDingDian1)
        hybridBody1.AppendHybridShape(Line_ChiDingLunKuo)
        Line_ChiDingLunKuo.Name = "齿坯齿顶轮廓线"

        Dim Line_ChiXiaoLunKuo = hybridShapeFactory1.AddNewLinePtPt(Point_ChiDingDian1, Point_ZuoLunKuoDingDian)
        hybridBody1.AppendHybridShape(Line_ChiXiaoLunKuo)
        Line_ChiXiaoLunKuo.Name = "齿坯小端面轮廓线"

        Dim Line_ZuoLunKuo = hybridShapeFactory1.AddNewLinePtPt(Point_ZuoLunKuoDingDian, Point_YiDongDianZuo)
        hybridBody1.AppendHybridShape(Line_ZuoLunKuo)
        Line_ZuoLunKuo.Name = "齿坯左轮廓线"

        Dim Line_XiaLunKuo As Line
        Line_XiaLunKuo = hybridShapeFactory1.AddNewLinePtPt(Point_YiDongDianZuo, Point_YiDongDianYou)
        hybridBody1.AppendHybridShape(Line_XiaLunKuo)
        Line_XiaLunKuo.Name = "齿坯下轮廓线"

        Dim Line_YouLunKuo = hybridShapeFactory1.AddNewLinePtPt(Point_YiDongDianYou, Point_YouLunKuoDingDian)
        hybridBody1.AppendHybridShape(Line_YouLunKuo)
        Line_YouLunKuo.Name = "齿坯右轮廓线"

        Dim Line_XieLunKuo = hybridShapeFactory1.AddNewLinePtPt(Point_YouLunKuoDingDian, Point_ChiDingDian)
        hybridBody1.AppendHybridShape(Line_XieLunKuo)
        Line_XieLunKuo.Name = "齿坯斜轮廓线"

        Dim Pline = hybridShapeFactory1.AddNewJoin(Line_ChiDingLunKuo, Line_ChiXiaoLunKuo)
        Pline.AddElement(Line_ZuoLunKuo)
        Pline.AddElement(Line_XiaLunKuo)
        Pline.AddElement(Line_YouLunKuo)
        Pline.AddElement(Line_XieLunKuo)
        Pline.SetConnex(1)
        Pline.SetManifold(1)
        Pline.SetSimplify(0)
        Pline.SetSuppressMode(0)
        Pline.SetDeviation（0.001）
        Pline.SetAngularToleranceMode（0）
        Pline.SetAngularTolerance（0.5）
        Pline.SetFederationPropagation（0）
        hybridBody1.AppendHybridShape（Pline）
        Pline.Name = "齿坯封闭轮廓线"

        Dim body1 = part1.Bodies.Add()
        Dim bodymain = part1.MainBody
        Dim shapeFactory1 As ShapeFactory
        shapeFactory1 = part1.ShapeFactory
        part1.InWorkObject = body1

        Dim reference_1 = part1.CreateReferenceFromName("")
        Dim shaft_1 As Shaft
        shaft_1 = shapeFactory1.AddNewShaftFromRef(reference_1)
        Dim angle1 = shaft_1.FirstAngle
        angle1.Value = 360.0#
        Dim angle2 = shaft_1.SecondAngle
        angle2.Value = 0#
        shaft_1.SetProfileElement(Pline)
        shaft_1.RevoluteAxis = part1.CreateReferenceFromGeometry(Line_XiaLunKuo)
        shaft_1.Name = "齿轮毛坯"

        Dim hybridShapeIntersection_1 = hybridShapeFactory1.AddNewIntersection(Plane_DaDuanMian, Plane_XY)
        hybridShapeIntersection_1.PointType = 0
        hybridBody1.AppendHybridShape（hybridShapeIntersection_1）
        Dim Point_DangLiangChiLun = hybridShapeFactory1.AddNewIntersection(hybridShapeIntersection_1, Plane_YZ)
        Point_DangLiangChiLun.PointType = 0
        hybridBody1.AppendHybridShape（Point_DangLiangChiLun）
        Point_DangLiangChiLun.Name = "当量齿轮圆心点"

        Dim Line_ChiGenMuXian1 = hybridShapeFactory1.AddNewLineAngle(Line_FenDuMuXian, Plane_YZ, Point_jizhun, False, 0#, D_r + 10, -θf * 180 / PI, False)
        hybridBody1.AppendHybridShape（Line_ChiGenMuXian1）
        Line_ChiGenMuXian1.Name = "齿根圆母线_1"

        Dim Point_ChiGenDian = hybridShapeFactory1.AddNewIntersection(Line_ChiGenMuXian1, Plane_DaDuanMian)
        Point_ChiGenDian.PointType = 0
        hybridBody1.AppendHybridShape（Point_ChiGenDian)
        Point_ChiGenDian.Name = "大端面齿根圆顶点"

        Dim Circle_DL_ChiGenYuan = hybridShapeFactory1.AddNewCircleCtrPtWithAngles(Point_DangLiangChiLun, Point_ChiGenDian, Plane_DaDuanMian, False, -45.0#, 45.0#)
        Circle_DL_ChiGenYuan.SetLimitation(0)
        hybridBody1.AppendHybridShape(Circle_DL_ChiGenYuan)
        Circle_DL_ChiGenYuan.Name = "当量齿根圆"

        Dim Circle_DL_FenDuYuan = hybridShapeFactory1.AddNewCircleCtrPtWithAngles(Point_DangLiangChiLun, Point_FenDuDingDian, Plane_DaDuanMian, False, -45.0#, 45.0#)
        Circle_DL_FenDuYuan.SetLimitation(0)
        hybridBody1.AppendHybridShape(Circle_DL_FenDuYuan)
        Circle_DL_FenDuYuan.Name = "当量分度圆"

        Dim t_Value(14) As Double
        Dim t_point(14)

        t_Value(0) = 0
        For k = 0 To 13
            t_Value(k + 1) = t_Value(k) + 0.05
        Next

        Dim point_x As Double, point_y As Double
        For i = 0 To 14
            T_arc = Rb_ν * t_Value(i)
            point_x = Rb_ν * Sin(t_Value(i)) - T_arc * Cos(t_Value(i))
            point_y = Rb_ν * Cos(t_Value(i)) + T_arc * Sin(t_Value(i)) - R_ν

            t_point(i) = hybridShapeFactory1.AddNewPointOnPlaneWithReference(Plane_DaDuanMian, Point_FenDuDingDian, point_x, point_y)

            hybridBody1.AppendHybridShape(t_point(i))
            t_point(i).Name = "point_T" & i
        Next

        Dim Spline_YouCaoLunKuo = hybridShapeFactory1.AddNewSpline()
        For i = 0 To 14

            Spline_YouCaoLunKuo.AddPointWithConstraintExplicit(t_point(i), Nothing, -1.0#, 1, Nothing, 0#)
        Next
        hybridBody1.AppendHybridShape(Spline_YouCaoLunKuo)
        Spline_YouCaoLunKuo.Name = "右齿槽轮廓线_1"

        Dim Line_Dian_0_QieXian = hybridShapeFactory1.AddNewLineTangencyOnSupport(Spline_YouCaoLunKuo, t_point(0), Plane_DaDuanMian, 0#, (Rb_ν - Rf_ν + Rf_ν / 10), True)
        hybridBody1.AppendHybridShape(Line_Dian_0_QieXian)
        Line_Dian_0_QieXian.Name = "右齿槽0点处切线"

        Dim Point_ChiHouYouDian = hybridShapeFactory1.AddNewIntersection(Spline_YouCaoLunKuo, Circle_DL_FenDuYuan)
        Point_ChiHouYouDian.PointType = 0
        hybridBody1.AppendHybridShape(Point_ChiHouYouDian)
        Point_ChiHouYouDian.Name = "齿厚右端点"

        Dim Circle_ChiHouYuan = hybridShapeFactory1.AddNewCircleCtrRadWithAngles(Point_ChiHouYouDian, Plane_DaDuanMian, False, S, 80.0#, 257.0#)
        Circle_ChiHouYuan.SetLimitation(0)
        hybridBody1.AppendHybridShape(Circle_ChiHouYuan)
        Circle_ChiHouYuan.Name = "齿厚圆"

        Dim Point_ChiHouZuoDian = hybridShapeFactory1.AddNewIntersection(Circle_ChiHouYuan, Circle_DL_FenDuYuan)
        Point_ChiHouZuoDian.PointType = 0
        hybridBody1.AppendHybridShape(Point_ChiHouZuoDian)
        Point_ChiHouZuoDian.Name = "齿厚左端点"

        Dim Line_ChiHouXianChang = hybridShapeFactory1.AddNewLinePtPt(Point_ChiHouYouDian, Point_ChiHouZuoDian)
        hybridBody1.AppendHybridShape(Line_ChiHouXianChang)
        Line_ChiHouXianChang.Name = "齿槽弦长"

        Dim Point_Mid_ChiHouXianChang = hybridShapeFactory1.AddNewPointOnCurveFromPercent(Line_ChiHouXianChang, 0.5, False)
        hybridBody1.AppendHybridShape(Point_Mid_ChiHouXianChang)
        Point_Mid_ChiHouXianChang.Name = "齿槽弦长的中点"

        Dim Line_DuiChengXian = hybridShapeFactory1.AddNewLinePtPt(Point_Mid_ChiHouXianChang, Point_DangLiangChiLun)
        hybridBody1.AppendHybridShape(Line_DuiChengXian)
        Line_DuiChengXian.Name = "齿槽对称线"

        Dim Line_Dian_0_QieXian_1 = hybridShapeFactory1.AddNewSymmetry(Line_Dian_0_QieXian, Line_DuiChengXian)
        Line_Dian_0_QieXian_1.VolumeResult = False
        hybridBody1.AppendHybridShape(Line_Dian_0_QieXian_1)
        Line_Dian_0_QieXian_1.Name = "左齿槽0点处切线"

        Dim Spline_ZuoCaoLunKuo = hybridShapeFactory1.AddNewSymmetry(Spline_YouCaoLunKuo, Line_DuiChengXian)
        Spline_ZuoCaoLunKuo.VolumeResult = False
        hybridBody1.AppendHybridShape(Spline_ZuoCaoLunKuo)
        Spline_ZuoCaoLunKuo.Name = "左齿槽轮廓线_1"

        Dim Corner_ZuoGenBuYuanJiao As HybridShapeCorner
        Dim Corner_YouGenBuYuanJiao As HybridShapeCorner
        Dim X_DaDuanChiKuo As HybridShapeAssemble
        Dim Circle_ChiGen As HybridShapeSplit


        If Rb_ν > Rf_ν + pf Then
            Corner_YouGenBuYuanJiao = hybridShapeFactory1.AddNewCorner(Line_Dian_0_QieXian, Circle_DL_ChiGenYuan, Plane_DaDuanMian, pf, 1, -1, False)
            Corner_YouGenBuYuanJiao.DiscriminationIndex = 1
            Corner_YouGenBuYuanJiao.BeginOfCorner = 2
            Corner_YouGenBuYuanJiao.FirstTangentOrientation = 1
            Corner_YouGenBuYuanJiao.SecondTangentOrientation = -1
            hybridBody1.AppendHybridShape(Corner_YouGenBuYuanJiao)
            Corner_YouGenBuYuanJiao.Name = "右根部圆角"

            Dim Line_GuoDuXian_You = hybridShapeFactory1.AddNewHybridSplit(Line_Dian_0_QieXian, Corner_YouGenBuYuanJiao, -1)
            hybridShapeFactory1.GSMVisibility(Line_Dian_0_QieXian, 0)
            hybridBody1.AppendHybridShape(Line_GuoDuXian_You)
            Line_GuoDuXian_You.Name = "右过度线"

            Corner_ZuoGenBuYuanJiao = hybridShapeFactory1.AddNewCorner(Line_Dian_0_QieXian_1, Circle_DL_ChiGenYuan, Plane_DaDuanMian, pf, -1, -1, False)
            Corner_ZuoGenBuYuanJiao.DiscriminationIndex = 1
            Corner_ZuoGenBuYuanJiao.BeginOfCorner = 1
            Corner_ZuoGenBuYuanJiao.FirstTangentOrientation = -1
            Corner_ZuoGenBuYuanJiao.SecondTangentOrientation = -1
            hybridBody1.AppendHybridShape(Corner_ZuoGenBuYuanJiao)
            Corner_ZuoGenBuYuanJiao.Name = "左根部圆角"

            Dim Line_GuoDuXian_Zuo = hybridShapeFactory1.AddNewHybridSplit(Line_Dian_0_QieXian_1, Corner_ZuoGenBuYuanJiao, -1)
            hybridShapeFactory1.GSMVisibility(Line_Dian_0_QieXian_1, 0)
            hybridBody1.AppendHybridShape(Line_GuoDuXian_Zuo)
            Line_GuoDuXian_Zuo.Name = "左过度线"

            Dim Circle_ChiGen_1 = hybridShapeFactory1.AddNewHybridSplit(Circle_DL_ChiGenYuan, Corner_YouGenBuYuanJiao, -1)
            hybridShapeFactory1.GSMVisibility(Circle_DL_ChiGenYuan, 0)
            hybridBody1.AppendHybridShape(Circle_ChiGen_1)

            Circle_ChiGen = hybridShapeFactory1.AddNewHybridSplit(Circle_ChiGen_1, Corner_ZuoGenBuYuanJiao, 1)
            hybridShapeFactory1.GSMVisibility（Circle_ChiGen_1, 0）
            hybridBody1.AppendHybridShape（Circle_ChiGen）
            Circle_ChiGen.Name = "齿槽根部"

            Dim point_ShangBuJingXiang = hybridShapeFactory1.AddNewSymmetry(t_point(14), Line_DuiChengXian)
            point_ShangBuJingXiang.VolumeResult = False
            hybridBody1.AppendHybridShape(point_ShangBuJingXiang)
            point_ShangBuJingXiang.Name = "顶部镜像点”
            Dim Line_Shang = hybridShapeFactory1.AddNewLinePtPtOnSupport(t_point(14), point_ShangBuJingXiang, Plane_DaDuanMian)
            hybridBody1.AppendHybridShape（Line_Shang）
            Line_Shang.Name = "齿槽上部直线"

            X_DaDuanChiKuo = hybridShapeFactory1.AddNewJoin(Spline_YouCaoLunKuo, Line_Shang)
            X_DaDuanChiKuo.AddElement（Spline_ZuoCaoLunKuo）

            X_DaDuanChiKuo.AddElement(Line_GuoDuXian_Zuo)
            X_DaDuanChiKuo.AddElement(Line_GuoDuXian_You)

        ElseIf Rb_ν > Rf_ν Then
            Corner_YouGenBuYuanJiao = hybridShapeFactory1.AddNewCorner(Spline_YouCaoLunKuo, Circle_DL_ChiGenYuan, Plane_DaDuanMian, pf, 1, -1, False)
            Corner_YouGenBuYuanJiao.DiscriminationIndex = 1
            Corner_YouGenBuYuanJiao.BeginOfCorner = 2
            Corner_YouGenBuYuanJiao.FirstTangentOrientation = 1
            Corner_YouGenBuYuanJiao.SecondTangentOrientation = -1
            hybridBody1.AppendHybridShape(Corner_YouGenBuYuanJiao)
            Corner_YouGenBuYuanJiao.Name = "右根部圆角"

            Dim Spline_YouCaoLunKuo_Trim = hybridShapeFactory1.AddNewHybridSplit(Spline_YouCaoLunKuo, Corner_YouGenBuYuanJiao, -1)
            hybridShapeFactory1.GSMVisibility(Spline_YouCaoLunKuo, 0)
            hybridBody1.AppendHybridShape(Spline_YouCaoLunKuo_Trim)
            Spline_YouCaoLunKuo_Trim.Name = "右齿槽轮廓线"

            Corner_ZuoGenBuYuanJiao = hybridShapeFactory1.AddNewCorner(Spline_ZuoCaoLunKuo, Circle_DL_ChiGenYuan, Plane_DaDuanMian, pf, -1, -1, False)
            Corner_ZuoGenBuYuanJiao.DiscriminationIndex = 1
            Corner_ZuoGenBuYuanJiao.BeginOfCorner = 1
            Corner_ZuoGenBuYuanJiao.FirstTangentOrientation = -1
            Corner_ZuoGenBuYuanJiao.SecondTangentOrientation = -1
            hybridBody1.AppendHybridShape(Corner_ZuoGenBuYuanJiao)
            Corner_ZuoGenBuYuanJiao.Name = "左根部圆角"

            Dim Spline_ZuoCaoLunKuo_Trim = hybridShapeFactory1.AddNewHybridSplit(Spline_ZuoCaoLunKuo, Corner_ZuoGenBuYuanJiao, -1)
            hybridShapeFactory1.GSMVisibility(Spline_ZuoCaoLunKuo, 0)
            hybridBody1.AppendHybridShape(Spline_ZuoCaoLunKuo_Trim)
            Spline_ZuoCaoLunKuo_Trim.Name = "左齿槽轮廓线"

            Dim Circle_ChiGen_1 = hybridShapeFactory1.AddNewHybridSplit(Circle_DL_ChiGenYuan, Corner_YouGenBuYuanJiao, -1)
            hybridShapeFactory1.GSMVisibility(Circle_DL_ChiGenYuan, 0)
            hybridBody1.AppendHybridShape(Circle_ChiGen_1)

            Circle_ChiGen = hybridShapeFactory1.AddNewHybridSplit(Circle_ChiGen_1, Corner_ZuoGenBuYuanJiao, 1)
            hybridShapeFactory1.GSMVisibility（Circle_ChiGen_1, 0）
            hybridBody1.AppendHybridShape（Circle_ChiGen）
            Circle_ChiGen.Name = "齿槽根部"

            Dim point_ShangBuJingXiang = hybridShapeFactory1.AddNewSymmetry(t_point(14), Line_DuiChengXian)
            point_ShangBuJingXiang.VolumeResult = False
            hybridBody1.AppendHybridShape(point_ShangBuJingXiang)
            point_ShangBuJingXiang.Name = "顶部镜像点”
            Dim Line_Shang = hybridShapeFactory1.AddNewLinePtPtOnSupport(t_point(14), point_ShangBuJingXiang, Plane_DaDuanMian)
            hybridBody1.AppendHybridShape（Line_Shang）
            Line_Shang.Name = "齿槽上部直线"

            X_DaDuanChiKuo = hybridShapeFactory1.AddNewJoin(Spline_YouCaoLunKuo_Trim, Line_Shang)
            X_DaDuanChiKuo.AddElement(Spline_ZuoCaoLunKuo_Trim)

        Else
            Corner_YouGenBuYuanJiao = hybridShapeFactory1.AddNewCorner(Spline_YouCaoLunKuo, Circle_DL_ChiGenYuan, Plane_DaDuanMian, pf, 1, -1, False)
            Corner_YouGenBuYuanJiao.DiscriminationIndex = 1
            Corner_YouGenBuYuanJiao.BeginOfCorner = 2
            Corner_YouGenBuYuanJiao.FirstTangentOrientation = 1
            Corner_YouGenBuYuanJiao.SecondTangentOrientation = -1
            hybridBody1.AppendHybridShape(Corner_YouGenBuYuanJiao)
            Corner_YouGenBuYuanJiao.Name = "右根部圆角"

            Dim Spline_YouCaoLunKuo_Trim = hybridShapeFactory1.AddNewHybridSplit(Spline_YouCaoLunKuo, Corner_YouGenBuYuanJiao, -1)
            hybridShapeFactory1.GSMVisibility(Spline_YouCaoLunKuo, 0)
            hybridBody1.AppendHybridShape(Spline_YouCaoLunKuo_Trim)
            Spline_YouCaoLunKuo_Trim.Name = "右齿槽轮廓线"

            Corner_ZuoGenBuYuanJiao = hybridShapeFactory1.AddNewCorner(Spline_ZuoCaoLunKuo, Circle_DL_ChiGenYuan, Plane_DaDuanMian, pf, -1, -1, False)
            Corner_ZuoGenBuYuanJiao.DiscriminationIndex = 1
            Corner_ZuoGenBuYuanJiao.BeginOfCorner = 1
            Corner_ZuoGenBuYuanJiao.FirstTangentOrientation = -1
            Corner_ZuoGenBuYuanJiao.SecondTangentOrientation = -1
            hybridBody1.AppendHybridShape(Corner_ZuoGenBuYuanJiao)
            Corner_ZuoGenBuYuanJiao.Name = "左根部圆角"

            Dim Spline_ZuoCaoLunKuo_Trim = hybridShapeFactory1.AddNewHybridSplit(Spline_ZuoCaoLunKuo, Corner_ZuoGenBuYuanJiao, -1)
            hybridShapeFactory1.GSMVisibility(Spline_ZuoCaoLunKuo, 0)
            hybridBody1.AppendHybridShape(Spline_ZuoCaoLunKuo_Trim）
            Spline_ZuoCaoLunKuo_Trim.Name = "左齿槽轮廓线"

            Dim Circle_ChiGen_1 = hybridShapeFactory1.AddNewHybridSplit(Circle_DL_ChiGenYuan, Corner_YouGenBuYuanJiao, -1)
            hybridShapeFactory1.GSMVisibility(Circle_DL_ChiGenYuan, 0)
            hybridBody1.AppendHybridShape(Circle_ChiGen_1)

            Circle_ChiGen = hybridShapeFactory1.AddNewHybridSplit(Circle_ChiGen_1, Corner_ZuoGenBuYuanJiao, 1)
            hybridShapeFactory1.GSMVisibility（Circle_ChiGen_1, 0）
            hybridBody1.AppendHybridShape（Circle_ChiGen）
            Circle_ChiGen.Name = "齿槽根部"

            Dim point_ShangBuJingXiang = hybridShapeFactory1.AddNewSymmetry(t_point(14), Line_DuiChengXian)
            point_ShangBuJingXiang.VolumeResult = False
            hybridBody1.AppendHybridShape(point_ShangBuJingXiang)
            point_ShangBuJingXiang.Name = "顶部镜像点”
            Dim Line_Shang = hybridShapeFactory1.AddNewLinePtPtOnSupport(t_point(14), point_ShangBuJingXiang, Plane_DaDuanMian)
            hybridBody1.AppendHybridShape（Line_Shang）
            Line_Shang.Name = "齿槽上部直线"

            X_DaDuanChiKuo = hybridShapeFactory1.AddNewJoin(Spline_YouCaoLunKuo_Trim, Line_Shang)
            X_DaDuanChiKuo.AddElement(Spline_ZuoCaoLunKuo_Trim)
        End If


        X_DaDuanChiKuo.AddElement(Corner_ZuoGenBuYuanJiao)
        X_DaDuanChiKuo.AddElement(Circle_ChiGen)
        X_DaDuanChiKuo.AddElement(Corner_YouGenBuYuanJiao)


        X_DaDuanChiKuo.SetConnex(1)
        X_DaDuanChiKuo.SetManifold（1）
        X_DaDuanChiKuo.SetSimplify（0）
        X_DaDuanChiKuo.SetSuppressMode（0）
        X_DaDuanChiKuo.SetDeviation（0.001）
        X_DaDuanChiKuo.SetAngularToleranceMode（0）
        X_DaDuanChiKuo.SetAngularTolerance（0.5）
        X_DaDuanChiKuo.SetFederationPropagation（0）
        hybridBody1.AppendHybridShape（X_DaDuanChiKuo）
        X_DaDuanChiKuo.Name = "大端齿槽"

        Dim Plane_XiaoDuanChiKuoMian = hybridShapeFactory1.AddNewPlaneOffset(Plane_DaDuanMian, (D_r + B) / 2, True)
        hybridBody1.AppendHybridShape（Plane_XiaoDuanChiKuoMian）
        Plane_XiaoDuanChiKuoMian.Name = "小端齿槽平面"

        Dim Project_XiaoDuanChiKuo = hybridShapeFactory1.AddNewProject(X_DaDuanChiKuo, Plane_XiaoDuanChiKuoMian)
        Project_XiaoDuanChiKuo.SolutionType = 0
        Project_XiaoDuanChiKuo.Normal = True
        Project_XiaoDuanChiKuo.SmoothingType = 0
        hybridBody1.AppendHybridShape（Project_XiaoDuanChiKuo）
        Project_XiaoDuanChiKuo.Name = "大端齿槽在小端齿槽平面的投影"



        Dim Point_FengBiDian = hybridShapeFactory1.AddNewProject(t_point(14), Plane_XiaoDuanChiKuoMian)
        Point_FengBiDian.SolutionType = 0
        Point_FengBiDian.Normal = True
        Point_FengBiDian.SmoothingType = 0
        hybridBody1.AppendHybridShape（Point_FengBiDian）
        Point_FengBiDian.Name = "小端封闭点投影"

        Dim Point_SuoFangDian = hybridShapeFactory1.AddNewProject(Point_FenDuDingDian, Plane_XiaoDuanChiKuoMian)
        Point_SuoFangDian.SolutionType = 0
        Point_SuoFangDian.Normal = True
        Point_SuoFangDian.SmoothingType = 0
        hybridBody1.AppendHybridShape（Point_SuoFangDian）
        Point_SuoFangDian.Name = "小端齿槽缩放点"

        Dim X_XiaoDuanChiKuo = hybridShapeFactory1.AddNewHybridScaling(Project_XiaoDuanChiKuo, Point_SuoFangDian, 0.5)
        X_XiaoDuanChiKuo.VolumeResult = False
        hybridBody1.AppendHybridShape（X_XiaoDuanChiKuo）
        X_XiaoDuanChiKuo.Name = "小端齿槽"

        Dim X_XiaoDuanFengBi = hybridShapeFactory1.AddNewHybridScaling(Point_FengBiDian, Point_SuoFangDian, 0.5)
        X_XiaoDuanFengBi.VolumeResult = False
        hybridBody1.AppendHybridShape（X_XiaoDuanFengBi）
        X_XiaoDuanFengBi.Name = "小端齿槽封闭点"

        Dim loft1 = shapeFactory1.AddNewRemovedLoft()
        Dim hybridShapeLoft1 = loft1.HybridShape
        hybridShapeLoft1.SectionCoupling = 3
        hybridShapeLoft1.Relimitation = 1
        hybridShapeLoft1.CanonicalDetection = 2

        hybridShapeLoft1.AddSectionToLoft（X_DaDuanChiKuo, 1, t_point(14)）
        hybridShapeLoft1.AddSectionToLoft（X_XiaoDuanChiKuo, 1, X_XiaoDuanFengBi）
        hybridShapeLoft1.Name = "齿槽"

        '-----------环行阵列齿槽---------------------------------------------------
        Dim reference1 As Reference
        reference1 = part1.CreateReferenceFromName("")

        Dim reference2 As Reference
        reference2 = part1.CreateReferenceFromName("")

        Dim circPattern1 As CircPattern
        circPattern1 = shapeFactory1.AddNewCircPattern(hybridShapeLoft1, 1, 2, 20.0#, 45.0#, 1, 1, reference1, reference2, True, 0#, True)

        circPattern1.CircularPatternParameters = CatCircularPatternParameters.catInstancesandAngularSpacing

        circPattern1.CircularPatternParameters = CatCircularPatternParameters.catCompleteCrown

        Dim angularRepartition1 As AngularRepartition
        angularRepartition1 = circPattern1.AngularRepartition

        Dim angle_1111 As Angle
        angle_1111 = angularRepartition1.AngularSpacing

        angle_1111.Value = 360 / z

        Dim angularRepartition2 As AngularRepartition
        angularRepartition2 = circPattern1.AngularRepartition

        Dim intParam1 As IntParam
        intParam1 = angularRepartition2.InstancesCount

        intParam1.Value = z + 1

        circPattern1.SetRotationAxis(Line_Y)
        '----------------------------建模结束------------------------
        '------------------------------移动几何体-----------------------------
        If (Dir) Then
            Dim translate1 As Translate
            translate1 = shapeFactory1.AddNewTranslate2(0#)

            Dim hybridShapeTranslate1 As HybridShapeTranslate
            hybridShapeTranslate1 = translate1.HybridShape

            hybridShapeTranslate1.VectorType = 1
            hybridShapeTranslate1.FirstPoint = Point_YiDongDianZuo
            hybridShapeTranslate1.SecondPoint = Point_DingWeiDian
        Else
            Dim hybridShapePlaneOffsetPt1 As HybridShapePlaneOffsetPt
            hybridShapePlaneOffsetPt1 = hybridShapeFactory1.AddNewPlaneOffsetPt(Plane_ZX, Point_YiDongDianYou)
            Dim symmetry1 As Symmetry
            symmetry1 = shapeFactory1.AddNewSymmetry2(hybridShapePlaneOffsetPt1)

            Dim translate1 As Translate
            translate1 = shapeFactory1.AddNewTranslate2(0#)

            Dim hybridShapeTranslate1 As HybridShapeTranslate
            hybridShapeTranslate1 = translate1.HybridShape

            hybridShapeTranslate1.VectorType = 1
            hybridShapeTranslate1.FirstPoint = Point_YiDongDianYou
            hybridShapeTranslate1.SecondPoint = Point_DingWeiDian
        End If



        part1.Update()


        Dim selection1 As Selection
        selection1 = partdoc1.Selection

        Dim visPropertySet1 As VisPropertySet
        visPropertySet1 = selection1.VisProperties

        selection1.Add(hybridBody1)
        visPropertySet1.SetShow(1)
        selection1.Clear()

        part1.InWorkObject = bodymain
        Dim add1 As Add
        add1 = shapeFactory1.AddNewAdd(body1)

        part1.Update()

        Return True

Error_AAA:
        MsgBox("凹槽深 C 太大，无解，请重新输入！", vbOKOnly, "温馨提示")

Error_BBB:
        MsgBox("齿坯厚 A 太大，无解，请重新输入！", vbOKOnly, "温馨提示")

Error_CCC:
        MsgBox("齿轮未成功创建，请重新重新检查各参数！", vbOKOnly, "温馨提示")

    End Function
End Class
