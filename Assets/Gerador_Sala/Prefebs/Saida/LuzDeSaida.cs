using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzDeSaida : MonoBehaviour
{
    [SerializeField] GameObject luz;// braseiro1, braseiro2;
    [SerializeField] GameObject braseiro;
    Braseiro bras1, bras2;


    private void Start()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f))
        {
            if (hit.collider.gameObject.CompareTag("Parede"))
            {
                //braseiro1.SetActive(true);
                //braseiro2.SetActive(true);
                bras1 = Instantiate(braseiro, transform.position - transform.forward - (transform.right * 2), Quaternion.identity, this.transform).GetComponent<Braseiro>();
                bras2 = Instantiate(braseiro, transform.position - transform.forward + (transform.right * 2), Quaternion.identity, this.transform).GetComponent<Braseiro>();
            }
        }
    }

    public Vector3 Verificar()
    {
        Vector3 r = Vector3.zero;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f))
        {
            if (hit.collider.gameObject.CompareTag("Parede"))
            {
                //braseiro1.GetComponent<Braseiro>().Acender();
                //braseiro2.GetComponent<Braseiro>().Acender();
                bras1.Acender();
                bras2.Acender();
                luz.SetActive(true);
                r = transform.position;
            }
        }
        return r;
    }
}
