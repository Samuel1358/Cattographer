using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using UnityEngine;
using static Mov_Inimigo_PassoAPasso;

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

    bool noFundo = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Fundo"))
        {
            noFundo = true;
            gameObject.layer = LayerMask.NameToLayer("Chao");
        }
    }

    public IEnumerator EmpurraoCoroutine(Vector3 direcao)
    {
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

                // Queda no buraco
                if (!Physics.Raycast(new Ray(transform.position, -transform.up), out _, 1f))
                {
                    yield return QuedaCoroutine();
                }
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

        yield return !movimentoObstruido;
    }

    private IEnumerator QuedaCoroutine()
    {
        box.isTrigger = false;
        rb.useGravity = true;

        const float tempoMaximoDaQueda = 4f;

        float timer = tempoMaximoDaQueda;
        while (timer > Time.deltaTime && !noFundo)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
    }
}
