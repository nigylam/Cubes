using UnityEngine;

public class Cube : MonoBehaviour 
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Rigidbody _rigidbody;

    public float MultiplyChance { get; private set; } = 1f;

    public void AddExplosionForce(float force, Vector3 position, float radius)
    {
        _rigidbody.AddExplosionForce(force, position, radius);
    }

    public void DecreaseMultiplyChance(float previousChance, float multiplyChanceDecreasing)
    {
        MultiplyChance = previousChance * multiplyChanceDecreasing;
    }

    public void ChangeMaterial(Material material)
    {
        _meshRenderer.material = material;
    }
}
