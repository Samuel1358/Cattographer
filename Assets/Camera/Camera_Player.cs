using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Player : MonoBehaviour
{
    Mov_Player player;

    // Lista de IDs
    int[,] ID = new int[5, 5] { { 1,  2,  3,  4,  5},
                                { 6,  7,  8,  9, 10},
                                {11, 12, 13, 14, 15},
                                {16, 17, 18, 19, 20},
                                {21, 22, 23, 24, 25} };

    // Posicoes das salas
    // (valores das posicoes reais das salas, baseando a matriz no formato do gride)
    int[,,] POS = new int[5, 5, 2] { {  /*1*/{-22, 22},   /*2*/{-11, 22},   /*3*/{0, 22},   /*4*/{11, 22},   /*5*/{22, 22} },
                                     {  /*6*/{-22, 11},   /*7*/{-11, 11},   /*8*/{0, 11},   /*9*/{11, 11},   /*10*/{22, 11} },
                                     { /*11*/{-22, 0},   /*12*/{-11, 0},   /*13*/{0, 0},   /*14*/{11, 0},   /*15*/{22, 0} },
                                     { /*16*/{-22, -11}, /*17*/{-11, -11}, /*18*/{0, -11}, /*19*/{11, -11}, /*20*/{22, -11} },
                                     { /*21*/{-22, -22}, /*22*/{-11, -22}, /*23*/{0, -22}, /*24*/{11, -22}, /*25*/{22, -22} } };

    int registro;

    // Start is called before the first frame update
    void Start()
    {
        /*player = FindObjectOfType<Mov_Player>();

        for (int x = 0; x < POS.GetLength(0); x++)
        {
            for (int y = 0; y < POS.GetLength(1); y++)
            {
                if (ID[x, y] == player.sala)
                {
                    Debug.Log("oii");
                    transform.position = new Vector3(POS[x, y, 0], transform.position.y, POS[x, y, 1]);
                    registro = ID[x, y];
                }
            }
        }
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<Mov_Player>();

            for (int x = 0; x < POS.GetLength(0); x++)
            {
                for (int y = 0; y < POS.GetLength(1); y++)
                {
                    if (ID[x, y] == player.sala)
                    {
                        Debug.Log("oii");
                        transform.position = new Vector3(POS[x, y, 0], transform.position.y, POS[x, y, 1] - 2.5f);
                        registro = ID[x, y];
                    }
                }
            }
            transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z - 2.5f);
        }
        else
        {
            if (player.sala != registro)
            {
                for (int x = 0; x < POS.GetLength(0); x++)
                {
                    for (int y = 0; y < POS.GetLength(1); y++)
                    {
                        if (ID[x, y] == player.sala)
                        {
                            transform.position = new Vector3(POS[x, y, 0], transform.position.y, POS[x, y, 1] - 2.5f);
                            //Debug.Log()
                            registro = ID[x, y];
                        }
                    }
                }
            }
        }
    }
}
