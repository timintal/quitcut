using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;


namespace ProceduralUIElements
{


    public class MaterialToImageConvertor_PUE : MonoBehaviour
    {
        
        public Material m_Material;
        public int m_Quality;



        void Start()
        {

        }


        [ContextMenu("Save Material As Image File")]
        public void SaveMaterialAsImageFile()
        {
            Texture2D _Texture= null;

            int _Width = (int)m_Material.GetVector("_ImageSizeRatio").x;
            int _Height = (int)m_Material.GetVector("_ImageSizeRatio").y;
            _Width = _Width == 0 ? 512 : _Width;
            _Height = _Height == 0 ? 512 : _Height;
            int _Quality = m_Quality == 0 ? 1 : m_Quality;
            _Width *= _Quality;
            _Height *= _Quality;

            _Texture = new Texture2D(_Width, _Height, TextureFormat.ARGB32, true);

            _Texture =  ConvertMaterialIntoTexture(m_Material, m_Quality, RenderTextureFormat.ARGB32);

            byte[] _Bytes = _Texture.EncodeToPNG();

            if (Directory.Exists(Application.dataPath + "/OutputFolder") == false)
            {
                Directory.CreateDirectory(Application.dataPath + "/OutputFolder");
            }

            string _FileName = "Image" + PlayerPrefs.GetInt("SavedFileIndex").ToString() + ".png";
            File.WriteAllBytes(Application.dataPath + "/OutputFolder/" + _FileName, _Bytes);
            PlayerPrefs.SetInt("SavedFileIndex", PlayerPrefs.GetInt("SavedFileIndex") + 1);
#if UNITY_EDITOR
            AssetDatabase.Refresh();
#endif
        }


        Texture2D ConvertMaterialIntoTexture(Material _Material, int _Quality, RenderTextureFormat _RenderTextureFormat)
        {
            int _Width = (int)_Material.GetVector("_ImageSizeRatio").x;
            int _Height = (int)_Material.GetVector("_ImageSizeRatio").y;
            _Width = _Width == 0 ? 512 : _Width;
            _Height = _Height == 0 ? 512 : _Height;
            _Quality = _Quality == 0 ? 1 : _Quality;
            _Width *= _Quality;
            _Height *= _Quality;

            RenderTexture _RenderTextureBuffer = new RenderTexture(_Width, _Height, 0, _RenderTextureFormat, RenderTextureReadWrite.Linear);
            _RenderTextureBuffer.DiscardContents();

            Texture2D _Texture = new Texture2D(_Width, _Height, TextureFormat.ARGB32, true);

            Graphics.Blit(null, _RenderTextureBuffer, _Material);
            RenderTexture.active = _RenderTextureBuffer;           // If not using a scene camera

            _Texture.ReadPixels(new Rect(0, 0, _Width, _Height), // Capture the whole texture
                              0, 0,                               // Write starting at the top-left texel
                              false);                             // No mipmaps

            _Texture.Apply();
            RenderTexture.active = null;
            _RenderTextureBuffer.Release();

            return _Texture;
        }

    }


}/// Name Space

