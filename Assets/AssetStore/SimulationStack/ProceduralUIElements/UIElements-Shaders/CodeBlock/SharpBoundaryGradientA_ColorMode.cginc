
SelectedColor = lerp(_ColorA, _ColorB, smoothstep(_BoundaryBlur, 0, RotateXY(ColorUV, _GradientAngle).y + _BoundaryOffset));
