using UnityEngine;

namespace Khoreo {

sealed class MaterialPositionBinder : MonoBehaviour
{
    [SerializeField] Transform _target = null;
    [SerializeField] string _propertyName = null;

    MaterialPropertyBlock _block;
    Renderer _renderer;

    void Start()
    {
        _block = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        _renderer.GetPropertyBlock(_block);
        _block.SetVector(_propertyName, _target.position);
        _renderer.SetPropertyBlock(_block);
    }
}

} // namespace Khoreo
