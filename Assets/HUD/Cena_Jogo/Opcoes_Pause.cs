using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Opcoes_Pause : MonoBehaviour
{
    public GameObject pause;

    // Start is called before the first frame update
    void Start()
    {
        
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
        Time.timeScale = 1f;
    }

    public void Sair()
    {
        Application.Quit();
    }

}
