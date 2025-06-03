using UnityEngine;
using System.Collections.Generic;

public class CubeMultiplyer : MonoBehaviour
{
    [SerializeField] private Exploader _exploader;
    [SerializeField] private CubeSpawner _spawner;

    public void TryMultiply(Cube cube)
    {
        if (Random.value <= cube.MultiplyChance)
        {
            List<Cube> newCubes = _spawner.SpawnCubes(cube);
            _exploader.Explode(cube.transform.position, GetCubesRigidbody(newCubes));
        }
        else
        {
            _exploader.Disappear(cube.transform.position);
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
