using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Exploder))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _minCountClones;
    [SerializeField] private int _maxCountClones;

    [SerializeField] private int _chanseSplit;

    private Exploder _exploder;

    private void Awake()
    {
        _exploder = GetComponent<Exploder>();
    }

    public void Spawn()
    {
        int multiplier = 2;
        int chanceSplitMaxValue = 101;
        int chanceSplitMinValue = 0;

        bool isSplit = Random.Range(chanceSplitMinValue, chanceSplitMaxValue) <= _chanseSplit;
        int cubeValue = Random.Range(_minCountClones, _maxCountClones);

        if (isSplit)
        {
            List<CubeSpawner> cubes = new();
            List<Rigidbody> rigidbodyCubes = new();

            for (int i = 0; i < cubeValue; i++)
            {
                cubes.Add(Instantiate(this));
            }

            foreach (var cube in cubes)
            {
                cube.Init(multiplier);
                rigidbodyCubes.Add(cube.GetComponent<Rigidbody>());
            }

            _exploder.Explode(rigidbodyCubes);
        }
        else
        {
            _exploder.ExplodeInRadius();
        }

        Destroy(gameObject);
    }

    private void Init(int multiplier)
    {
        _chanseSplit /= multiplier;

        transform.localScale /= multiplier;

        GetComponent<MeshRenderer>().material.color = CubeColorChanger.GetRandomColor();
    }
}
