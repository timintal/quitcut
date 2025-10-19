
#include "../CodeBlock/SizeRatioA.cginc"
#include "../CodeBlock/BendA.cginc"
#include "../CodeBlock/RectangleCodeBlock.cginc"
float4 Roundness = float4(_TopRightCornerRoundness, _BottomRightCornerRoundness, _TopLeftCornerRoundness, _BottomLeftCornerRoundness);//  );
Roundness = _ChooseRoundnessMode == 0 ? fixed4(1, 1, 1, 1) * _CornerRoundness : Roundness;
