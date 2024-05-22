using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Porta_Tesouro : MonoBehaviour
{
    Player_Final player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player_Final>();
        }
        else
        {
            if (player.portas >= 1)
            {
                gameObject.layer = 0;
            }
            else
            {
                gameObject.layer = 7;
            }
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.portas -= 1;
            Destroy(gameObject);
        }
    }
}
