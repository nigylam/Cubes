using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Material[] _cubeMaterials;

    public void ChangeColor(Cube cube)
    {
        if(cube.TryGetComponent(out MeshRenderer mesh))
            mesh.material = _cubeMaterials[Random.Range(0, _cubeMaterials.Length)];
    }
}
