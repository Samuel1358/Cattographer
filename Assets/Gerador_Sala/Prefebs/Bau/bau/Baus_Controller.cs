using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baus_Controller : MonoBehaviour
{
    Bau_Radomizer[] bau;

    public int bausAtivos;
    public bool chaveSpawned = false;

    private void Start()
    {
        bau = FindObjectsOfType<Bau_Radomizer>();
        bausAtivos = bau.Length;
    }
}
