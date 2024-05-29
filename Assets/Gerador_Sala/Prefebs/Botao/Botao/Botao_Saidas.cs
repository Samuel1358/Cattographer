using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao_Saidas : MonoBehaviour
{
    Player_Final player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player_Final>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (FindObjectsOfType<Botao_Saidas>().Length == 1)
            {
                player.aberto = true;
            }
            Destroy(gameObject);
        }
    }
}
