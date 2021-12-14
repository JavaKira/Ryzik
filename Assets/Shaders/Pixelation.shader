Shader "Custom/Pixelation"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _PixelSize ("PixelSize", float) = 0
    }
    SubShader
    {
        Pass {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            #include "UnityCG.cginc"       

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2_f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float _PixelSize;
            float4 _MainTex_ST;

            v2_f vert (appdata v)
            {
                v2_f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            float4 frag(v2_f input) : COLOR {
                fixed2 pos = input.vertex.xy;
                
                float x = int(pos.x) % _PixelSize;
                float y = int(pos.y) % _PixelSize;

                x = floor(_PixelSize / 2) - x;
                y = floor(_PixelSize / 2) - y;

                x = pos.x + x;
                y = pos.y + y;

                fixed2 v = fixed2(x, y) / _ScreenParams;
                v.y = 1.0 - v.y;
                
                fixed4 color = tex2D(_MainTex, v);
                return color;
            }
        
            ENDCG
        }
    }
    FallBack "Diffuse"
}
