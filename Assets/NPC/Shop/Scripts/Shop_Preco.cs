using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Preco : MonoBehaviour
{
    Text texto;
    public Item_Shop preco;

    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponent<Text>();
        texto.text = preco.valor.ToString();
    }
}
