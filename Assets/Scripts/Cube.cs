using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour 
{
    public float MultiplyChance { get; private set; } = 1f;
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Construct(float multiplyChance, Vector3 scale)
    {
        MultiplyChance = multiplyChance;
        transform.localScale = scale;
    }
}
