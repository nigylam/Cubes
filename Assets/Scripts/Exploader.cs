using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploader : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private ParticleSystem _disappearingEffect;
    [SerializeField] private float _cubeExplosionForce = 500f;
    [SerializeField] private float _cubeExplosionRadius = 10f;

    private int _effectDeletingTime = 5;
    private WaitForSeconds _deleteParticleSystemDelay;

    private void Start()
    {
        _deleteParticleSystemDelay = new WaitForSeconds(_effectDeletingTime);
    }

    public void Disappear(Vector3 effectPosition)
    {
        ParticleSystem disappearingEffect = Instantiate(_disappearingEffect, effectPosition, Quaternion.identity);
        StartCoroutine(DestroyEffectAfterDelay(disappearingEffect.gameObject));
    }

    public void Explode(Vector3 explodePosition, List<Rigidbody> cubesToExplode)
    {
        ParticleSystem explosionEffect = Instantiate(_explosionEffect, explodePosition, Quaternion.identity);
        StartCoroutine(DestroyEffectAfterDelay(explosionEffect.gameObject));

        foreach(Rigidbody cube in cubesToExplode)
            cube.AddExplosionForce(_cubeExplosionForce, explodePosition, _cubeExplosionRadius);
    }

    private IEnumerator DestroyEffectAfterDelay(GameObject effectObject)
    {
        yield return _deleteParticleSystemDelay;
        Destroy(effectObject);
    }
}
