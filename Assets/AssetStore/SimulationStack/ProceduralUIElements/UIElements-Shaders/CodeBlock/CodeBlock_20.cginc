
SDF = 10.0f;
TempSDFA=0;
//TEMP2 = CalculateSDF(UV, _SelectShape_1, _Radius_1, _Width_1, _Height_1, _CornerRoundness_1, _Rotation_1, _X_1, _Y_1);
if(_SelectShape_1==0)
{
    TEMP2 = length(UV - float2(_X_1, _Y_1))- _Radius_1;
}
else
{
    TEMP2 = BoxSDF(RotateXY(UV, _Rotation_1), float2(_Width_1, _Height_1))- _CornerRoundness_1;
}
SDF = SmoothUnionSDF(SDF, TEMP2, _SmoothBlend);
//TEMP2 = CalculateSDF(UV, _SelectShape_2, _Radius_2, _Width_2, _Height_2, _CornerRoundness_2, _Rotation_2, _X_2, _Y_2);

// _SelectShape = _SelectShape_2;
// _X=_X_2;
// _Y=_Y_2;
// _Radius=_Radius_2;
// _Rotation=_Rotation_2;
// _Width=_Width_2;
// _Height=_Height_2;
// _CornerRoundness=_CornerRoundness_2;
// #include "/SDFBlock.cginc"

// _SelectShape = _SelectShape_3;
// _X=_X_3;
// _Y=_Y_3;
// _Radius=_Radius_3;
// _Rotation=_Rotation_3;
// _Width=_Width_3;
// _Height=_Height_3;
// _CornerRoundness=_CornerRoundness_;
// #include "/SDFBlock.cginc"

if(_SelectShape_2==0)
{
    TEMP2 = length(UV - float2(_X_2, _Y_2))- _Radius_2;
}
else
{
    TEMP2 = BoxSDF(RotateXY(UV, _Rotation_2), float2(_Width_2, _Height_2))- _CornerRoundness_2;
}
SDF = SmoothUnionSDF(SDF, TEMP2, _SmoothBlend);



if(_NoOfShapes>=1)
{
//TEMP2 = CalculateSDF(UV, _SelectShape_3, _Radius_3, _Width_3, _Height_3, _CornerRoundness_3, _Rotation_3, _X_3, _Y_3);
if(_SelectShape_3==0)
{
    TEMP2 = length(UV - float2(_X_3, _Y_3))- _Radius_3;
}
else
{
    TEMP2 = BoxSDF(RotateXY(UV, _Rotation_3), float2(_Width_3, _Height_3))- _CornerRoundness_3;
}
SDF = SmoothUnionSDF(SDF, TEMP2, _SmoothBlend);
}
if(_NoOfShapes>=2)
{
//TEMP2 = CalculateSDF(UV, _SelectShape_4, _Radius_4, _Width_4, _Height_4, _CornerRoundness_4, _Rotation_4, _X_4, _Y_4);
if(_SelectShape_4==0)
{
    TEMP2 = length(UV - float2(_X_4, _Y_4))- _Radius_4;
}
else
{
    TEMP2 = BoxSDF(RotateXY(UV, _Rotation_4), float2(_Width_4, _Height_4))- _CornerRoundness_4;
}
SDF = SmoothUnionSDF(SDF, TEMP2, _SmoothBlend);
}
if(_NoOfShapes>=3)
{
//TEMP2 = CalculateSDF(UV, _SelectShape_5, _Radius_5, _Width_5, _Height_5, _CornerRoundness_5, _Rotation_5, _X_5, _Y_5);
if(_SelectShape_5==0)
{
    TEMP2 = length(UV - float2(_X_5, _Y_5))- _Radius_5;
}
else
{
    TEMP2 = BoxSDF(RotateXY(UV, _Rotation_5), float2(_Width_5, _Height_5))- _CornerRoundness_5;
}
SDF = SmoothUnionSDF(SDF, TEMP2, _SmoothBlend);
}
if(_NoOfShapes>=4)
{
//TEMP2 = CalculateSDF(UV, _SelectShape_6, _Radius_6, _Width_6, _Height_6, _CornerRoundness_6, _Rotation_6, _X_6, _Y_6);
if(_SelectShape_6==0)
{
    TEMP2 = length(UV - float2(_X_6, _Y_6))- _Radius_6;
}
else
{
    TEMP2 = BoxSDF(RotateXY(UV, _Rotation_6), float2(_Width_6, _Height_6))- _CornerRoundness_6;
}
SDF = SmoothUnionSDF(SDF, TEMP2, _SmoothBlend);
}
