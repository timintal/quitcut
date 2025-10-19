
//#include "../CodeBlock/SizeRatioA.cginc"
#include "../CodeBlock/BendA.cginc"
#include "../CodeBlock/RectangleCodeBlock.cginc"
float4 Roundness = float4(_TopRightCornerRoundness, _BottomRightCornerRoundness, _TopLeftCornerRoundness, _BottomLeftCornerRoundness);
Roundness = _ChooseRoundnessMode == 0 ? fixed4(1, 1, 1, 1) * _CornerRoundness : Roundness;
float WidthFill = _WidthFillAmount * _Width;
float HeightFill = _HeightFillAmount * _Height;
float SDF = RoundBoxSDFB(UV - float2(WidthFill - _Width, HeightFill - _Height), float2(WidthFill, HeightFill), Roundness);
