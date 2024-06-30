using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Tradutor : MonoBehaviour
{
    [SerializeField] Seletor_Linguagem seletor;

    Text texto;
    public string[] traducoes = new string[1] { "" };

    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponent<Text>();
        AtualizarTexto();
    }

    private void Update()
    {
        AtualizarTexto();
    }

    public void AtualizarTexto()
    {
        if (traducoes.Length - 1 >= (int)seletor.lingua)
        {
            texto.text = traducoes[(int)seletor.lingua];
        }
        else
        {
            texto.text = traducoes[0];
        }
    }
}
