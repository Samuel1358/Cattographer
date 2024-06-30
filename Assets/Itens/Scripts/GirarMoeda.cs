using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarMoeda : MonoBehaviour
{
    [SerializeField] float spd;
    [SerializeField] float timer;
    float tt;
    Vector3 vec = Vector3.one;

    private void Start()
    {
        tt = timer;
    }

    void Update()
    {
        if ((timer -= Time.deltaTime) <= 0f)
        {
            vec = new Vector3(Random.Range(1, 100), Random.Range(1, 100), Random.Range(1, 100)).normalized;
            timer = tt;
        }
        transform.Rotate(vec * spd);
    }
}
