using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using UnityEngine;

public class Empurrao : MonoBehaviour
{

    Mov_Player player;

    RaycastHit hit;
    public LayerMask bloqueio;
    public LayerMask chao;
    //public Vector3 x = new Vector3(0, 0, 0);

    // QUEDA
    Rigidbody rb;
    Collider box;

    bool caindo = false;

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
        // (gravidade é ativada quando empurado para um buraco)
        if (other.CompareTag("Buraco"))
        {
            //player.canMove = false;
            if (Physics.Raycast(new Ray(transform.position, Vector2.down), out _, 1f, bloqueio, QueryTriggerInteraction.Collide))
            {
                //player.canMove = true;
            }
            else
            {
                caindo = true;
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
            //box.isTrigger = true;
            //rb.useGravity = false;
            gameObject.layer = LayerMask.NameToLayer("Chao");
            player.canMove = true;
        }
    }

    public bool Empurrar(Vector3 direcao)
    {
        if (caindo)
        {
            return false;
        }
        bool empurrou = false;

        bool movimentoObstruido;
        // Loop para caso o piso seja de gelo
        do
        {
            // Verifica se tem um obstáculo
            movimentoObstruido = Physics.Raycast(
                ray: new Ray(transform.position, direcao),
                // hitInfo: out RaycastHit obstaculo,
                maxDistance: 1f,
                layerMask: bloqueio,
                QueryTriggerInteraction.Collide
            );

            // Se não tiver, movimenta o bloco
            if (!movimentoObstruido)
            {
                transform.position += direcao;
                // Marca que empurrou com sucesso
                empurrou = true;
            }

        } while (
            // Repete enquanto o piso for de gelo e o movimento não estiver obstruído
            Physics.Raycast(
                ray: new Ray(transform.position, -transform.up),
                hitInfo: out RaycastHit piso,
                maxDistance: 1f,
                layerMask: chao,
                QueryTriggerInteraction.Collide
            ) && piso.collider.CompareTag("Gelo")
            && !movimentoObstruido
        );

        // Retorna se empurrou o bloco com sucesso
        return empurrou;
    }
}
