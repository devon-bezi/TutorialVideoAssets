Shader "Custom/BackgroundGradient"
{
    Properties
    {
        _GradientColor1("Gradient Color 1", Color) = (1, 1, 1, 1)
        _GradientColor2("Gradient Color 2", Color) = (0, 0, 0, 1)
        _ColorPositions("Color Positions", Vector) = (0.0, 1.0, 0.0, 0.0)
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" }

        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            CBUFFER_START(UnityPerMaterial)
                half4 _GradientColor1;
                half4 _GradientColor2;
                float2 _ColorPositions;
            CBUFFER_END


            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.uv = IN.uv;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                return OUT;
            }
            
            float3 lerp(float3 a, float3 b, float t){
                return t * b + (1.0-t)*a;
            }

            float inverseLerp(float from, float to, float value)
            {
                return (value - from) / (to - from);
            }
            
            half4 frag(Varyings IN) : SV_Target
            {
                //half4 color = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.uv) * _BaseColor;
                float t = inverseLerp(_ColorPositions.x, _ColorPositions.y, IN.uv.y);
                float3 gradient = lerp(_GradientColor2, _GradientColor1,t);
                return float4(gradient, 1);
            }
            ENDHLSL
        }
    }
}
