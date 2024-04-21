using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Opcoes_Pause : MonoBehaviour
{
    Timer_Dungeon timer;
    Timer_Sombra sombra;
    public GameObject marcadorCheat;

    public GameObject pause;

    // Start is called before the first frame update
    void Start()
    {
        timer = FindFirstObjectByType<Timer_Dungeon>();
        sombra = FindFirstObjectByType<Timer_Sombra>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AbrirPause()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void FecharPause()
    {
        Time.timeScale = 1f;
        pause.SetActive(false);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void NovaSala()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void VidaInfinita()
    {
        if (timer.active == true && sombra.active == true)
        {
            timer.active = false;
            sombra.active = false;
            marcadorCheat.SetActive(true);
        }
        else if (timer.active == false && sombra.active == false)
        {
            timer.active = true;
            sombra.active = true;
            marcadorCheat.SetActive(false);
        }
        
        //FecharPause();
    }

    public void Sair()
    {
        Application.Quit();
    }

}
