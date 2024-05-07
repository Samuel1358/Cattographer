using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Saidas_Ativador : MonoBehaviour
{
    public Sala_Controller controller;

    RaycastHit hit;
    public LayerMask bloqueio;
    float timerDestruir = 10f, ttDestruir;

    // Start is called before the first frame update
    void Start()
    {
        ttDestruir = timerDestruir;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), -transform.up, Color.red, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        // (verifica se o player entrou por esta porta)
        if (other.CompareTag("Player"))
        {
            Sala_Controller.SetUltimaPorta(this);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Physics.Raycast(new Ray(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), -transform.up), out hit, 1f, bloqueio, QueryTriggerInteraction.Collide))
        {
            if (timerDestruir <= 0)
            {
                Destroy(hit.collider.gameObject);
                timerDestruir = ttDestruir;
            }
            if (timerDestruir > 0)
            {
                timerDestruir -= Time.deltaTime;
            }
        }
        else
        {
            timerDestruir = ttDestruir;
        }
    }
}
