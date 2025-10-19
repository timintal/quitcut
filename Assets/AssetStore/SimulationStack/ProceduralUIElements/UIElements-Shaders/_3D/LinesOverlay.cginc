
#include "../CodeBlock/BaseFilesB.cginc"
#include "../CodeBlock/Variables_3.cginc"
#include "../CodeBlock/Variables_FillA.cginc"
#include "../CodeBlock/Variables_LinesA.cginc"

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableLines == 0)
        return 0;

   #include "../CodeBlock/SizeRatioA.cginc"
   float SDF = StarSDF(UV, _Size, _Turns, _EdgeAngle) - _CornerRoundness;
   #include "../CodeBlock/FillA.cginc"
   #include "../CodeBlock/LinesA.cginc"
   col.a *= smoothstep(_EdgeBlur, 0, SDF);
   col.a *= FillAmount;
   col *= i.color;
   return col;
}