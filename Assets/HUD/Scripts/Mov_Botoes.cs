using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_Botoes : MonoBehaviour
{
    Mov_Player player;
    Lista_Itens itens;

    [SerializeField] private Mov_Botao botaoCima;
    [SerializeField] private Mov_Botao botaoDireita;
    [SerializeField] private Mov_Botao botaoBaixo;
    [SerializeField] private Mov_Botao botaoEsquerda;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Mov_Player>();
        itens = FindObjectOfType<Lista_Itens>();
    }

    private float holdTime = 0;
    void Update()
    {
        itens.Precionado(false);

        bool inputCima = botaoCima.IsPressionado;
        bool inputDireita = botaoDireita.IsPressionado;
        bool inputBaixo = botaoBaixo.IsPressionado;
        bool inputEsquerda = botaoEsquerda.IsPressionado;

        if (inputCima || inputDireita || inputBaixo || inputEsquerda)
        {
            if (holdTime > Mov_Player.holdTimeMovimentacao || holdTime == 0)
            {
                if (inputCima && !(inputDireita || inputBaixo || inputEsquerda))
                { Cima(); }
                else if (inputDireita && !(inputCima || inputBaixo || inputEsquerda))
                { Direita(); }
                if (inputBaixo && !(inputCima || inputDireita || inputEsquerda))
                { Baixo(); }
                if (inputEsquerda && !(inputCima || inputDireita || inputBaixo))
                { Esquerda(); }
            }

            holdTime += Time.deltaTime;
        }
        else
        { holdTime = 0; }
    }

    public void Cima()
    {
        itens.Precionado(true);
        if (itens.selecionado == false)
        {
            player.Movimentar(Vector3.forward);
        }
        else
        {
            itens.dir = 1;
            itens.agir = true;
        }
    }
    public void Direita()
    {
        itens.Precionado(true);
        if (itens.selecionado == false)
        {
            player.Movimentar(Vector3.right);
        }
        else
        {
            itens.dir = 2;
            itens.agir = true;
        }
    }
    public void Baixo()
    {
        itens.Precionado(true);
        if (itens.selecionado == false)
        {
            player.Movimentar(Vector3.back);
        }
        else
        {
            itens.dir = 3;
            itens.agir = true;
        }
    }
    public void Esquerda()
    {
        itens.Precionado(true);
        if (itens.selecionado == false)
        {
            player.Movimentar(Vector3.left);
        }
        else
        {
            itens.dir = 4;
            itens.agir = true;
        }
    }
}
