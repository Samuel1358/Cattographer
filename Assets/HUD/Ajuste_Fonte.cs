using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ajuste_Fonte : MonoBehaviour
{
    //public RectTransform canvas;
    Text texto;
    //int tamanhoBase;

    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponent<Text>();
        //tamanhoBase = texto.fontSize;
    }

    // Update is called once per frame
    void Update()
    {
        /*Debug.Log("L: " + texto.rectTransform.rect.width);
        Debug.Log("A: " + texto.rectTransform.rect.height);*/

        texto.fontSize = (int)(texto.rectTransform.rect.height / 1.2f);
        //texto.fontSize = (int)(tamanhoBase * (texto.rectTransform.rect.width * texto.rectTransform.rect.height / 19128));
    }
}
