using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Item_Tesouro : MonoBehaviour
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
            if (player.coletados >= 1)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                player.coletados += 1;
                Destroy(gameObject);
            }
        }
    }
}
