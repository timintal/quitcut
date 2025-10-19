
SDF = _EnableRim == 1 ? abs(SDF) - _RimWidth : SDF;
_RimGamma = _EnableRim == 1 ? _RimGamma : 1;
col.a = pow(smoothstep(_EdgeBlur, 0, SDF), _RimGamma);
