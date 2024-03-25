using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Player : MonoBehaviour
{
    Gride grid;
    Gerador gerador;
    public GameObject player;

    int [] saidas = new int[4];
    int sala = 0;
    int[] posicao = new int[2];

    // Start is called before the first frame update
    void Start()
    {
        grid = GetComponent<Gride>();
        gerador = GetComponent<Gerador>();

        #region // LISTANDO SAIDAS

        for (int x = 0; x < grid.grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.grid.GetLength(1); y++)
            {
                /*if (sala >= 3)
                {
                    break;
                }*/
                if (grid.grid[x, y, 0] == 1)
                {                    
                    saidas[sala] = gerador.ID[x, y];
                    sala++;
                }
            }
        }

        #endregion

        #region // DEFININDO SAIDA

        sala = Random.Range(0, 4);

        for (int x = 0; x < gerador.POS.GetLength(0); x++)
        {
            for (int y = 0; y < gerador.POS.GetLength(1); y++)
            {
                if (gerador.ID[x, y] == saidas[sala])
                {
                    posicao[0] = gerador.POS[x, y, 0];
                    posicao[1] = gerador.POS[x, y, 1];
                }
            }
        }

        #endregion

        player.transform.position = new Vector3(posicao[0], 2f, posicao[1]);
        //Instantiate(player, new Vector3(posicao[0], 2f, posicao[1]), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
