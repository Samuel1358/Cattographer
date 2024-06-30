using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Chave : MonoBehaviour
{
    Player_Final player;

    public bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player_Final>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (active) 
        {
            if (other.CompareTag("Player"))
            {
                player.portas += 1;
                Destroy(gameObject);
            }
        }       
    }
}
