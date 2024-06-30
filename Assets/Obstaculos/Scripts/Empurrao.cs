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
    public LayerMask bloqueio;
    public LayerMask chao;
    //public Vector3 x = new Vector3(0, 0, 0);

    // QUEDA
    Rigidbody rb;
    Collider box;
    bool noFundo = false;
    [HideInInspector] public bool caindo = false;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Fundo"))
        {
            noFundo = true;
            caindo = false;
            gameObject.layer = LayerMask.NameToLayer("Chao");
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    public bool MovimentoObstruido(Vector3 direcao)
    {
        if (caindo || pulando) return true;

        if (Physics.Raycast(
            ray: new Ray(transform.position, direcao),
            hitInfo: out RaycastHit obstaculo,
            maxDistance: 1f,
            layerMask: bloqueio,
            QueryTriggerInteraction.Collide
        ))
        {
            if (obstaculo.collider.TryGetComponent(out Chester chester))
            { return !chester.IsIndefeso; }

            return true;
        }

        return false;
    }
    public IEnumerator EmpurraoCoroutine(Vector3 direcao)
    {
        bool movimentoObstruido;
        // Loop para caso o piso seja de gelo
        do
        {
            // Verifica se tem um obstáculo
            movimentoObstruido = MovimentoObstruido(direcao);

            // Se não tiver, movimenta o bloco
            if (!movimentoObstruido)
            {
                Gerenciador_Audio.TocarSFX(Gerenciador_Audio.SFX.slide);
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
        caindo = true;

        box.isTrigger = false;
        rb.useGravity = true;

        const float tempoMaximoDaQueda = 4f;

        Gerenciador_Audio.TocarSFX(Gerenciador_Audio.SFX.fall);

        float timer = tempoMaximoDaQueda;
        while (timer > Time.deltaTime && !noFundo)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        caindo = false;
    }

    public void Queda()
    {
        if (caindo || noFundo) return;
        RaycastHit hit;
        if (Physics.Raycast(new Ray(transform.position, -transform.up), out hit, 23f))
        {
            if (hit.collider.gameObject.CompareTag("Fundo") || hit.collider.gameObject.CompareTag("Freckles"))
            {
                Gerenciador_Audio.TocarSFX(Gerenciador_Audio.SFX.fall);

                caindo = true;
                box.isTrigger = false;
                rb.useGravity = true;
            } 
        }
    }

    bool pulando = false;
    public void Pula(Vector3 offset, float altura, float tempo)
    {
        if (!pulando)
        { StartCoroutine(PuloCoroutine(Utilitarios.IgnoreY(offset), altura, tempo)); }
    }

    private IEnumerator PuloCoroutine(Vector3 offset, float altura, float tempo)
    {
        pulando = true;
        yield return Utilitarios.Parabola(gameObject, transform.position + offset, altura, tempo);
        pulando = false;
    }
}
