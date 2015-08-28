// Shader code based on Apple's CIChromaKeyFilter example: https://developer.apple.com/library/mac/#samplecode/CIChromaKeyFilter/Introduction/Intro.html

Shader "Custom/ChromaKey" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGBA)", 2D) = "white" {}
		_ColorToReplace ("_ColorToReplace", Color) = (0,0.5,0,1)
		_ThresholdSensitivity ("_ThresholdSensitivity", Range (0.0,1.0)) = 0.4
		_Smoothing ("_Smoothing", Range (0.0,1.0)) = 0.15
	}
	SubShader {
	   Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		LOD 200
		Blend SrcAlpha OneMinusSrcAlpha
		
		CGPROGRAM
		#pragma surface surf Lambert alpha:blend

		struct Input {
			float2 uv_MainTex;
      	};
      	
		sampler2D _MainTex;
		fixed4 _Color;
		fixed4 _ColorToReplace;
		float _ThresholdSensitivity,_Smoothing;
		
		void surf (Input IN, inout SurfaceOutput o) {
		    float2 xy = float2(IN.uv_MainTex.x,  IN.uv_MainTex.y);
			float4 textureColor = tex2D (_MainTex, xy);
			float maskY = 0.2989 * _ColorToReplace.r + 0.5866 * _ColorToReplace.g + 0.1145 * _ColorToReplace.b;
     		float maskCr = 0.7132 * (_ColorToReplace.r - maskY);
     		float maskCb = 0.5647 * (_ColorToReplace.b - maskY);
     
     		float Y = 0.2989 * textureColor.r + 0.5866 * textureColor.g + 0.1145 * textureColor.b;
     		float Cr = 0.7132 * (textureColor.r - Y);
     		float Cb = 0.5647 * (textureColor.b - Y);
     
     
     		float blendValue = smoothstep(_ThresholdSensitivity, _ThresholdSensitivity + _Smoothing, distance(float2(Cr, Cb), float2(maskCr, maskCb)));
			
			o.Albedo = textureColor.rgb * _Color.rgb;
			o.Alpha = textureColor.a * blendValue * _Color.a;
		}
		ENDCG
	} 
}
