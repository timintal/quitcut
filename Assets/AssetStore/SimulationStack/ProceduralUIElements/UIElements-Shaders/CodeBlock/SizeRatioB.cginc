
float4 col = float4(0, 0, 0, 0);
float2 UV = i.uv - float2(0.5, 0.5);
UV.y *= _ImageSizeRatio.y / _ImageSizeRatio.x;

