using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzDeSaida : MonoBehaviour
{
    [SerializeField] GameObject luz, parede;
    [SerializeField] GameObject braseiro;
    GameObject bras1, bras2;


    private void Start()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f))
        {
            if (hit.collider.gameObject.CompareTag("Parede"))
            {
                //braseiro1.SetActive(true);
                //braseiro2.SetActive(true);
                parede = Instantiate(parede, transform.position, Quaternion.identity, this.transform);
                bras1 = Instantiate(braseiro, transform.position - transform.forward - (transform.right * 2), Quaternion.identity, this.transform);
                bras2 = Instantiate(braseiro, transform.position - transform.forward + (transform.right * 2), Quaternion.identity, this.transform);
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

                Destroy(parede);
                bras1.GetComponent<Braseiro>().Acender();
                bras2.GetComponent<Braseiro>().Acender();
                
                luz.SetActive(true);
                r = transform.position;
            }
        }
        return r;
    }
}
