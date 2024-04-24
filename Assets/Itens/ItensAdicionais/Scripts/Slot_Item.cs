using System.Collections;
using System.Collections.Generic;
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
    public bool selecionadoControler = false;
    public bool agir = false;
    bool botaoPrecionado = false;

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
                    //@
                    //selecionadoControler = true;
                    lista.listaItens[slot] = 0;
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
