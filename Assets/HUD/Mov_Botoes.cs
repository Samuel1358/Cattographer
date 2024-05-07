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
            player.Movimentar(Vector3.forward);
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
            player.Movimentar(Vector3.right);
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
            player.Movimentar(Vector3.back);
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
            player.Movimentar(Vector3.left);
        }
        else
        {
            itens.dir = 4;
            itens.agir = true;
        }
    }
}
