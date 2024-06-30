using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Braseiro : MonoBehaviour
{
    [SerializeField] GameObject chama;

    private void Start()
    {
        chama = transform.GetChild(1).gameObject;
    }

    public void Acender()
    {
        chama.SetActive(true);
    }
}
