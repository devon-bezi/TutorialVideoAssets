Shader "Custom/ParticlesHDR" { 
    Properties { 
        [HDR] _Color("Color", Color) = (1, 1, 1, 1) 
        _FXTexture("VFX Texture", 2D) = "white" {}
        _AtlasColumns("Atlas Columns", Int) = 1
        _AtlasRows("Atlas Rows", Int) = 1
    } 
    SubShader { 
        Tags { 
            "Queue" = "Transparent" 
            "RenderType" = "Transparent" 
            "RenderPipeline" = "UniversalPipeline" 
        } 
        Pass { 
            ZWrite Off 
            Blend One One 
            
            HLSLPROGRAM 
            #pragma vertex vert 
            #pragma fragment frag 
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl" 

            struct Attributes { 
                float4 positionOS : POSITION; 
                float2 uv         : TEXCOORD0; 
                float4 color      : COLOR; 
                float4 customData : TEXCOORD1; 
            }; 

            struct Varyings { 
                float4 positionHCS : SV_POSITION; 
                float2 uv         : TEXCOORD0; 
                float4 color      : COLOR; 
            }; 

            TEXTURE2D(_FXTexture); 
            SAMPLER(sampler_FXTexture); 

            CBUFFER_START(UnityPerMaterial) 
            half4 _Color; 
            float4 _FXTexture_ST;
            float _AtlasColumns;
            float _AtlasRows;
            CBUFFER_END 

            Varyings vert(Attributes IN) { 
                Varyings OUT; 
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz); 
                float randomValue = IN.customData.x;
                float tileCount = _AtlasColumns * _AtlasRows;
                float tileIndex = floor(randomValue * tileCount);
                float col = fmod(tileIndex, _AtlasColumns);
                float row = floor(tileIndex / _AtlasColumns);
                float2 tileSize = float2(1.0 / _AtlasColumns, 1.0 / _AtlasRows);
                OUT.uv = (IN.uv + float2(col, (_AtlasRows - 1.0) - row)) * tileSize;
                OUT.color = IN.color; 
                return OUT; 
            } 

            half4 frag(Varyings IN) : SV_Target { 
                half4 color = SAMPLE_TEXTURE2D(_FXTexture, sampler_FXTexture, IN.uv) * _Color * IN.color; 
                color.rgb *= color.a;
                
                return color; 
            } 
            ENDHLSL 
        } 
    } 
}

