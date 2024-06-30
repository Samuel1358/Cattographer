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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (player.coletados >= 1)
            {
                player.fuga = true;
                player.coletados += 1;
            }
            else
            {
                player.coletados += 1;
            }

            Gerenciador_Audio.TocarSFX(Gerenciador_Audio.SFX.collect);
            Destroy(gameObject);
        }
    }
}
