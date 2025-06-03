using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Transform _cubeParrent;
    [SerializeField] private ColorChanger _colorChanger;

    [SerializeField] private float _sizeDecreasing = 0.5f;
    [SerializeField] private float _multiplyChanceDecreasing = 0.5f;
    [SerializeField] private float _explosionRadiusIncreasing = 3f;
    [SerializeField] private float _explosionForceIncreasing = 3f;
    [SerializeField] private int _newCubesMin = 2;
    [SerializeField] private int _newCubesMax = 6;

    public List<Cube> SpawnCubes(Cube cube)
    {
        Vector3 newCubeScale = cube.transform.localScale * _sizeDecreasing;
        Vector3 newCubePosition = cube.transform.position;
        float multiplyChance = cube.MultiplyChance * _multiplyChanceDecreasing;
        float explosionForce = cube.ExplosionForce * _explosionForceIncreasing;
        float explosionRadius = cube.ExplosionRadius * _explosionRadiusIncreasing;
        int newCubesCount = Random.Range(_newCubesMin, _newCubesMax + 1);

        List<Cube> newCubes = new List<Cube>();

        for (int i = 0; i < newCubesCount; i++)
            newCubes.Add(CreateCube(newCubePosition, newCubeScale, multiplyChance, explosionForce, explosionRadius));

        return newCubes;
    }

    private Cube CreateCube(Vector3 position, Vector3 scale, float multiplyChance, float explosionForce, float explosionRadius)
    {
        Cube cube = Instantiate(_cubePrefab, position, Quaternion.identity, _cubeParrent);
        cube.Construct(multiplyChance, scale, explosionForce, explosionRadius);
        _colorChanger.ChangeColor(cube);

        return cube;
    }
}
