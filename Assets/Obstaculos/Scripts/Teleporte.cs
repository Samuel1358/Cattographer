using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporte : MonoBehaviour
{
    public Teleporte gemeo;
    
    RaycastHit hit;
    public LayerMask bloqueio;

    public bool registro = false;
    public bool ocupado = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(new Ray(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), transform.up), out hit, 1f, bloqueio, QueryTriggerInteraction.Collide))
        {
            registro = true;
            ocupado = true;
        }
        else
        {
            registro = false;
            if (gemeo.registro == false)
            {
                ocupado = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ocupado == false)
        {
            if (Physics.Raycast(new Ray(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), transform.up), out hit, 1f, bloqueio, QueryTriggerInteraction.Collide))
            {
                if (gemeo.ocupado == false)
                {
                    hit.collider.gameObject.transform.position = new Vector3(gemeo.transform.position.x, hit.collider.gameObject.transform.position.y, gemeo.transform.position.z);
                    Gerenciador_Audio.TocarSFX(Gerenciador_Audio.SFX.magic);
                    gemeo.ocupado = true;
                    ocupado = true;
                }
            }
        }
    }
}
