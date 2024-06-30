using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Slot_Item : MonoBehaviour
{
    Lista_Itens lista; 

    #region // Visual

    Image item;
    Color visivel = new Color(1f, 1f, 1f, 1f);
    Color invisivel = new Color(1f, 1f, 1f, 0f);

    public int slot;

    //public int dir = 1;
    public GameObject selecionado;
    bool selectInfo = false;
    public bool selecionadoControler = false;
    public bool agir = false;
    bool botaoPrecionado = false;

    [SerializeField] Image SetaCima;
    [SerializeField] Image SetaDireita;
    [SerializeField] Image SetaBaixo;
    [SerializeField] Image SetaEsquerda;

    [SerializeField] Sprite bomba;
    [SerializeField] Sprite tabua;
    [SerializeField] Sprite kyrozene;

    #endregion

    #region // Funcional

    Funcao_Itens funcoes;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        lista = FindAnyObjectByType<Lista_Itens>();
        funcoes = FindAnyObjectByType<Funcao_Itens>();

        item = GetComponent<Image>();

        SetaCima.color = invisivel;
        SetaDireita.color = invisivel;
        SetaBaixo.color = invisivel;
        SetaEsquerda.color = invisivel;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(masc.value);
        #region // Icones

        switch (lista.listaItens[slot])
        {
            case 1:
                item.color = visivel;
                item.sprite = bomba;
                break;
            case 2:
                item.color = visivel;
                item.sprite = tabua;
                break;
            case 3:
                item.color = visivel;
                item.sprite = kyrozene;
                break;
            default:
                item.color = invisivel;
                item.sprite = null;
                break;
        }        

        if (selecionadoControler == true)
        {
            selectInfo = true;
            switch (lista.listaItens[slot])
            {
                case 1:
                    SetaCima.color = visivel;
                    SetaDireita.color = visivel;
                    SetaBaixo.color = visivel;
                    SetaEsquerda.color = visivel;

                    SetaCima.sprite = bomba;
                    SetaDireita.sprite = bomba;
                    SetaBaixo.sprite = bomba;
                    SetaEsquerda.sprite = bomba;
                    break;
                case 2:
                    SetaCima.color = visivel;
                    SetaDireita.color = visivel;
                    SetaBaixo.color = visivel;
                    SetaEsquerda.color = visivel;

                    SetaCima.sprite = tabua;
                    SetaDireita.sprite = tabua;
                    SetaBaixo.sprite = tabua;
                    SetaEsquerda.sprite = tabua;
                    break;
                default:
                    SetaCima.color = invisivel;
                    SetaDireita.color = invisivel;
                    SetaBaixo.color = invisivel;
                    SetaEsquerda.color = invisivel;

                    SetaCima.sprite = null;
                    SetaDireita.sprite = null;
                    SetaBaixo.sprite = null;
                    SetaEsquerda.sprite = null;
                    break;
            }
        }
        else if (selectInfo == true)
        {           
            SetaCima.color = invisivel;
            SetaDireita.color = invisivel;
            SetaBaixo.color = invisivel;
            SetaEsquerda.color = invisivel;

            SetaCima.sprite = null;
            SetaDireita.sprite = null;
            SetaBaixo.sprite = null;
            SetaEsquerda.sprite = null;

            selectInfo = false;
        }

        #endregion

        if (selecionadoControler == true && lista.setas == false)
        {
            if (botaoPrecionado == false)
            {
                if (Input.touchCount > 0)
                {
                    selecionadoControler = false;
                    agir = true;
                }
                
            }
        }

        if (lista.agir == true && agir == true)
        {
            switch (lista.listaItens[slot])
            {
                case 1:
                    if (funcoes.VerificarBomba(lista.dir) == true)
                    {
                        funcoes.ColocarBomba(lista.dir);
                        lista.listaItens[slot] = 0;
                    }
                    break;
                case 2:
                    //Debug.Log(funcoes.VerificarTabua(lista.dir));
                    if (funcoes.VerificarTabua(lista.dir, 1) && !funcoes.VerificarTabua(lista.dir, 2))
                    {
                        funcoes.ColocarTabua(lista.dir);
                        lista.listaItens[slot] = 0;
                    }
                    break;
            }
            lista.Selecionado(selecionadoControler);
            lista.agir = false;
            agir = false;
        }

        selecionado.SetActive(selecionadoControler);
        botaoPrecionado = false;
        //lista.Precionado(false);
    }

    public void Acao()
    {
        switch (lista.listaItens[slot])
        {
            case 1:
                //@
                selecionadoControler = true;
                //lista.listaItens[slot] = 0;
                break;
            case 2:
                //@
                selecionadoControler = true;
                //lista.listaItens[slot] = 0;
                break;
            case 3:
                funcoes.Kyrozene();
                lista.listaItens[slot] = 0;
                break;
            default:
                //
                break;
        }
        lista.Selecionado(selecionadoControler);
        botaoPrecionado = true;
    }
}
