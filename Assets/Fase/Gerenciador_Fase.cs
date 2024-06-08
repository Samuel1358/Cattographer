using System.Collections;
using System.Collections.Generic;
using Unity.Loading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gerenciador_Fase : MonoBehaviour
{
    Gerenciador_Fase instance;
    Player_Final player;
    Lista_Itens lista;
    Timer_Sombra sombra;

    bool original = false;

    public bool boss = true;
    public int nivel = 1;
    public int moedas = 0;
    public int chaves = 0;
    public int[] listaItens = new int[3];
    public float timerSombra, maxSombra;


    void Awake()
    {
        Gerenciador_Fase[] singleton = FindObjectsOfType<Gerenciador_Fase>();

        if (singleton.Length == 1)
        {
            original = true;
        }
        else
        {
            if (original == false)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);

        // player
        player = FindAnyObjectByType<Player_Final>();
        moedas = player.moedas;
        chaves = player.portas;

        // lista itens
        lista = FindObjectOfType<Lista_Itens>();
        listaItens = lista.listaItens;

        // sombra
        sombra = FindAnyObjectByType<Timer_Sombra>();
        timerSombra = sombra.timerSombra;
        maxSombra = sombra.timerSombra;
    }

    // Start is called before the first frame update
    void Start()
    {        

    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Spawn_Player>() == null)
        {
            Destroy(gameObject);
        }
    }
}
