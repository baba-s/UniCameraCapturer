using UnityEngine;

namespace UniCameraCapturer
{
	/// <summary>
	/// カメラが表示している画面をテクスチャに書き込むクラス
	/// </summary>
	public static class CameraCapturer
	{
		//==============================================================================
		// 変数
		//==============================================================================
		private static Texture2D     m_texture;
		private static RenderTexture m_renderTexture;
		private static bool          m_isInit;

		//==============================================================================
		// 関数
		//==============================================================================
		/// <summary>
		/// Texture 2D と RenderTexture を作成します
		/// </summary>
		public static void Init()
		{
			if ( m_isInit ) return;
			m_isInit = true;

			var width  = Screen.width;
			var height = Screen.height;

			m_texture       = new Texture2D( width, height, TextureFormat.RGB24, false );
			m_renderTexture = new RenderTexture( width, height, 24 );
		}

		/// <summary>
		/// 指定されたカメラが表示している画面をテクスチャに書き込んで返します
		/// </summary>
		public static Texture Capture( Camera camera )
		{
			Init();

			var width         = Screen.width;
			var height        = Screen.height;
			var targetTexture = camera.targetTexture;
			var active        = RenderTexture.active;

			camera.targetTexture = m_renderTexture;
			camera.Render();

			camera.targetTexture = targetTexture;
			RenderTexture.active = m_renderTexture;

			var source = new Rect( 0, 0, width, height );
			m_texture.ReadPixels( source, 0, 0 );
			m_texture.Apply();

			RenderTexture.active = active;

			return m_texture;
		}
	}
}