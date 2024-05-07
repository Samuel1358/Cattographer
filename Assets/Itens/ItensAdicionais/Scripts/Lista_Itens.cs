using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lista_Itens : MonoBehaviour
{
    public int[] listaItens = new int[3] {0, 0, 0};
    public int dir = 1;
    public bool agir = false, selecionado, setas;

    public void Selecionado(bool valor)
    {
        if (setas == false)
        {
            selecionado = valor;
        }
    }

    public void Precionado(bool valor)
    {
        setas = valor;
    }
}
