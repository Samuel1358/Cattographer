using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Player : MonoBehaviour
{
    public Mov_Player player;

    private List<Vector3> posicaoSaidas = new();

    void Start()
    {
        StartCoroutine(SpawnPlayerCoroutine());
    }

    private IEnumerator SpawnPlayerCoroutine()
    {
        Gride grid = GetComponent<Gride>();

        for (int linha = 0; linha < grid.grid.GetLength(0); linha++)
        {
            for (int coluna = 0; coluna < grid.grid.GetLength(1); coluna++)
            {
                Gride.Sala_Def sala = grid.grid[linha, coluna];
                if (sala.Tipo == Gride.Tipo.Saida)
                {
                    Vector3 posicaoNoGrid = Gride.IndicesCentralizados(linha, coluna);
                    Vector3 posicaoNoMundo = Gride.PosicaoNoMundo(posicaoNoGrid);
                    posicaoSaidas.Add(posicaoNoMundo);
                }
            }
        }

        Vector3 spawn = posicaoSaidas[Random.Range(0, posicaoSaidas.Count)];

        player.canMove = false;
        yield return player.SpawnCoroutine(new Vector3(spawn.x, 2f, spawn.z));
        player.canMove = true;
    }
}
