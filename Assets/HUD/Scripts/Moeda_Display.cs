using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moeda_Display : MonoBehaviour
{
    Player_Final player;
    Text texto;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player_Final>();
        texto = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        texto.text = ": " + player.moedas.ToString();
    }
}
