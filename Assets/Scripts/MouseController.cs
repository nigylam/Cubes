using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CubeMultiplyer _cubeMultiplyer;

    private Ray _mouseRay;
    private RaycastHit _hit;

    private void Update()
    {
        _mouseRay = _camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast( _mouseRay, out _hit) && _hit.transform.TryGetComponent<Cube>(out Cube cube) && Input.GetMouseButtonUp(0))
            _cubeMultiplyer.TryMultiply(cube);
    }
}
