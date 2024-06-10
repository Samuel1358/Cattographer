using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freckles_Hit : MonoBehaviour
{
    Freckles_Escavar escavar;
    public int hits;

    // Start is called before the first frame update
    void Start()
    {
        escavar = GetComponent<Freckles_Escavar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hits >= 3)
        {
            escavar.estado = 7;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Empurravel"))
        {
            hits += 1;
            escavar.estado = 6;
            escavar.AjusteAtordoado();
            Destroy(other.gameObject);
        }
    }
}
