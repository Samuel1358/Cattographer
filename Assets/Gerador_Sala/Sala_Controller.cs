using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Sala_Controller : MonoBehaviour
{
    Gride grid;
    Gerador gerador;

    Mov_Player player;

    // ID & INFOS
    public int id;
    public int[] infos = new int[3];

    // SAIDAS
    public Saidas_Ativador saida1;
    public Saidas_Ativador saida2;
    public Saidas_Ativador saida3;
    public Saidas_Ativador saida4;

    public bool spawnSeted = false;
    Vector3 salaSpaw;
    public float timerSpawn = 1.5f, ttSpawn = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        grid = FindObjectOfType<Gride>();
        gerador = FindObjectOfType<Gerador>();
        player = FindObjectOfType<Mov_Player>();

        #region // ID & INFOS
        // (atribui as intormações da sala)

        for (int i = 0; i < gerador.POS.GetLength(0); i++)
        {
            for (int j = 0; j < gerador.POS.GetLength(1); j++)
            {
                if (gerador.POS[i, j, 0] == transform.position.x && gerador.POS[i, j, 1] == transform.position.z)
                {
                    id = gerador.ID[i, j];

                    // Infos[tipo, forma, rotacao]
                    for (int k = 0; k < 2; k++)
                    {
                        infos[k] = grid.grid[i, j, k];
                    }
                    break;
                }
            }
        }

        #endregion

        /*#region // SAIDAS

        switch (infos[1])
        {
            case 1:
                //@
                break;
            case 2:
                //@
                break;
            case 3:
                //@
                break;
            case 4:
                //@
                break;
            case 5:
                //@
                break;
        }

        #endregion*/


        ttSpawn = timerSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        #region // SetSpawn
        // (verifica por qual saida o jogador entrou para setar o spaw, para caso ele caia em um buraco)

        if (spawnSeted == false)
        {

            if (saida1 != null)
            {
                if (saida1.playerPassed == true)
                {
                    spawnSeted = true;
                    salaSpaw = new Vector3(saida1.transform.position.x, 2f, saida1.transform.position.z);
                }                
            }
            if (saida2 != null)
            {
                if (saida2.playerPassed == true)
                {
                    spawnSeted = true;
                    salaSpaw = new Vector3(saida2.transform.position.x, 1.5f, saida2.transform.position.z);
                }                
            }
            if (saida3 != null)
            {
                if (saida3.playerPassed == true)
                {
                    spawnSeted = true;
                    salaSpaw = new Vector3(saida3.transform.position.x, 1.5f, saida3.transform.position.z);
                }                
            }
            if (saida4 != null)
            {
                if (saida4.playerPassed == true)
                {
                    spawnSeted = true;
                    salaSpaw = new Vector3(saida4.transform.position.x, 1.5f, saida4.transform.position.z);
                }                
            }
            
        }

        #endregion

        #region // SPAWN
        // (tira o player do buraco e spawna-o na saida pelo qual ele entrou)

        if (player.caiuBuraco == true && player.sala == id)
        {
            if (timerSpawn <= 0)
            {
                player.transform.position = salaSpaw;
                player.canMove = true;
                player.caiuBuraco = false;
                timerSpawn = ttSpawn;
            }
            if (timerSpawn > 0)
            {
                timerSpawn -= Time.deltaTime;
            }
        }

        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player != null)
        {
            if (other.CompareTag("Player"))
            {
                player.sala = id;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (player != null)
        {
            if (other.CompareTag("Player"))
            {
                spawnSeted = false;
            }
        }
    }
}
