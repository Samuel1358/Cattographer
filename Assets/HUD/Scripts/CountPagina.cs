using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountPagina : MonoBehaviour
{
    [SerializeField] PassarPagina passarPagina;
    Text texto;

    private void Start()
    {
        texto = GetComponent<Text>();        
    }

    private void Update()
    {
        texto.text = (passarPagina.GetPagina() + 1).ToString() + " / " + passarPagina.GetPaineis().Length.ToString();
    }
}
