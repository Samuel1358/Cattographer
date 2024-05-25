using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensAdicionais : MonoBehaviour
{
    Lista_Itens lista;
    public int tipo;

    public bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        lista = FindAnyObjectByType<Lista_Itens>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            if (other.CompareTag("Player"))
            {
                for (int i = 0; i < lista.listaItens.Length; i++)
                {
                    if (lista.listaItens[i] == 0)
                    {
                        lista.listaItens[i] = tipo;
                        Destroy(gameObject);
                        break;
                    }
                }
            }
        }        
    }
}
