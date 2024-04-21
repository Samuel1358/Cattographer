using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_Botoes : MonoBehaviour
{
    Mov_Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Mov_Player>();
    }

    public void Cima()
    {
        player.Cima();
    }
    public void Direita()
    {
        player.Direita();
    }
    public void Baixo()
    {
        player.Baixo();
    }
    public void Esquerda()
    {
        player.Esquerda();
    }
}
