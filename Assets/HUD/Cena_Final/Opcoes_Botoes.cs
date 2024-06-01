using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opcoes_Botoes : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void TorreMagica()
    {
        SceneManager.LoadScene("TorreMagica");
    }
    public void CavernaCongelada()
    {
        SceneManager.LoadScene("CavernaCongelada");
    }

    /*public void Win()
    {
        SceneManager.LoadScene(2);
    }

    public void Lose()
    {
        SceneManager.LoadScene(2);
    }*/

    public void Sair()
    {
        Application.Quit();
    }

    
}
