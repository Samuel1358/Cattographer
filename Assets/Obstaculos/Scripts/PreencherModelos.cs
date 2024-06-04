using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PreencherModelos : MonoBehaviour
{
    public GameObject modelo;
    public float altura;

    // Start is called before the first frame update
    void Start()
    {
        int x = (int)Mathf.Ceil(Mathf.Ceil(transform.localScale.x - modelo.transform.localScale.x) / modelo.transform.localScale.x),
            z = (int)Mathf.Ceil(Mathf.Ceil(transform.localScale.z - modelo.transform.localScale.z) / modelo.transform.localScale.z);

        float a, b;

        /*if (altura == null)
        {
            altura = -(transform.localScale.y / 2f);
        }*/

        GameObject instance;

        GameObject cubo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubo.transform.position = new Vector3(0, -10, 0);
        cubo.name = "Modelos";

        for (float i = -(x/2f); i <= x/2f; i += modelo.transform.localScale.x)
        {
            for (float k = -(z / 2f); k <= z / 2f; k += modelo.transform.localScale.z)
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
                instance = Instantiate(modelo, pos, Quaternion.identity, cubo.transform);
                instance.isStatic = true;
            }
        }

        cubo.isStatic = true;
        cubo.transform.SetParent(this.transform);
    }
}
