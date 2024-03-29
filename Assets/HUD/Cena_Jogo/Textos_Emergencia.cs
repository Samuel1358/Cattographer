using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Textos_Emergencia : MonoBehaviour
{
    Player_Final player;
    Emergencia emer;

    public Text textoPortas;
    public Text textoTesouro;
    //public Text textoBotao1;
    //public Text textoBotao2;
    public Text textoEmergencia;
    public Text textoEmergenciaAlerta;
    float timerAlerta = 0.5f, ttAlerta;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player_Final>();
        emer = FindObjectOfType<Emergencia>();

        textoPortas.gameObject.SetActive(true);
        textoTesouro.gameObject.SetActive(true);
        //textoBotao1.gameObject.SetActive(true);
        //textoBotao2.gameObject.SetActive(false);
        textoEmergencia.gameObject.SetActive(false);
        textoEmergenciaAlerta.gameObject.SetActive(false);

        ttAlerta = timerAlerta;
        timerAlerta = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.fuga == false)
        {
            textoPortas.gameObject.SetActive(true);
            textoTesouro.gameObject.SetActive(true);
            //textoBotao1.gameObject.SetActive(true);
            //textoBotao2.gameObject.SetActive(false);
            textoEmergencia.gameObject.SetActive(false);
            textoEmergenciaAlerta.gameObject.SetActive(false);

            textoPortas.text = player.portas.ToString();
            textoTesouro.text = player.coletados.ToString() + " / 2";
        }
        if (player.fuga == true)
        {
            textoPortas.gameObject.SetActive(false);
            textoTesouro.gameObject.SetActive(false);
            //textoBotao1.gameObject.SetActive(false);
            //textoBotao2.gameObject.SetActive(true);
            textoEmergencia.gameObject.SetActive(true);

            textoEmergencia.text = ((int)emer.timerFinal).ToString();

            if (timerAlerta <= 0)
            {
                if (ttAlerta  == 0.5f)
                {
                    ttAlerta *= 2;
                    textoEmergenciaAlerta.gameObject.SetActive(true);
                    timerAlerta = ttAlerta;
                }
                else 
                {
                    ttAlerta /= 2;
                    textoEmergenciaAlerta.gameObject.SetActive(false);
                    timerAlerta = ttAlerta;
                }
            }
            if (timerAlerta > 0)
            {
                timerAlerta -= Time.deltaTime;
            }
        }
    }

}
