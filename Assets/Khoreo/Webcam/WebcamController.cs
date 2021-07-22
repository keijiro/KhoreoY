using UnityEngine;
using UnityEngine.VFX;

namespace Khoreo
{
    public sealed class WebcamController : MonoBehaviour
    {
        [SerializeField] int _deviceIndex = 0;
        [SerializeField] Shader _filterShader = null;
        [SerializeField, Range(0, 1)] float _threshold = 0.1f;
        [SerializeField, Range(0, 1)] float _contrast = 0.5f;

        WebCamTexture _webcam;
        Material _material;
        RenderTexture _filtered;

        string DeviceName => WebCamTexture.devices[_deviceIndex].name;

        void Start()
        {
            _webcam = new WebCamTexture(DeviceName);
            _material = new Material(_filterShader);
            _filtered = new RenderTexture(1024, 1024, 0);
            _filtered.useMipMap = true;

            _webcam.Play();

            GetComponent<VisualEffect>()
              .SetTexture("WebcamTexture", _filtered);
        }

        void OnDestroy()
        {
            _webcam.Stop();

            Destroy(_webcam);
            Destroy(_material);
            Destroy(_filtered);
        }

        void Update()
        {
            _material.SetVector
              ("_FilterParams", new Vector2(_threshold, _contrast));

            Graphics.Blit(_webcam, _filtered, _material, 0);
        }
    }
}
