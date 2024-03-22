using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Empurrao : MonoBehaviour
{

    Mov_Player player;

    RaycastHit hit;
    public LayerMask mask;
    public bool verifique = false;
    public Vector3 x = new Vector3(0, 0, 0);

    // QUEDA
    Rigidbody rb;
    Collider box;

    private void Awake()
    {
        player = FindObjectOfType<Mov_Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // (se o bloco estiver orientado à horizontal seu movimento fica bugado)
        // (e ser instanciado junto com o prefeb da sala acaba mudando sua orientação)
        // (para evitar bugs, devido a isso, sempre que é instanciado automaticamente vira para cima)
        Quaternion dir = Quaternion.Euler(0f, 0f, 0f);
        transform.rotation = dir;

        rb = GetComponent<Rigidbody>();
        box = GetComponent<Collider>();
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (player != null)
        {
            if (other.CompareTag("Player"))
            {
                // (verifica se há algo bloquiando o caminho)
                if (Physics.Raycast(new Ray(transform.position, player.transform.forward), out hit, 1f, mask, QueryTriggerInteraction.Collide))
                {

                }
                else
                {
                    verifique = true;
                    x = player.transform.forward;
                    transform.Translate(player.transform.forward);
                }               
            }
        }

        // (gravidade é ativada quando empurado para um buraco)
        if (other.CompareTag("Buraco"))
        {
            if (Physics.Raycast(new Ray(transform.position, Vector2.down), out hit, 1f, mask, QueryTriggerInteraction.Collide))
            {

            }
            else
            {
                box.isTrigger = false;
                rb.useGravity = true;
                player.canMove = false;
            }            
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fundo"))
        {
            //box.isTrigger = false;
            player.canMove = true;
        }
    }

}
