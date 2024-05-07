using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Mov_Player : MonoBehaviour
{
    // MOVE
    //Rigidbody rb;
    //private float spd = 1f;
    public bool canMove = true;

    // RAY
    public LayerMask bloqueio;
    public LayerMask fundo;
    public LayerMask chao;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        Sala_Controller.SetPlayer(this);
    }

    void Update()
    {
        float inputEixoZ = Input.GetAxisRaw("Vertical");
        float inputEixoX = Input.GetAxisRaw("Horizontal");

        if (inputEixoZ != 0 && inputEixoX == 0)
        { Movimentar(Vector3.forward * inputEixoZ); }
        else if (inputEixoX != 0 && inputEixoZ == 0)
        { Movimentar(Vector3.right * inputEixoX); }
    }

    public void Movimentar(Vector3 direcao)
    {
        if (!canMove) return;

        Quaternion rotacao = Quaternion.LookRotation(direcao, Vector3.up);
        transform.rotation = rotacao;

        StartCoroutine(MovimentacaoCoroutine(direcao));
    }

    private IEnumerator MovimentacaoCoroutine(Vector3 direcao)
    {
        canMove = false;

        // Força a direção a ter magnitude 1
        direcao.Normalize();

        // Começa assumindo que o movimento não está obstruído
        bool movimentoObstruido = false;

        // Loop para caso o piso seja de gelo
        do
        {
            // Verifica se existe um obstáculo na direção do movimento, uma casa a frente
            if (Physics.Raycast(
                ray: new Ray(transform.position, direcao),
                hitInfo: out RaycastHit obstaculo,
                maxDistance: 1f,
                layerMask: bloqueio,
                QueryTriggerInteraction.Collide
            ))
            {
                // Se for uma parede, só obstrui o movimento
                if (obstaculo.collider.CompareTag("Parede"))
                {
                    movimentoObstruido = true;
                }
                // Se for um bloco, tenta empurrá-lo
                else if (obstaculo.collider.CompareTag("Empurravel"))
                {
                    Empurrao bloco = obstaculo.collider.GetComponent<Empurrao>();
                    yield return bloco.EmpurraoCoroutine(direcao);

                    movimentoObstruido = true;
                }
            }

            // Se não for obstruído, movimenta
            if (!movimentoObstruido)
            {
                transform.position += direcao;

                // Queda no buraco
                RaycastHit[] abaixo = Physics.RaycastAll(transform.position, -transform.up, 1f);
                if (!abaixo.Any(hit => hit.collider.gameObject.layer == LayerMask.NameToLayer("Chao")))
                {
                    yield return QuedaCoroutine();
                }
            }

            yield return null;

        } while (
            // Repete enquanto o piso for de gelo e se o movimento não estiver obstruído
            Physics.Raycast(
                ray: new Ray(transform.position, -transform.up),
                hitInfo: out RaycastHit piso,
                maxDistance: 1f,
                layerMask: chao,
                QueryTriggerInteraction.Collide
            ) && piso.collider.CompareTag("Gelo")
            && !movimentoObstruido
        );

        const float cooldownMovimentacao = 0.16f;
        yield return new WaitForSeconds(cooldownMovimentacao);
        canMove = true;
    }

    private IEnumerator QuedaCoroutine()
    {
        const float tempoDaQueda = 1.5f;
        yield return new WaitForSeconds(tempoDaQueda);

        Sala_Controller.RespawnPlayer();

        const float tempoDeRespawn = 0.5f;
        yield return new WaitForSeconds(tempoDeRespawn);
    }
}
