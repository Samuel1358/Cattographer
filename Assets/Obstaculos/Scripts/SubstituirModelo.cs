using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstituirModelo : MonoBehaviour
{
    [SerializeField] GameObject modelo;
    public float altura;

    // Start is called before the first frame update
    void Start()
    {
        switch (Random.Range(0, 2))
        {
            case 0:
                modelo = FindObjectOfType<ModelosFase>().bloco1;
                break;
            case 1:
                modelo = FindObjectOfType<ModelosFase>().bloco2;
                break;
        }        

        GameObject instance;

        // tirar ao concertar o modelo da estante
        modelo.transform.localScale = new Vector3(1, 1.5f, 1);

        Vector3 pos = new Vector3(transform.position.x, transform.position.y + altura, transform.position.z);
        instance = Instantiate(modelo, pos, Quaternion.identity, this.transform);        
        instance.isStatic = true;
    }
}
