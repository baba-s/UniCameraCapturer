# Uni Camera Capturer

カメラが表示している画面をテクスチャに書き込むクラス

## 使用例

```cs
using UniCameraCapturer;
using UnityEngine;

public class Example : MonoBehaviour
{
    public Texture m_texture;

    private void OnGUI()
    {
        if ( GUILayout.Button( "Capture" ) )
        {
            m_texture = CameraCapturer.Capture( Camera.main );
        }
    }
}
```