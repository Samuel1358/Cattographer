using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudarLinguagem : MonoBehaviour
{
    [HideInInspector][SerializeField] Seletor_Linguagem seletor;
    int valor;

    private void Start()
    {
        valor = (int)seletor.lingua;
    }

    void AtualizarLinguagem()
    {
        switch (valor)
        {
            case 0:
                seletor.lingua = Seletor_Linguagem.Linguagem.Ingles;
                break;
            case 1:
                seletor.lingua = Seletor_Linguagem.Linguagem.Portugues;
                break;
            case 2:
                seletor.lingua = Seletor_Linguagem.Linguagem.Espanhol;
                break;
            case 3:
                seletor.lingua = Seletor_Linguagem.Linguagem.Italiano;
                break;
            case 4:
                seletor.lingua = Seletor_Linguagem.Linguagem.Frances;
                break;
            case 5:
                seletor.lingua = Seletor_Linguagem.Linguagem.Alemao;
                break;
            case 6:
                seletor.lingua = Seletor_Linguagem.Linguagem.Russo;
                break;
        }
    }

    public void Anterior()
    {
        if (valor > 0)
        {
            valor -= 1;
        }
        else
        {
            valor = 6;
        }
        AtualizarLinguagem();
    }

    public void Proximo()
    {
        if (valor < 5)
        {
            valor += 1;
        }
        else
        {
            valor = 0;
        }
        AtualizarLinguagem();
    }
}
