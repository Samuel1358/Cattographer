using System.Collections;
using System.Collections.Generic;
using Unity.Loading;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gerenciador_Fase : MonoBehaviour
{
    Gerenciador_Fase instance;
    Timer_Sombra sombra;
    public bool original = false;

    public bool boss = true;
    public int nivel = 1;
    public int moedas = 0;
    public int chaves = 0;
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
        if (SceneManager.GetActiveScene().name != "Jogador")
        {
            Destroy(gameObject);
        }
    }
}
