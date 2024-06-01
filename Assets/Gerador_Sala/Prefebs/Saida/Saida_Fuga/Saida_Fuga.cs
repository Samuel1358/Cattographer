using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saida_Fuga : MonoBehaviour
{
    Gerenciador_Fase fase;
    Player_Final player;
    Lista_Itens lista;
    Timer_Sombra sombra;

    void Start()
    {
        fase = FindObjectOfType<Gerenciador_Fase>();
        player = FindObjectOfType<Player_Final>();
        lista = FindAnyObjectByType<Lista_Itens>();
        sombra = FindObjectOfType<Timer_Sombra>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // alterna a sala 'Unica', entre sala 'Trancada' e sala de 'NPC' unica
            if (fase.boss)
            {
                fase.boss = false;
            }
            else
            {
                fase.boss = true;
            }

            // contagem do nível da fase
            fase.nivel += 1;

            // moedas
            fase.moedas = player.moedas;

            // chaves
            fase.chaves = player.portas;

            // lista itens
            fase.listaItens = lista.listaItens;

            // recarga da sombra
            fase.timerSombra = sombra.timerSombra;
            fase.maxSombra = sombra.ttSombra;
            if ((fase.maxSombra / 5) * 3 > fase.timerSombra)
            {
                fase.timerSombra = (fase.maxSombra / 5) * 3; // 60%
            }

            
            if (fase.nivel - 1 == 5)
            {
                SceneManager.LoadScene("Win");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
        }
    }
}
