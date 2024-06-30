using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporte : MonoBehaviour
{
    public Teleporte gemeo;
    ParticleSystem efeito;
    
    RaycastHit hit;
    public LayerMask bloqueio;

    public bool registro = false;
    public bool ocupado = false;

    // Start is called before the first frame update
    void Start()
    {
        efeito = transform.GetChild(2).GetComponent<ParticleSystem>();
        if (ColorUtility.TryParseHtmlString(transform.GetChild(1).GetComponent<SetEmissão>().hex, out Color cor))
        {
            #pragma warning disable CS0618 // O tipo ou membro é obsoleto
            efeito.startColor = cor - (new Color(1, 1, 1, 0) * 0.1f);
        }
        
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
                    efeito.Play();
                    gemeo.ocupado = true;
                    ocupado = true;
                }
            }
        }
    }
}
