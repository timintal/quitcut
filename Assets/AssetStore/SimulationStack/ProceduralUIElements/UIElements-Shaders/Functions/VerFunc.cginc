v2f vert(appdata v)
{
    v2f OUT;
    UNITY_SETUP_INSTANCE_ID(v);
    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
    OUT.worldPosition = v.vertex;
    OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);
    OUT.uv = TRANSFORM_TEX(v.uv, _MainTex);
    OUT.color = v.color * fixed4(1, 1, 1, 1);
    return OUT;
}



