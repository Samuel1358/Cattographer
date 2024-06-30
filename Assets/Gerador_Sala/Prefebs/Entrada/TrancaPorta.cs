using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrancaPorta : MonoBehaviour
{
    [SerializeField] GameObject parede;

    // Start is called before the first frame update
    void Start()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f))
        {
            if (hit.collider.gameObject.CompareTag("Parede"))
            {
                Instantiate(parede, transform.position, Quaternion.identity);
            }
        }
    }
}
