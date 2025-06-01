using UnityEngine;
using System.Collections;

public class CubeMultiplyer : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Transform _cubeParrent;
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private ParticleSystem _disappearingEffect;
    [SerializeField] private float _sizeDecreasing = 0.5f;
    [SerializeField] private float _multiplyChanceDecreasing = 0.5f;
    [SerializeField] private int _newCubesMin = 2;
    [SerializeField] private int _newCubesMax = 6;
    [SerializeField] private float _cubeExplosionForce = 50f;
    [SerializeField] private float _cubeExplosionRadius = 10f;
    [SerializeField] private Material[] _cubeMaterials;

    private int _effectDeletingTime = 5;
    private WaitForSeconds _deleteParticleSystemDelay;

    private void Start()
    {
        _deleteParticleSystemDelay = new WaitForSeconds(_effectDeletingTime);
    }

    public void TryMultiply(Cube cube)
    {
        if ((float)UserUtil.GetRandomDouble() <= cube.MultiplyChance)
        {
            Multiply(cube);
        }
        else
        {
            ParticleSystem disappearingEffect = Instantiate(_disappearingEffect, cube.transform.position, Quaternion.identity);
            Destroy(cube.gameObject);
            StartCoroutine(DestroyEffectAfterDelay(disappearingEffect.gameObject));
        }
    }

    public void Multiply(Cube cube)
    {
        Vector3 newCubeScale = cube.transform.localScale * _sizeDecreasing;
        Vector3 newCubePosition = cube.transform.position;
        float currentMultiplyChance = cube.MultiplyChance;
        Destroy(cube.gameObject);
        int newCubesCount = UserUtil.GetRandomInt(_newCubesMin, _newCubesMax + 1);
        ParticleSystem explosionEffect = Instantiate(_explosionEffect, newCubePosition, Quaternion.identity);
        StartCoroutine(DestroyEffectAfterDelay(explosionEffect.gameObject));

        for (int i = 0; i < newCubesCount; i++)
            CreateNewCube(newCubePosition, newCubeScale, currentMultiplyChance);
    }

    private void CreateNewCube(Vector3 position, Vector3 scale, float currentMultiplyChance)
    {
        Cube newCube = Instantiate(_cubePrefab, position, Quaternion.identity, _cubeParrent);
        newCube.DecreaseMultiplyChance(currentMultiplyChance, _multiplyChanceDecreasing);
        newCube.transform.localScale = scale;
        newCube.ChangeMaterial(_cubeMaterials[UserUtil.GetRandomInt(0, _cubeMaterials.Length)]);
        newCube.AddExplosionForce(_cubeExplosionForce, position, _cubeExplosionRadius);
    }

    private IEnumerator DestroyEffectAfterDelay(GameObject effectObject)
    {
        yield return _deleteParticleSystemDelay;
        Destroy(effectObject);
    }

}
