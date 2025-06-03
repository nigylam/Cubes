using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour 
{
    public float MultiplyChance { get; private set; } = 1f;
    public Rigidbody Rigidbody { get; private set; }
    public float ExplosionForce { get; private set; } = 100f;
    public float ExplosionRadius { get; private set; } = 3f;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Construct(float multiplyChance, Vector3 scale, float explosionForce, float explosionRadius)
    {
        MultiplyChance = multiplyChance;
        transform.localScale = scale;
        ExplosionForce = explosionForce;
        ExplosionRadius = explosionRadius;
    }
}
