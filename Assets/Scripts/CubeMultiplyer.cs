using UnityEngine;
using System.Collections.Generic;
using System;

public class CubeMultiplyer : MonoBehaviour
{
    [SerializeField] private Exploader _exploader;
    [SerializeField] private CubeSpawner _spawner;

    public event Action<Vector3> Explode; 
    public event Action<Vector3> Disappear; 

    public void TryMultiply(Cube cube)
    {
        if (UnityEngine.Random.value <= cube.MultiplyChance)
        {
            List<Cube> newCubes = _spawner.SpawnCubes(cube);
            _exploader.ExplodeChildCubes(cube.transform.position, GetCubesRigidbody(newCubes));
            Explode?.Invoke(cube.transform.position);
        }
        else
        {
            _exploader.Disappear(cube.transform.position, cube.ExplosionForce, cube.ExplosionRadius);
            Disappear?.Invoke(cube.transform.position);
        }

        Destroy(cube.gameObject);
    }

    private List<Rigidbody> GetCubesRigidbody(List<Cube> cubes)
    {
        List<Rigidbody> cubesRigidbody = new List<Rigidbody>();

        foreach (Cube cube in cubes)
            cubesRigidbody.Add(cube.Rigidbody);

        return cubesRigidbody;
    }
}
