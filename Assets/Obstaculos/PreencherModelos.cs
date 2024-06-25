using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PreencherModelos : MonoBehaviour
{
    public enum Modelo
    {
        Parede,
        Chao,
    }

    public Modelo tipo;

    [SerializeField] GameObject modelo;
    public float altura;
    public float escala = 1;
    public float escalaM = 1;

    // Start is called before the first frame update
    void Start()
    {
        switch(tipo)
        {
            case Modelo.Parede:
                modelo = FindObjectOfType<ModelosFase>().parede;
                break;
            case Modelo.Chao:
                modelo = FindObjectOfType<ModelosFase>().chao;
                //var material = GetComponent<MeshRenderer>().material;
                //material.color *= new Vector4(1, 1, 1, 0);
                break;
        }
        

        int x = (int)Mathf.Ceil(Mathf.Ceil((transform.localScale.x * escala) - (modelo.transform.localScale.x * escalaM)) / (modelo.transform.localScale.x * escalaM)),
            z = (int)Mathf.Ceil(Mathf.Ceil((transform.localScale.z * escala) - (modelo.transform.localScale.z * escalaM)) / (modelo.transform.localScale.z * escalaM));

        float a, b;

        /*if (altura == null)
        {
            altura = -(transform.localScale.y / 2f);
        }*/

        GameObject instance;

        //GameObject cubo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cubo.transform.position = new Vector3(0, -10, 0);
        //cubo.name = "Modelos";

        for (float i = -(x/2f); i <= x/2f; i += (modelo.transform.localScale.x * escalaM))
        {
            for (float k = -(z / 2f); k <= z / 2f; k += (modelo.transform.localScale.z * escalaM))
            {
                if (Mathf.Abs(transform.rotation.eulerAngles.y / 90) % 2 == 0)
                {
                    a = i;
                    b = k;
                }
                else
                {
                    a = k;
                    b = i;
                }
                Vector3 pos = new Vector3(transform.position.x + a, transform.position.y + /*(float)*/altura, transform.position.z + b);
                

                switch (tipo)
                {
                    case Modelo.Parede:
                        instance = Instantiate(modelo, pos, Quaternion.Euler(0f, 90 * Random.Range(0, 4), 0f));
                        instance.transform.SetParent(this.transform);
                        instance.isStatic = true;
                        break;
                    case Modelo.Chao:
                        instance = Instantiate(modelo, pos, Quaternion.identity);
                        instance.transform.SetParent(this.transform.parent);
                        instance.isStatic = true;
                        break;
                }
                
            }
        }

        if (tipo == Modelo.Chao)
        {
            Destroy(gameObject);
        }

        //cubo.isStatic = true;
        //cubo.transform.SetParent(this.transform);
    }
}
