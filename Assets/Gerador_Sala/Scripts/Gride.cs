using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UIElements;

public class Gride : MonoBehaviour
{
    Gerenciador_Fase fase;

    public const int nLinhas = 4;
    public const int nColunas = 3;

    public const float DistanciaEntreSalas = 11f;

    [SerializeField] int[] idGrids = new int[4];

    public enum Tipo
    {
        Entrada = 1, // Entrada
        Vazia = 2,
        Obstaculo = 3,
        Bau = 4,
        NPC = 5,
        Unica = 6, // Sala Trancada + Shop
        Botao = 7,
        Saida = 8,
        Secreto = 9,
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

    // Entrada
    public Entrada entradas;
    [System.Serializable]
    public class Entrada
    {
        public Sala_Prefab[] Entrada_2;
        public Sala_Prefab[] Entrada_3;
        public Sala_Prefab[] Entrada_4;
    }

    // Vazio
    public Vazio vazios;
    [System.Serializable]
    public class Vazio
    {
        public Sala_Prefab[] Vazio_2;
        public Sala_Prefab[] Vazio_3;
        public Sala_Prefab[] Vazio_4;
        public Sala_Prefab[] Vazio_5;
    }

    // Obstáculo
    public Obstaculo obstaculos;
    [System.Serializable]
    public class Obstaculo
    {
        public Sala_Prefab[] Obstaculo_2;
        public Sala_Prefab[] Obstaculo_3;
        public Sala_Prefab[] Obstaculo_4;
        public Sala_Prefab[] Obstaculo_5;
    }

    // Baú
    public Bau baus;
    [System.Serializable]
    public class Bau
    {
        public Sala_Prefab[] Bau_1;
    }

    // NPC
    public NPC npcs;
    [System.Serializable]
    public class NPC
    {
        public Sala_Prefab[] NPC_2;
        public Sala_Prefab[] NPC_3;
        public Sala_Prefab[] NPC_4;
    }

    // Unica
    public Unica unicas;
    [System.Serializable]
    public class Unica
    {
        public Sala_Prefab[] NPC_1;
        public Sala_Prefab[] Trancada_1;
    }

    // Botão
    public Botao botoes;
    [System.Serializable]
    public class Botao
    {
        public Sala_Prefab[] Botao_1;
    }

    // Saída
    public Saida saidas;
    [System.Serializable]
    public class Saida
    {
        public Sala_Prefab[] Saida_2;
        public Sala_Prefab[] Saida_3;
        public Sala_Prefab[] Saida_4;
    }

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
        // 0
        new[,] { //       1                      2                      3              
        { new Sala_Def(3, 3, 1), new Sala_Def(3, 4, 2), new Sala_Def(4, 1, 3) },    // 1
        { new Sala_Def(8, 3, 3), new Sala_Def(2, 2, 1), new Sala_Def(6, 1, 2) },    // 2
        { new Sala_Def(5, 3, 1), new Sala_Def(3, 5, 0), new Sala_Def(3, 4, 3) },    // 3
        { new Sala_Def(4, 1, 0), new Sala_Def(1, 2, 1), new Sala_Def(7, 1, 0) }, }, // 4

        // 1
        new[,] { //       1                      2                      3              
        { new Sala_Def(4, 1, 2), new Sala_Def(3, 3, 1), new Sala_Def(4, 1, 3) },    // 1
        { new Sala_Def(3, 4, 1), new Sala_Def(3, 5, 0), new Sala_Def(8, 2, 0) },    // 2
        { new Sala_Def(5, 2, 1), new Sala_Def(2, 4, 1), new Sala_Def(3, 3, 2) },    // 3
        { new Sala_Def(7, 1, 0), new Sala_Def(6, 1, 0), new Sala_Def(1, 2, 1) }, }, // 4

        // 2
        new[,] { //       1                      2                      3              
        { new Sala_Def(8, 2, 1), new Sala_Def(4, 1, 1), new Sala_Def(3, 3, 2) },    // 1
        { new Sala_Def(3, 2, 1), new Sala_Def(7, 1, 1), new Sala_Def(5, 4, 3) },    // 2
        { new Sala_Def(3, 4, 1), new Sala_Def(2, 4, 2), new Sala_Def(3, 4, 3) },    // 3
        { new Sala_Def(4, 1, 0), new Sala_Def(1, 2, 1), new Sala_Def(6, 1, 0) }, }, // 4

