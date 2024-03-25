using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Porta : MonoBehaviour
{
    Player_Finalizar player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player_Finalizar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.portas >= 2)
        {
            gameObject.layer = 0;
        }
        else
        {
            gameObject.layer = 7;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.portas -= 2;
            Destroy(gameObject);
        }
    }
}
