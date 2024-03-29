using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Tesouro : MonoBehaviour
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
            if (player.coletados >= 1)
            {
                player.fuga = true;
            }
            else
            {
                player.coletados += 1;
            }
            Destroy(gameObject);
        }
    }
}
