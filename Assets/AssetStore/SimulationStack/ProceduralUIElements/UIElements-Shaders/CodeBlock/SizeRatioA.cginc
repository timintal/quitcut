
float4 col = float4(0, 0, 0, 0);
float2 UV = i.uv - float2(0.5, 0.5);
float ImageSizeRatio = _ImageSizeRatio.x / _ImageSizeRatio.y;
UV.x *= ImageSizeRatio;

