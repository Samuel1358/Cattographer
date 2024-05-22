using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Chave : MonoBehaviour
{
    Player_Final player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player_Final>();
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
