using UnityEngine;

[RequireComponent (typeof(CubeSpawner))]
public class Cube : MonoBehaviour
{
    private CubeSpawner _cubeSpawner;

    private void Awake()
    {
        _cubeSpawner = GetComponent<CubeSpawner>();
    }

    private void OnMouseUpAsButton()
    {
        _cubeSpawner.Spawn();
    }
}