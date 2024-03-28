using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Texto_Itens : MonoBehaviour
{
    Player_Finalizar player;

    public Text textoP;
    public Text textoF;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player_Finalizar>();
    }

    // Update is called once per frame
    void Update()
    {
        textoP.text = player.portas.ToString();
        textoF.text = player.coletados.ToString() + " / 2";
    }

}
