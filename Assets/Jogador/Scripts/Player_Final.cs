using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Final : MonoBehaviour
{
    Gerenciador_Fase fase;

    public int moedas = 0;
    public int coletados = 0;
    public int portas = 0;

    public bool fuga = false;
    public bool aberto = false;

    void Start()
    {
        // resgate das infos do gride anterior(caso tenha)
        fase = FindObjectOfType<Gerenciador_Fase>();

        moedas = fase.moedas;
        portas = fase.chaves;
    }
}
