using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escavavel : MonoBehaviour
{
    [SerializeField] GameObject luz;
    float spd = 0.5f;
    public bool unico = true;

    public void DarSinal()
    {
        transform.GetChild(0).transform.Rotate(0, spd, 0, Space.Self);
        //transform.eulerAngles += Vector3.up * spd;
        //transform.GetChild(0).transform.Translate(0, spd, 0, Space.World);
        if (unico)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            Instantiate(luz, pos, Quaternion.identity).transform.SetParent(this.transform);
            var sinal = transform.GetChild(0).GetComponent<MeshRenderer>().material;
            sinal.color = Color.red;
            unico = false;
        }
        /*else
        {
            var luce = luz.GetComponent<Light>();
            if (luce.)
        }*/
    }
}
