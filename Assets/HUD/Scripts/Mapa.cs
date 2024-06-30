using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour
{
    // (importando o gride, para se ultilizar das definicoes das salas)
    public Gride grid;

    void Start()
    {
        // (a cada posicao do grid, com base nas coordenadas das matrizes,)
        // (se instancia o prefeb da sala correnpondete e ajusta sua rotacao)

        for (int linha = 0; linha < grid.grid.GetLength(0); linha++)
        {
            for (int coluna = 0; coluna < grid.grid.GetLength(1); coluna++)
            {

            }
        }
    }
}
