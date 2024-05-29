using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ativar_SaidaFuga : MonoBehaviour
{
    Player_Final player;
    public GameObject saidaFuga;
    bool ativar = true;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player_Final>();
        saidaFuga.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(ativar)
        {
            if (player.aberto)
            {
                saidaFuga.SetActive(true);
                ativar = false;
            }
        }
    }
}
