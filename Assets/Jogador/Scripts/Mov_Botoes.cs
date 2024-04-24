using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_Botoes : MonoBehaviour
{
    Mov_Player player;
    Lista_Itens itens;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Mov_Player>();
        itens = FindObjectOfType<Lista_Itens>();
    }

    void Update()
    {
        itens.Precionado(false);
    }

    public void Cima()
    {
        itens.Precionado(true);
        if (itens.selecionado == false)
        {
            player.Cima();
        }
        else
        {
            itens.dir = 1;
            itens.agir = true;
        } 
    }
    public void Direita()
    {
        itens.Precionado(true);
        if (itens.selecionado == false)
        {
            player.Direita();
        }
        else
        {
            itens.dir = 2;
            itens.agir = true;
        }  
    }
    public void Baixo()
    {
        itens.Precionado(true);
        if (itens.selecionado == false)
        {
            player.Baixo();
        }
        else
        {
            itens.dir = 3;
            itens.agir = true;
        }
    }
    public void Esquerda()
    {
        itens.Precionado(true);
        if (itens.selecionado == false)
        {
            player.Esquerda();
        }
        else
        {
            itens.dir = 4;
            itens.agir = true;
        }
    }
}
