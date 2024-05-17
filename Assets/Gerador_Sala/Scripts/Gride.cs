using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gride : MonoBehaviour
{
    public const int nLinhas = 5;
    public const int nColunas = 5;

    public const float DistanciaEntreSalas = 11f;

    public enum Tipo
    {
        Saida = 1,
        Vazia = 2,
        Obstaculo = 3,
        NPC = 4,
        Bau = 5,
        Trancada = 6,
        Botao = 7,
    }
    public enum Formato
    {
        Unica = 1,
        Linha = 2,
        L = 3,
        T = 4,
        Cruz = 5,
    }
    public enum Rotacao
    {
        Normal,
        Direita,
        Invertida,
        Esquerda,
    }

    #region //Salas
    // (prefebs de todas as salas disponiveis)

    // Saída
    public Sala_Prefab Saida_2;
    public Sala_Prefab Saida_3;
    public Sala_Prefab Saida_4;

    // Vazio
    public Sala_Prefab Vazio_2;
    public Sala_Prefab Vazio_3;
    public Sala_Prefab Vazio_4;
    public Sala_Prefab Vazio_5;

    // Obstáculo
    public Sala_Prefab Obsc_1;
    public Sala_Prefab Obsc_2;
    public Sala_Prefab Obsc_3;
    public Sala_Prefab Obsc_4_1;
    public Sala_Prefab Obsc_4_2;
    public Sala_Prefab Obsc_5;

    // NPC
    public Sala_Prefab NPC_2;
    public Sala_Prefab NPC_3;
    public Sala_Prefab NPC_4;

    // Baú
    public Sala_Prefab Bau_1;

    // Trancada
    public Sala_Prefab Trancada_1;

    // Botão
    public Sala_Prefab Botao_1;

    #endregion

    public class Sala_Def
    {
        private Tipo tipo;
        private Formato formato;
        private Rotacao rotacao;

        private void Init(Tipo tipo, Formato formato, Rotacao rotacao)
        {
            this.tipo = tipo;
            this.formato = formato;
            this.rotacao = rotacao;
        }
        public Sala_Def(Tipo tipo, Formato formato, Rotacao rotacao)
        => Init(tipo, formato, rotacao);

        public Sala_Def(int tipo, int formato, int rotacao)
        => Init((Tipo)tipo, (Formato)formato, (Rotacao)rotacao);

        public Tipo Tipo => tipo;
        public Formato Formato => formato;
        public Rotacao Rotacao => rotacao;
        public float RotacaoEmGraus => 90f * (int)rotacao;
    }

    #region // Grides (tipo, forma, rotacao)
    // (templats dos grides disponiveis)
    private readonly Sala_Def[][,] grids = new[]
    {
        new[,] { //       1                      2                      3                      4                      5               
        { new Sala_Def(3, 3, 0), new Sala_Def(7, 1, 2), new Sala_Def(5, 1, 1), new Sala_Def(1, 2, 0), new Sala_Def(7, 1, 1) },    // 1
        { new Sala_Def(1, 4, 3), new Sala_Def(3, 2, 0), new Sala_Def(4, 4, 3), new Sala_Def(3, 5, 3), new Sala_Def(3, 4, 2) },    // 2
        { new Sala_Def(3, 3, 0), new Sala_Def(4, 3, 1), new Sala_Def(5, 1, 0), new Sala_Def(2, 4, 2), new Sala_Def(1, 4, 0) },    // 3
        { new Sala_Def(6, 1, 3), new Sala_Def(2, 4, 0), new Sala_Def(3, 4, 1), new Sala_Def(3, 4, 2), new Sala_Def(2, 2, 0) },    // 4
        { new Sala_Def(1, 2, 3), new Sala_Def(3, 3, 2), new Sala_Def(7, 1, 3), new Sala_Def(5, 1, 3), new Sala_Def(6, 1, 3) }, }, // 5
        
        new[,] { //       1                      2                      3                      4                      5
        { new Sala_Def(2, 3, 0), new Sala_Def(6, 1, 2), new Sala_Def(7, 1, 1), new Sala_Def(5, 1, 0), new Sala_Def(3, 3, 1) },    // 1
        { new Sala_Def(1, 4, 3), new Sala_Def(3, 4, 1), new Sala_Def(3, 4, 2), new Sala_Def(6, 1, 1), new Sala_Def(1, 4, 0) },    // 2
        { new Sala_Def(5, 1, 0), new Sala_Def(4, 3, 2), new Sala_Def(2, 4, 0), new Sala_Def(3, 4, 3), new Sala_Def(3, 4, 2) },    // 3
        { new Sala_Def(2, 3, 0), new Sala_Def(3, 4, 1), new Sala_Def(3, 5, 3), new Sala_Def(3, 4, 1), new Sala_Def(4, 4, 2) },    // 4
        { new Sala_Def(7, 1, 3), new Sala_Def(1, 2, 0), new Sala_Def(5, 1, 3), new Sala_Def(1, 2, 0), new Sala_Def(7, 1, 3) }, }, // 5
        
        new[,] { //       1                      2                      3                      4                      5
        { new Sala_Def(5, 1, 1), new Sala_Def(6, 1, 1), new Sala_Def(1, 3, 3), new Sala_Def(2, 4, 1), new Sala_Def(3, 3, 1) },    // 1
        { new Sala_Def(3, 3, 3), new Sala_Def(4, 4, 2), new Sala_Def(7, 1, 0), new Sala_Def(3, 4, 2), new Sala_Def(5, 1, 3) },    // 2
        { new Sala_Def(1, 2, 1), new Sala_Def(3, 5, 0), new Sala_Def(3, 4, 1), new Sala_Def(2, 5, 0), new Sala_Def(1, 4, 1) },    // 3
        { new Sala_Def(7, 1, 0), new Sala_Def(2, 4, 3), new Sala_Def(3, 4, 2), new Sala_Def(4, 2, 0), new Sala_Def(3, 2, 1) },    // 4
        { new Sala_Def(5, 1, 0), new Sala_Def(3, 2, 0), new Sala_Def(1, 4, 2), new Sala_Def(7, 1, 3), new Sala_Def(6, 1, 3) }, }, // 5
        
        new[,] { //       1                      2                      3                      4                      5
        { new Sala_Def(1, 3, 3), new Sala_Def(3, 4, 1), new Sala_Def(4, 4, 1), new Sala_Def(3, 4, 1), new Sala_Def(1, 3, 2) },    // 1
        { new Sala_Def(6, 1, 1), new Sala_Def(5, 1, 3), new Sala_Def(7, 1, 3), new Sala_Def(2, 2, 0), new Sala_Def(6, 1, 1) },    // 2
        { new Sala_Def(2, 4, 0), new Sala_Def(4, 2, 3), new Sala_Def(3, 4, 1), new Sala_Def(3, 4, 3), new Sala_Def(2, 4, 2) },    // 3
        { new Sala_Def(3, 2, 3), new Sala_Def(7, 1, 1), new Sala_Def(5, 1, 3), new Sala_Def(7, 1, 1), new Sala_Def(3, 2, 3) },    // 4
        { new Sala_Def(1, 4, 0), new Sala_Def(3, 4, 3), new Sala_Def(5, 1, 2), new Sala_Def(3, 3, 3), new Sala_Def(1, 4, 2) }, }, // 5
    };

    #endregion

    public Sala_Def[,] grid = new Sala_Def[nLinhas, nColunas];

    void Awake()
    {
        // Randomizer
        // (aleatoriza qual gride será usada)
        grid = grids[Random.Range(0, grids.Length)];

        // Salas
        // (atribui os prevebs de cada salas à matriz 'obj')
        for (int linha = 0; linha < grid.GetLength(0); linha++)
        {
            for (int coluna = 0; coluna < grid.GetLength(1); coluna++)
            {
                Sala_Def definicao = grid[linha, coluna];

                Vector3 posicaoNoGrid = IndicesCentralizados(linha, coluna);
                Vector3 posicaoNoMundo = PosicaoNoMundo(posicaoNoGrid);

                switch (definicao.Tipo)
                {
                    case Tipo.Saida:
                        switch (definicao.Formato)
                        {
                            case Formato.Linha:
                                Saida_2.Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.L:
                                Saida_3.Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.T:
                                Saida_4.Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                        }
                        break;

                    case Tipo.Vazia:
                        switch (definicao.Formato)
                        {
                            case Formato.Linha:
                                Vazio_2.Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.L:
                                Vazio_3.Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.T:
                                Vazio_4.Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.Cruz:
                                Vazio_5.Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                        }
                        break;

                    case Tipo.Obstaculo:
                        switch (definicao.Formato)
                        {
                            case Formato.Unica:
                                Obsc_1.Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.Linha:
                                Obsc_2.Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.L:
                                Obsc_3.Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.T:

                                //GameObject[] Obsc_4 = { Obsc_4_1, Obsc_4_2 };
                                //obj[i, j] = Obsc_4[Random.Range(0, 2)];

                                // obsc_4
                                switch (Random.Range(1, 3))
                                {
                                    case 1:
                                        Obsc_4_1.Create(definicao, posicaoNoMundo, Quaternion.identity);
                                        break;
                                    case 2:
                                        Obsc_4_2.Create(definicao, posicaoNoMundo, Quaternion.identity);
                                        break;
                                }

                                break;
                            case Formato.Cruz:
                                Obsc_5.Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                        }
                        break;
                    // NPC
                    case Tipo.NPC:
                        switch (definicao.Formato)
                        {
                            case Formato.Linha:
                                NPC_2.Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.L:
                                NPC_3.Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.T:
                                NPC_4.Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                        }
                        break;
                    // Bau
                    case Tipo.Bau:
                        Bau_1.Create(definicao, posicaoNoMundo, Quaternion.identity);
                        break;
                    // Trancada
                    case Tipo.Trancada:
                        Trancada_1.Create(definicao, posicaoNoMundo, Quaternion.identity);
                        break;
                    // Botao
                    case Tipo.Botao:
                        Botao_1.Create(definicao, posicaoNoMundo, Quaternion.identity);
                        break;
                }
            }
        }
    }

    static public Vector3 PosicaoNoGrid(Vector3 posicao)
    => new((int)(posicao.x / DistanciaEntreSalas), (int)(posicao.y / DistanciaEntreSalas), (int)(posicao.z / DistanciaEntreSalas));
    static public Vector3 PosicaoNoMundo(Vector3 posicao)
    => posicao * DistanciaEntreSalas;
    static public Vector3 PosicaoNoMundo(int linha, int coluna)
    => PosicaoNoMundo(new Vector3(linha, 0, coluna));
    static public Vector3 IndicesCentralizados(int linha, int coluna)
    {
        linha -= (nLinhas - 1) / 2;
        coluna -= (nColunas - 1) / 2;

        return new(linha, 0, coluna);
    }
}
