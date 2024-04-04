using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Textos_Emergencia : MonoBehaviour
{
    Player_Final player;
    Emergencia emer;
    public RectTransform canvas;

    public Text textoPortas;
    public Text textoTesouro;
    public Text textoBotao;
    public Text textoBotaoMensagem;
    float timerBotao = 20f;
    bool botao = true, posBotao = true;
    

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
        textoBotao.gameObject.SetActive(true);
        textoBotaoMensagem.gameObject.SetActive(false);
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

            if (posBotao == true)
            {
                textoBotao.rectTransform.anchorMin = new Vector2(0.5f, 1f);
                textoBotao.rectTransform.anchorMax = new Vector2(0.5f, 1f);
            
                textoBotao.rectTransform.position = new Vector3(canvas.rect.width / 2, canvas.rect.height -40f, 0f);
                posBotao = false;
            }           

            textoEmergencia.gameObject.SetActive(false);
            textoEmergenciaAlerta.gameObject.SetActive(false);

            textoPortas.text = player.portas.ToString();
            textoTesouro.text = player.coletados.ToString() + " / 2";
            textoBotao.text = player.botoes.ToString() + " / 3";
        }

        if (player.fuga == true)
        {
            textoPortas.gameObject.SetActive(false);
            textoTesouro.gameObject.SetActive(false);

            if (posBotao == false)
            {
                textoBotao.rectTransform.anchorMin = new Vector2(1f, 1f);
                textoBotao.rectTransform.anchorMax = new Vector2(1f, 1f);
                //
                textoBotao.rectTransform.position = new Vector3(canvas.rect.width - 55f, canvas.rect.height -40f, 0f);
                posBotao = true;
            }

            textoEmergencia.gameObject.SetActive(true);

            textoEmergencia.text = ((int)emer.timerFinal).ToString();
            textoBotao.text = player.botoes.ToString() + " / 3";

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

        if (player.aberto == true)
        {
            textoBotao.gameObject.SetActive(false);
            if (botao)
            {
                textoBotaoMensagem.gameObject.SetActive(true);
                if (timerBotao <= 0f)
                {
                    textoBotaoMensagem.gameObject.SetActive(false);
                    botao = false;
                }
                if (timerBotao > 0f)
                {
                    timerBotao -= Time.deltaTime;
                    if (timerBotao <= 15f)
                    {
                        textoBotaoMensagem.color = new Color(0.1568628f, 0.3921569f, 0.7058824f, (timerBotao * 17) / 255);
                    }
                }
            }
        }
    }

}
