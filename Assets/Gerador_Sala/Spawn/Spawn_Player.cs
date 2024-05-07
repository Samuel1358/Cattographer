using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Player : MonoBehaviour
{
    public GameObject player;

    private List<Vector3> posicaoSaidas = new();

    // Start is called before the first frame update
    void Start()
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

        player.transform.position = new Vector3(spawn.x, 2f, spawn.z);
        Camera_Player.Reposicionar(player.transform.position);
        //Instantiate(player, new Vector3(posicao[0], 2f, posicao[1]), Quaternion.identity);
    }
}
