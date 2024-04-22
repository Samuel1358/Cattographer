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
    }

    public void Acao()
    {
        switch (lista.listaItens[slot])
        {
            case 1:
                //@
                lista.listaItens[slot] = 0;
                break;
            case 2:
                //@
                lista.listaItens[slot] = 0;
                break;
            case 3:
                funcoes.Kyrozene();
                lista.listaItens[slot] = 0;
                break;
            default:
                //
                break;
        }
    }
}
