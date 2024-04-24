using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lista_Itens : MonoBehaviour
{
    public int[] listaItens = new int[3] {0, 0, 0};
    public int dir = 1;
    public bool agir = false, selecionado, setas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
