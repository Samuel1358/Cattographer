using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ativar_SaidaFuga : MonoBehaviour
{
    Player_Final player;
    [SerializeField] LuzDeSaida[] listaLuz;
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
                Vector3 pos = Vector3.zero;
                for(int i = 0; i < listaLuz.Length; i++)
                {
                    if ((pos = listaLuz[i].Verificar()) != Vector3.zero)
                    {
                        break;
                    }
                }
                if (pos != Vector3.zero)
                {
                    saidaFuga.transform.position = pos;
                }
                saidaFuga.SetActive(true);
                ativar = false;
            }
        }
    }
}