        // 3
        new[,] { //       1                      2                      3              
        { new Sala_Def(3, 3, 1), new Sala_Def(8, 3, 3), new Sala_Def(4, 1, 2) },    // 1
        { new Sala_Def(3, 4, 1), new Sala_Def(6, 1, 3), new Sala_Def(5, 2, 1) },    // 2
        { new Sala_Def(3, 4, 1), new Sala_Def(3, 4, 2), new Sala_Def(2, 4, 3) },    // 3
        { new Sala_Def(1, 2, 1), new Sala_Def(4, 1, 0), new Sala_Def(7, 1, 0) }, }, // 4

        // 4
        new[,] { //       1                      2                      3              
        { new Sala_Def(6, 1, 1), new Sala_Def(3, 4, 2), new Sala_Def(3, 3, 2) },    // 1
        { new Sala_Def(4, 1, 1), new Sala_Def(2, 4, 3), new Sala_Def(8, 3, 0) },    // 2
        { new Sala_Def(1, 4, 2), new Sala_Def(3, 5, 0), new Sala_Def(4, 1, 3) },    // 3
        { new Sala_Def(3, 3, 0), new Sala_Def(5, 4, 0), new Sala_Def(7, 1, 3) }, }, // 4

        // 5
        new[,] { //       1                      2                      3              
        { new Sala_Def(8, 2, 1), new Sala_Def(6, 1, 2), new Sala_Def(4, 1, 2) },    // 1
        { new Sala_Def(2, 4, 1), new Sala_Def(3, 4, 0), new Sala_Def(3, 3, 3) },    // 2
        { new Sala_Def(3, 4, 1), new Sala_Def(3, 4, 2), new Sala_Def(1, 2, 0) },    // 3
        { new Sala_Def(4, 1, 0), new Sala_Def(5, 3, 0), new Sala_Def(7, 1, 3) }, }, // 4

        // 6
        new[,] { //       1                      2                      3              
        { new Sala_Def(6, 1, 1), new Sala_Def(3, 4, 2), new Sala_Def(4, 1, 3) },    // 1
        { new Sala_Def(8, 2, 0), new Sala_Def(2, 4, 0), new Sala_Def(3, 3, 2) },    // 2
        { new Sala_Def(1, 2, 0), new Sala_Def(3, 4, 2), new Sala_Def(3, 4, 3) },    // 3
        { new Sala_Def(4, 1, 1), new Sala_Def(5, 3, 3), new Sala_Def(7, 1, 0) }, }, // 4

        // 7
        new[,] { //       1                      2                      3              
        { new Sala_Def(6, 1, 1), new Sala_Def(3, 4, 2), new Sala_Def(8, 3, 3) },    // 1
        { new Sala_Def(7, 1, 2), new Sala_Def(2, 4, 1), new Sala_Def(4, 1, 3) },    // 2
        { new Sala_Def(3, 3, 0), new Sala_Def(3, 5, 0), new Sala_Def(3, 3 ,2) },    // 3
        { new Sala_Def(1, 3, 1), new Sala_Def(5, 3, 3), new Sala_Def(4, 1, 0) }, }, // 4



        /*
               
        */

        /*
        new[,] { //       1                      2                      3              
        { new Sala_Def(, , ), new Sala_Def(, , ), new Sala_Def(, , ) },    // 1
        { new Sala_Def(, , ), new Sala_Def(, , ), new Sala_Def(, , ) },    // 2
        { new Sala_Def(, , ), new Sala_Def(, , ), new Sala_Def(, , ) },    // 3
        { new Sala_Def(, , ), new Sala_Def(, , ), new Sala_Def(, , ) }, }, // 4
        */

        // dedsculpa gatinho juro nao mexer mais no gride <3
    };

    #endregion

    public Sala_Def[,] grid = new Sala_Def[nLinhas, nColunas];


    // Shop NPC
    /*bool shopSetted = false;
    int countNPC = 0;*/

    public GameObject ShopKeeper1;

