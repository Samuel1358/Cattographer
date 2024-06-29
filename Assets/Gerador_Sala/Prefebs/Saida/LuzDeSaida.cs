using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzDeSaida : MonoBehaviour
{
    [SerializeField] GameObject luz;

    public Vector3 Verificar()
    {
        Vector3 r = Vector3.zero;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f))
        {
            if (hit.collider.gameObject.CompareTag("Parede"))
            {
                luz.SetActive(true);
                r = transform.position;
            }
        }
        return r;
    }
}
