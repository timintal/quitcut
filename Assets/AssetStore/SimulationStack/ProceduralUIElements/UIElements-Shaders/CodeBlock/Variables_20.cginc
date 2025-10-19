
float4 _ImageSizeRatio;

float _NoOfShapes;
float _ShapeIdentifier;

float _SelectShape_1, _SelectShape_2, _SelectShape_3, _SelectShape_4, _SelectShape_5, _SelectShape_6;
float _Radius_1, _Radius_2, _Radius_3, _Radius_4, _Radius_5, _Radius_6;
float _Width_1, _Width_2, _Width_3, _Width_4, _Width_5, _Width_6;
float _Height_1, _Height_2, _Height_3, _Height_4, _Height_5, _Height_6;
float _CornerRoundness_1, _CornerRoundness_2, _CornerRoundness_3, _CornerRoundness_4, _CornerRoundness_5, _CornerRoundness_6;
float _Rotation_1, _Rotation_2, _Rotation_3, _Rotation_4, _Rotation_5, _Rotation_6;
float _X_1, _X_2, _X_3, _X_4, _X_5, _X_6;
float _Y_1, _Y_2, _Y_3, _Y_4, _Y_5, _Y_6;

float _EdgeBlur, _SmoothBlend;

float _EnableRim;
float _RimWidth;
float _RimGamma;

float _Bloom;

float TEMP2=0;
float TempSDFA;

// float _SelectShape ;
// float _X;
// float _Y;
// float _Radius;
// float _Rotation;
// float _Width;
// float _Height;
// float _CornerRoundness;


//#define _CIRCLESDF(X,Y,Radius) length(float2(X,Y))-Radius
//#define _BOXSDF(X,Y,W,H,Roundness) length(max(abs(float2(X,Y)) - float2(W, H), 0.0)) + min(max((abs(UV) - float2(W, H)).x, (abs(float2(X, Y)) - float2(W, H)).y), 0.0) - Roundness
//#define _SMOOTHUNIONSDF(distA,distB,k) lerp(distA, distB, clamp(0.5 + 0.5 * (distA - distB) / k, 0., 1.)) - k * clamp(0.5 + 0.5 * (distA - distB) / k, 0., 1.) * (1. - clamp(0.5 + 0.5 * (distA - distB) / k, 0., 1.))

float BoxSDF(float2 UV, float2 Dimension)
{
    float2 d = abs(UV) - Dimension;
    return length(max(d, 0.0)) + min(max(d.x, d.y), 0.0);
}

float SmoothUnionSDF(float distA, float distB, float k)
{
    float h = clamp(0.5 + 0.5 * (distA - distB) / k, 0., 1.);
    return lerp(distA, distB, h) - k * h * (1. - h);
}

// float CalculateSDF(float2 UV,float Shape, float Radius, float Width, float Height, float Roundness, float Rotation, float X, float Y)
// {
//     UV = UV - float2(X, Y);
//     if (Shape == 0)
//     {
//         return (length(UV) - Radius);
//     }
//     else
//     {
//         UV = RotateXY(UV, Rotation);
//         return BoxSDF(UV, float2(Width, Height))- Roundness;
//     }
// }
