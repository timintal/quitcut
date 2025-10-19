

UV -= float2(_TextureOverlayOffsetX, _TextureOverlayOffsetY);
UV = RotateXY(UV, _TextureOverlayRotation);
UV *= 1/_TextureOverlayScale;

if (_TextureOverlay_TexelSize.z > _TextureOverlay_TexelSize.w)
{
	UV.y *= _TextureOverlay_TexelSize.z / _TextureOverlay_TexelSize.w;
}
else if (_TextureOverlay_TexelSize.z < _TextureOverlay_TexelSize.w)
{
	UV.x *= _TextureOverlay_TexelSize.w / _TextureOverlay_TexelSize.z;
}

float Clipping = _TextureOverlayClipping == 1 ? smoothstep(0.5, 0.499, abs(UV.x)) * smoothstep(0.5, 0.499, abs(UV.y)) : 1;
col = tex2D(_TextureOverlay, UV + float2(0.5, 0.5)) * smoothstep(_EdgeBlur, 0, SDF) * Clipping;
col.a *= _TextureOverlayOpacity;