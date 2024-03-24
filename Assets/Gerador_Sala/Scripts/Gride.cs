using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gride : MonoBehaviour
{
    // (matriz para armazenar os prefebs respectivos a cada sala)
    public GameObject[,] obj = new GameObject[5, 5];

    #region //Salas
    // (prefebs de todas as salas disponiveis)

    // Saída
    public GameObject Saida_2;
    public GameObject Saida_3;
    public GameObject Saida_4;

    // Vazio
    public GameObject Vazio_2;
    public GameObject Vazio_3;
    public GameObject Vazio_4;

    // Obstáculo
    public GameObject Obsc_1;
    public GameObject Obsc_2;
    public GameObject Obsc_3;
    public GameObject Obsc_4;
    public GameObject Obsc_5;

    // NPC
    public GameObject NPC_2;
    public GameObject NPC_3;
    public GameObject NPC_4;

    // Baú
    public GameObject Bau_1;

    // Trancada
    public GameObject Trancada_1;

    // Botão
    public GameObject Botao_1;

    #endregion

    public int[,] rotacao = new int[5, 5];

    #region // Grides [tipo, forma, rotacao]
    // (templats dos grides disponiveis)

    private int[,,] grid1 = new int[5, 5, 3] { {  /*1*/{3, 3, 1},  /*2*/{7, 1, 3},  /*3*/{5, 1, 2},  /*4*/{1, 2, 1},  /*5*/{7, 1, 2} },
                                               {  /*6*/{1, 4, 0},  /*7*/{3, 2, 0},  /*8*/{4, 4, 0},  /*9*/{3, 5, 0}, /*10*/{3, 4, 3} },
                                               { /*11*/{3, 3, 1}, /*12*/{4, 3, 2}, /*13*/{5, 1, 1}, /*14*/{2, 4, 3}, /*15*/{1, 4, 1} },
                                               { /*16*/{6, 1, 0}, /*17*/{2, 4, 1}, /*18*/{3, 4, 2}, /*19*/{3, 4, 3}, /*20*/{2, 2, 1} },
                                               { /*21*/{1, 2, 0}, /*22*/{3, 3, 3}, /*23*/{7, 1, 0}, /*24*/{5, 1, 0}, /*25*/{6, 1, 0} } };

    private int[,,] grid2 = new int[5, 5, 3] { {  /*1*/{2, 3, 1},  /*2*/{6, 1, 3},  /*3*/{7, 1, 2},  /*4*/{5, 1, 1},  /*5*/{3, 3, 2} },
                                               {  /*6*/{1, 4, 0},  /*7*/{3, 4, 2},  /*8*/{3, 4, 3},  /*9*/{6, 1, 2}, /*10*/{1, 4, 1} },
                                               { /*11*/{5, 1, 1}, /*12*/{4, 3, 3}, /*13*/{2, 4, 1}, /*14*/{3, 4, 0}, /*15*/{3, 4, 3} },
                                               { /*16*/{2, 3, 1}, /*17*/{3, 4, 2}, /*18*/{3, 5, 0}, /*19*/{3, 4, 2}, /*20*/{4, 4, 3} },
                                               { /*21*/{7, 1, 0}, /*22*/{1, 2, 1}, /*23*/{5, 1, 0}, /*24*/{1, 2, 1}, /*25*/{7, 1, 0} } };

    private int[,,] grid3 = new int[5, 5, 3] { {  /*1*/{3, 3, 1},  /*2*/{5, 1, 3},  /*3*/{1, 4, 1},  /*4*/{2, 2, 0},  /*5*/{6, 1, 3} },
                                               {  /*6*/{3, 4, 1},  /*7*/{3, 4, 2},  /*8*/{3, 5, 0},  /*9*/{4, 2, 0}, /*10*/{7, 1, 3} },
                                               { /*11*/{1, 3, 3}, /*12*/{7, 1, 0}, /*13*/{2, 4, 1}, /*14*/{3, 4, 2}, /*15*/{1, 4, 2} },
                                               { /*16*/{6, 1, 1}, /*17*/{2, 4, 2}, /*18*/{3, 5, 0}, /*19*/{3, 4, 3}, /*20*/{3, 2, 1} },
                                               { /*21*/{5, 1, 1}, /*22*/{4, 3, 3}, /*23*/{1, 2, 1}, /*24*/{7, 1, 0}, /*25*/{5, 1, 0} } };

    private int[,,] grid4 = new int[5, 5, 3] { {  /*1*/{1, 3, 0},  /*2*/{3, 4, 2},  /*3*/{4, 4, 2},  /*4*/{3, 4, 2},  /*5*/{1, 3, 3} },
                                               {  /*6*/{6, 1, 2},  /*7*/{5, 1, 0},  /*8*/{7, 1, 0},  /*9*/{2, 2, 1}, /*10*/{6, 1, 2} },
                                               { /*11*/{2, 4, 1}, /*12*/{4, 2, 0}, /*13*/{3, 4, 2}, /*14*/{3, 4, 0}, /*15*/{2, 4, 3} },
                                               { /*16*/{3, 2, 1}, /*17*/{7, 1, 2}, /*18*/{5, 1, 0}, /*19*/{7, 1, 2}, /*20*/{3, 2, 1} },
                                               { /*21*/{1, 4, 1}, /*22*/{3, 4, 0}, /*23*/{5, 1, 3}, /*24*/{3, 3, 0}, /*25*/{1, 4, 3} } };

    #endregion
    public int[,,] grid = new int[5, 5, 3];


    // Start is called before the first frame update
    void Awake()
    {
        // Randomizer
        // (aleatoriza qual gride será usada)
        switch(Random.Range(1, 5))
        {
            case 1:
                grid = grid1;
                break;
            case 2:
                grid = grid2;
                break;
            case 3:
                grid = grid3;
                break;
            case 4:
                grid = grid4;
                break;
        }

        // Salas
        // (atribui os prevebs de cada salas à matriz 'obj')
        for (int i = 0; i < obj.GetLength(0); i++)
        {
            for (int j = 0; j < obj.GetLength(1); j++)
            {
                switch(grid[i, j, 0])
                {
                    // Saida
                    case 1:
                        switch(grid[i, j, 1])
                        {
                            case 2:
                                obj[i, j] = Saida_2;
                                break;
                            case 3:
                                obj[i, j] = Saida_3;
                                break;
                            case 4:
                                obj[i, j] = Saida_4;
                                break;
                        }
                        break;
                    // Vazio
                    case 2:
                        switch (grid[i, j, 1])
                        {
                            case 2:
                                obj[i, j] = Vazio_2;
                                break;
                            case 3:
                                obj[i, j] = Vazio_3;
                                break;
                            case 4:
                                obj[i, j] = Vazio_4;
                                break;
                        }
                        break;
                    // Obstaculo
                    case 3:
                        switch (grid[i, j, 1])
                        {
                            case 1:
                                obj[i, j] = Obsc_1;
                                break;
                            case 2:
                                obj[i, j] = Obsc_2;
                                break;
                            case 3:
                                obj[i, j] = Obsc_3;
                                break;
                            case 4:
                                obj[i, j] = Obsc_4;
                                break;
                            case 5:
                                obj[i, j] = Obsc_5;
                                break;
                        }
                        break;
                    // NPC
                    case 4:
                        switch (grid[i, j, 1])
                        {
                            case 2:
                                obj[i, j] = NPC_2;
                                break;
                            case 3:
                                obj[i, j] = NPC_3;
                                break;
                            case 4:
                                obj[i, j] = NPC_4;
                                break;
                        }
                        break;
                    // Bau
                    case 5:
                        obj[i, j] = Bau_1;
                        break;
                    // Trancada
                    case 6:
                        obj[i, j] = Trancada_1;
                        break;
                    // Botao
                    case 7:
                        obj[i, j] = Botao_1;
                        break;
                }
            }
        }

        // Rotacao
        // (atribui o indicie de rotacao de cada sala à matriz 'rotacao')
        for (int i = 0; i < rotacao.GetLength(0); i++)
        {
            for (int j = 0; j < rotacao.GetLength(1); j++)
            {
                rotacao[i, j] = grid[i, j, 2];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int[] infos(int i, int j)
    {
        int[] m = new int[3];
        for (int k = 0; k < 2; k++)
        {
            m[k] = grid[i, j, k];
        }
        return m;
    }
}
