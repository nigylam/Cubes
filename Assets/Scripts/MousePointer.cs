using UnityEngine;

public class MousePointer : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CubeMultiplyer _cubeMultiplyer;

    private Ray _mouseRay;
    private RaycastHit _hit;

    private void Update()
    {
        _mouseRay = _camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(_mouseRay, out _hit) && _hit.transform.TryGetComponent<Cube>(out Cube cube))
                _cubeMultiplyer.TryMultiply(cube);
        }
    }
}
