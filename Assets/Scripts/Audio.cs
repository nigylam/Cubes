using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private CubeMultiplyer _cubeMultiplyer;
    [SerializeField] private AudioClip _explode;
    [SerializeField] private AudioClip _disappear;

    private void OnEnable()
    {
        _cubeMultiplyer.Explode += Explode;
        _cubeMultiplyer.Disappear += Disappear;
    }

    private void OnDisable()
    {
        _cubeMultiplyer.Explode -= Explode;
        _cubeMultiplyer.Disappear -= Disappear;
    }

    private void Explode(Vector3 position)
    {
        _source.transform.position = position;
        _source.clip = _explode;
        _source.Play();
    }

    private void Disappear(Vector3 position)
    {
        _source.transform.position = position;
        _source.clip = _disappear;
        _source.Play();
    }
}
