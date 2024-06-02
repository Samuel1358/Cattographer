using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Shop : MonoBehaviour
{
    public enum Tipo
    {
        ItemGerais,
        Chave
    }

    public Tipo tipo;
    public int valor;

    ItensAdicionais itensGerais;
    Item_Chave chave;

    Player_Final player;

    // Start is called before the first frame update
    void Start()
    {
        switch (tipo)
        {
            case Tipo.ItemGerais:
                itensGerais = GetComponent<ItensAdicionais>();
                break;
            case Tipo.Chave:
                chave = GetComponent<Item_Chave>();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player_Final>();
        }

        if (player.moedas >= valor)
        {
            Ativar();
        }
        else
        {
            Desativar();
        }
    }

    // Ativar
    private void Ativar()
    {
        if (itensGerais != null)
        {
            itensGerais.active = true;
        }

        if (chave != null)
        {
            chave.active = true;
        }
    }

    // Desativar
    private void Desativar()
    {
        if (itensGerais != null)
        {
            itensGerais.active = false;
        }

        if (chave != null)
        {
            chave.active = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.moedas >= valor)
        {
            if (other.CompareTag("Player"))
            {
                player.moedas -= valor;
            }
        }
    }
}
