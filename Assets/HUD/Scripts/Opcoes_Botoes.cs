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

    public void ComoJogar()
    {
        SceneManager.LoadScene("ComoJogar");
    }
    public void TorreMagica()
    {
        SceneManager.LoadScene("TorreMagica");
    }
    public void CavernaCongelada()
    {
        SceneManager.LoadScene("CavernaCongelada");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void JogarNovamente()
    {
        GerenciadorResultado gerenciador = FindObjectOfType<GerenciadorResultado>();
        switch (gerenciador.idFase)
        {
            case 1:
                TorreMagica();
                break;
            case 2:
                CavernaCongelada();
                break;

        }
    }

    public void Sair()
    {
        Application.Quit();
    }

    
}
