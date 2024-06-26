using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComoJogar : MonoBehaviour
{
    [SerializeField] GameObject[] paineis;
    int pagina = 0;

    public void AtualizarPagina()
    {
        for (int i = 0; i < paineis.Length; i++)
        {
            if (i == pagina)
            {
                paineis[i].SetActive(true);
            }
            else
            {
                paineis[i].SetActive(false);
            }
        }
    }

    public void Anterior()
    {
        if (pagina > 0)
        {
            pagina -= 1;
        }
        AtualizarPagina();
    }

    public void Proximo()
    {
        if (pagina < paineis.Length - 1)
        {
            pagina += 1;
        }
        AtualizarPagina();
    }
}
