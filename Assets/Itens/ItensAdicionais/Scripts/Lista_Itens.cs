using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lista_Itens : MonoBehaviour
{
    Gerenciador_Fase fase;

    public int[] listaItens = new int[3] {0, 0, 0};
    public int dir = 1;
    public bool agir = false, selecionado, setas;

    void Start()
    {
        // resgate das infos do gride anterior(caso tenha)
        fase = FindObjectOfType<Gerenciador_Fase>();
        listaItens = fase.listaItens;
    }

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
