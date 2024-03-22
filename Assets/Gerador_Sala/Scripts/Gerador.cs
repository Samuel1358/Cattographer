using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerador : MonoBehaviour
{
    // Sala ID
    // [não utilizado ainda]
    public int[,] ID = new int[5, 5] { { 1,  2,  3,  4, 5},
                                       { 6,  7,  8,  9, 10},
                                       {11, 12, 13, 14, 15},
                                       {16, 17, 18, 19, 20},
                                       {21, 22, 23, 24, 25} };

    // Sala POS
    // (valores das posicoes reais das salas, baseando a matriz no formato do gride)
    public int[,,] POS = new int[5, 5, 2] { {  /*1*/{-22, 22},   /*2*/{-11, 22},   /*3*/{0, 22},   /*4*/{11, 22},   /*5*/{22, 22} },
                                            {  /*6*/{-22, 11},   /*7*/{-11, 11},   /*8*/{0, 11},   /*9*/{11, 11},   /*10*/{22, 11} },
                                            { /*11*/{-22, 0},   /*12*/{-11, 0},   /*13*/{0, 0},   /*14*/{11, 0},   /*15*/{22, 0} },
                                            { /*16*/{-22, -11}, /*17*/{-11, -11}, /*18*/{0, -11}, /*19*/{11, -11}, /*20*/{22, -11} },
                                            { /*21*/{-22, -22}, /*22*/{-11, -22}, /*23*/{0, -22}, /*24*/{11, -22}, /*25*/{22, -22} } };

    // (importando o gride, para se ultilizar das matrizes 'obj e 'rotacao')
    public Gride grid;

    // Start is called before the first frame update
    void Start()
    {
        #region // Gerar
        // (a cada posicao do grid, com base nas coordenadas das matrizes,)
        // (se instancia o prefeb da sala correnpondete e ajusta sua rotacao)

        for (int i = 0; i < POS.GetLength(0); i++)
        {
            for (int j = 0; j < POS.GetLength(1); j++)
            {
                Instantiate(grid.obj[i, j], new Vector3(POS[i, j, 0], 0, POS[i, j, 1]), Quaternion.Euler(0f, 90f * grid.rotacao[i, j], 0f));
            }
        }

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
