Shader "Custom/HandwritingShader" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _StrokeTex ("Stroke Texture", 2D) = "black" {}
        _PenColor ("Pen Color", Color) = (0, 0, 0, 1)
        _PenWidth ("Pen Width", Float) = 1.0
        _PenPressure ("Pen Pressure", Float) = 1.0
    }

    SubShader {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert

        struct Input {
            float2 uv_MainTex;
            float2 uv_StrokeTex; // Add UV coordinates for stroke texture
        };

        sampler2D _MainTex;
        sampler2D _StrokeTex;
        fixed4 _PenColor;
        float _PenWidth;
        float _PenPressure;

        void surf (Input IN, inout SurfaceOutput o) 
        {
            // Sample the stroke texture to determine if the cube is part of the handwriting stroke
            fixed4 strokeCol = tex2D(_StrokeTex, IN.uv_StrokeTex);
            if (strokeCol.r > 0.5) { // Assuming stroke texture has a red channel indicating the stroke
                // Sample the main texture at the current pixel location
                fixed4 col = tex2D(_MainTex, IN.uv_MainTex);

                // Calculate the pen pressure factor
                float pressureFactor = clamp(smoothstep(0, 1, _PenPressure) * _PenWidth, 0, 1);

                // Calculate the pen color with pressure factor
                fixed4 penColor = _PenColor;
                penColor.a *= pressureFactor;

                // Add the pen color to the texture color
                col.rgb += penColor.rgb;
                col.a = penColor.a;

                // Output the final color
                o.Albedo = col.rgb;
                o.Alpha = col.a;
            } else {
                // If not part of the handwriting stroke, set color to transparent
                o.Albedo = fixed3(0, 0, 0);
                o.Alpha = 0;
            }
            return;
        }
        ENDCG
    }
    FallBack "Diffuse"
}