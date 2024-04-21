using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opcoes_Botoes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Jogo()
    {
        SceneManager.LoadScene(1);
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
