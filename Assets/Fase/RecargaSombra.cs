using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecargaSombra : MonoBehaviour
{
    Count_RecargaSombra recarga;

    public enum Acao
    {
        Apoio,
        Start,
        CollisionTrigger,
        ItensMultiplos,
        Passagem,
    }

    public Acao acao;
    private bool unico = true;

    public RecargaSombra[] lista;

    // Start is called before the first frame update
    void Start()
    {
        recarga = FindObjectOfType<Count_RecargaSombra>();

        if (acao == Acao.Start && unico)
        {
            recarga.ConcluirSala();
            //Debug.Log(gameObject.name + " " + acao);
            unico = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (acao == Acao.CollisionTrigger && unico)
            {
                recarga.ConcluirSala();
                //Debug.Log(gameObject.name + " " + acao);
                unico = false;
            }

            if (acao == Acao.ItensMultiplos && unico)
            {
                recarga.ConcluirSala();
                //Debug.Log(gameObject.name + " " + acao);
                if (lista.Length > 0)
                {
                    for (int i = 0; i < lista.Length; i++)
                    {
                        lista[i].Desativar();
                    }
                }
                unico = false;
            }

            if (acao == Acao.Passagem && unico)
            {
                if (lista[0] == null)
                {
                    lista[0] = this;
                    if (lista.Length > 0)
                    {
                        for (int i = 1; i < lista.Length; i++)
                        {
                            lista[i].lista[0] = this;
                        }
                    }
                }
                else
                {
                    if (lista[0] != this)
                    {
                        recarga.ConcluirSala();
                        //Debug.Log(gameObject.name + " " + acao);
                        if (lista.Length > 0)
                        {
                            for (int i = 1; i < lista.Length; i++)
                            {
                                lista[i].Desativar();
                            }
                        }
                        unico = false;
                    }
                }
            }
        }
    }

    public void Desativar()
    {
        unico = false;
    }
}
