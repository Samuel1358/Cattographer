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
        Gerenciador_Audio.TocarSFX(Gerenciador_Audio.SFX.page);
    }

    public void FecharPause()
    {
        Time.timeScale = 1f;
        pause.SetActive(false);
        Gerenciador_Audio.TocarSFX(Gerenciador_Audio.SFX.page);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        var gr = FindObjectOfType<Gerenciador_Fase>();
        if (gr != null)
        {
            Destroy(gr.gameObject);
        }
        Gerenciador_Audio.TocarSFX(Gerenciador_Audio.SFX.page);
        SceneManager.LoadScene(0);
    }

    public void NovaSala()
    {
        Time.timeScale = 1f;
        var gr = FindObjectOfType<Gerenciador_Fase>();
        if (gr != null)
        {
            Destroy(gr.gameObject);
        }
        Gerenciador_Audio.TocarSFX(Gerenciador_Audio.SFX.revelation);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void VidaInfinita()
    {
        if (sombra.ivencivel == true)
        {
            Debug.Log("1");
            sombra.ivencivel = false;
            marcadorCheat.SetActive(false);
        }
        else if (sombra.ivencivel == false)
        {
            Debug.Log("3");
            sombra.ivencivel = true;
            marcadorCheat.SetActive(true);
        }
        Gerenciador_Audio.TocarSFX(Gerenciador_Audio.SFX.magic);
    }

    public void Sair()
    {
        Application.Quit();
    }

}