    void Awake()
    {
        fase = FindObjectOfType<Gerenciador_Fase>();

        // Randomizer
        // (aleatoriza qual gride será usada)
        grid = grids[idGrids[Random.Range(0, idGrids.Length)]];

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
                    case Tipo.Entrada:
                        switch (definicao.Formato)
                        {
                            case Formato.Linha:
                                entradas.Entrada_2[Random.Range(0, entradas.Entrada_2.Length)].Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.L:
                                entradas.Entrada_3[Random.Range(0, entradas.Entrada_3.Length)].Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.T:
                                entradas.Entrada_4[Random.Range(0, entradas.Entrada_4.Length)].Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                        }
                        break;

                    case Tipo.Vazia:
                        switch (definicao.Formato)
                        {
                            case Formato.Linha:
                                vazios.Vazio_2[Random.Range(0, vazios.Vazio_2.Length)].Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.L:
                                vazios.Vazio_3[Random.Range(0, vazios.Vazio_3.Length)].Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.T:
                                vazios.Vazio_4[Random.Range(0, vazios.Vazio_4.Length)].Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.Cruz:
                                vazios.Vazio_5[Random.Range(0, vazios.Vazio_5.Length)].Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                        }
                        break;

                    case Tipo.Obstaculo:
                        switch (definicao.Formato)
                        {
                            case Formato.Linha:
                                obstaculos.Obstaculo_2[Random.Range(0, obstaculos.Obstaculo_2.Length)].Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.L:
                                obstaculos.Obstaculo_3[Random.Range(0, obstaculos.Obstaculo_3.Length)].Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.T:
                                obstaculos.Obstaculo_4[Random.Range(0, obstaculos.Obstaculo_4.Length)].Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.Cruz:
                                obstaculos.Obstaculo_5[Random.Range(0, obstaculos.Obstaculo_5.Length)].Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                        }
                        break;
                    // NPC
                    case Tipo.Bau:
                        baus.Bau_1[Random.Range(0, baus.Bau_1.Length)].Create(definicao, posicaoNoMundo, Quaternion.identity);
                        break;
                    // Bau
                    case Tipo.NPC:
                        switch (definicao.Formato)
                        {
                            case Formato.Linha:
                                npcs.NPC_2[Random.Range(0, npcs.NPC_2.Length)].Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.L:
                                npcs.NPC_3[Random.Range(0, npcs.NPC_3.Length)].Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.T:
                                npcs.NPC_4[Random.Range(0, npcs.NPC_4.Length)].Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                        }
                        break;
                    // Trancada
                    case Tipo.Unica:
                        switch (fase.boss)
                        {
                            case true:
                                unicas.Trancada_1[Random.Range(0, unicas.Trancada_1.Length)].Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case false:
                                unicas.NPC_1[Random.Range(0, unicas.NPC_1.Length)].Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                        }                       
                        break;
                    // Botao
                    case Tipo.Botao:
                        botoes.Botao_1[Random.Range(0, botoes.Botao_1.Length)].Create(definicao, posicaoNoMundo, Quaternion.identity);
                        break;
                    // Saida
                    case Tipo.Saida:
                        switch (definicao.Formato)
                        {
                            case Formato.Linha:
                                saidas.Saida_2[Random.Range(0, saidas.Saida_2.Length)].Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.L:
                                saidas.Saida_3[Random.Range(0, saidas.Saida_3.Length)].Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                            case Formato.T:
                                saidas.Saida_4[Random.Range(0, saidas.Saida_4.Length)].Create(definicao, posicaoNoMundo, Quaternion.identity);
                                break;
                        }
                        break;
                }
            }
        }
    }

    static public Vector3 PosicaoNoGrid(Vector3 posicao)
    => new(Mathf.Round(posicao.x / DistanciaEntreSalas), Mathf.Round(posicao.y / DistanciaEntreSalas), Mathf.Round(posicao.z / DistanciaEntreSalas));
    static public Vector3 PosicaoNoMundo(Vector3 posicao)
    => posicao * DistanciaEntreSalas;
    static public Vector3 PosicaoNoMundo(int linha, int coluna)
    => PosicaoNoMundo(new Vector3(coluna, 0, linha));
    static public Vector3 IndicesCentralizados(int linha, int coluna)
    {
        linha = (nLinhas - 1) / 2 - linha;
        coluna -= (nColunas - 1) / 2;

        return new(coluna, 0, linha);
    }
}
