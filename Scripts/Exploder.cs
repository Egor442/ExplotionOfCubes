using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForse;
    [SerializeField] private float _explosionRadius;

    public void Explode(List<Rigidbody> cubes)
    {
        foreach (var cube in cubes)
        {
            cube.AddExplosionForce(_explosionForse, transform.position, _explosionRadius);
        }
    }

    public void ExplodeInRadius()
    {
        Collider[] cubeshits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (var hit in cubeshits)
        {
            if (hit.attachedRigidbody != null)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        _explosionForse /= transform.localScale.x;

        foreach (var cube in cubes)
        {
            _explosionRadius = _explosionRadius / transform.localScale.x / (cube.transform.position - transform.position).magnitude;

            cube.AddExplosionForce(_explosionForse, transform.position, _explosionRadius);
        }
    }
}