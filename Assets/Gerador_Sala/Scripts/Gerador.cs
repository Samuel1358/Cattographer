using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerador : MonoBehaviour
{
    // (importando o gride, para se ultilizar das definicoes das salas)
    public Gride grid;

    // Start is called before the first frame update
    void Start()
    {
        // (a cada posicao do grid, com base nas coordenadas das matrizes,)
        // (se instancia o prefeb da sala correnpondete e ajusta sua rotacao)

        for (int linha = 0; linha < grid.grid.GetLength(0); linha++)
        {
            for (int coluna = 0; coluna < grid.grid.GetLength(1); coluna++)
            {
                Gride.Sala_Def definicao = grid.grid[linha, coluna];

                Vector3 posicaoNoGrid = new(linha - ((Gride.nLinhas - 1) / 2), 0, coluna - ((Gride.nColunas - 1) / 2));
                Vector3 posicaoNoMundo = posicaoNoGrid * Gride.DistanciaEntreSalas;

                //prefab.Create(definicao, posicaoNoMundo, Quaternion.Euler(0f, definicao.RotacaoEmGraus, 0f));
            }
        }
    }
}
