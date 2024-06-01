using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Opcoes_Pause : MonoBehaviour
{
    Timer_Sombra sombra;
    public GameObject marcadorCheat;

    public GameObject pause;

    // Start is called before the first frame update
    void Start()
    {
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void VidaInfinita()
    {
        if (sombra.active == true)
        {
            sombra.ivencivel = true;
            marcadorCheat.SetActive(true);
        }
        else if (sombra.active == false)
        {
            sombra.ivencivel = false;
            marcadorCheat.SetActive(false);
        }
        
        //FecharPause();
    }

    public void Sair()
    {
        Application.Quit();
    }

}
