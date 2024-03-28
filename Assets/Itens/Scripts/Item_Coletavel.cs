using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Coletavel : MonoBehaviour
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
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.portas += 1;
            Destroy(gameObject);
        }
    }
}
