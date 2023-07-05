Shader "Unlit/Two-Sided"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        [Enum(UnityEngine.Rendering.CullMode)] _Cull("Cull", float) = 0
        _IsFront("Is Front", Float) = 0
    }
        SubShader
        {
            Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
            Lighting Off
            ZWrite Off
            Cull[_Cull]

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    UNITY_FOG_COORDS(1)
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float _IsFront;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;

                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 col = tex2D(_MainTex, i.uv);

                    if (_IsFront == 1)
                    {
                        // Render as front side
                        return col;
                    }
                    else
                    {
                        // Render as back side (modify color or other properties as desired)
                        fixed4 modifiedColor = col * 0.5; // Example modification: reduce the color intensity
                        return modifiedColor;
                    }
                }
                ENDCG
            }
        }
}
