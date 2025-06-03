using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploader : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private ParticleSystem _disappearingEffect;
    [SerializeField] private float _multiplyExplosionForce = 500f;
    [SerializeField] private float _multiplyExplosionRadius = 10f;

    private int _effectDeletingTime = 5;
    private WaitForSeconds _deleteParticleSystemDelay;

    private void Start()
    {
        _deleteParticleSystemDelay = new WaitForSeconds(_effectDeletingTime);
    }

    public void Disappear(Vector3 explodePosition, float explosionForce, float explosionRadius)
    {
        ParticleSystem disappearingEffect = Instantiate(_disappearingEffect, explodePosition, Quaternion.identity);
        StartCoroutine(DestroyEffectAfterDelay(disappearingEffect.gameObject));

        ExplodeAllCubes(explodePosition, explosionForce, explosionRadius);
    }

    public void ExplodeChildCubes(Vector3 explodePosition, List<Rigidbody> cubesToExplode)
    {
        ParticleSystem explosionEffect = Instantiate(_explosionEffect, explodePosition, Quaternion.identity);
        StartCoroutine(DestroyEffectAfterDelay(explosionEffect.gameObject));

        Explode(cubesToExplode, _multiplyExplosionForce, _multiplyExplosionRadius, explodePosition);
    }

    private void ExplodeAllCubes(Vector3 position, float force, float radius)
    {
        Explode(GetExplodableObjects(position, radius), force, radius, position);
    }

    private void Explode(List<Rigidbody> objectsToExplode, float force, float radius, Vector3 position)
    {
        foreach (Rigidbody obj in objectsToExplode)
            obj.AddExplosionForce(_multiplyExplosionForce, position, _multiplyExplosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects(Vector3 position, float radius)
    {
        Collider[] hits = Physics.OverlapSphere(position, radius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent(out Cube cube))
                cubes.Add(cube.Rigidbody);
        }

        return cubes;
    }

    private IEnumerator DestroyEffectAfterDelay(GameObject effectObject)
    {
        yield return _deleteParticleSystemDelay;
        Destroy(effectObject);
    }
}
