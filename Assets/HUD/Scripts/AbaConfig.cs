using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbaConfig : MonoBehaviour
{
    [SerializeField] GameObject painel;

    public void Abrir()
    {
        painel.SetActive(true);
    }

    public void Fechar()
    {
        painel.SetActive(false);
    }
}
