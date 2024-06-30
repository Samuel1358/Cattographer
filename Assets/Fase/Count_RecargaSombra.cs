using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count_RecargaSombra : MonoBehaviour
{
    [SerializeField] int salasComcluidas = 0;

    public int GetSalas()
    {
        return salasComcluidas;
    }

    public void ConcluirSala()
    {
        salasComcluidas++;
    }
}
