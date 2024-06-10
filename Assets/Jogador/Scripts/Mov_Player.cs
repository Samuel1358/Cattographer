using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Mov_Player : MonoBehaviour
{
    // CONSTANTES
    const float cooldownMovimentacao = 0.16f;
    const float movimentacaoBuffer = cooldownMovimentacao;
    public const float holdTimeMovimentacao = 0.4f;
    const float tempoDaQueda = 1.5f;
    const float tempoDeRespawn = 0.5f;

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

    private float holdTime = 0;
    void Update()
    {
        bool inputCima = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        bool inputDireita = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        bool inputBaixo = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        bool inputEsquerda = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);

        Vector3 movimento = Vector3.zero;
        if (inputCima && !(inputDireita || inputBaixo || inputEsquerda))
        {
            movimento = Vector3.forward;
        }
        else if (inputDireita && !(inputCima || inputBaixo || inputEsquerda))
        {
            movimento = Vector3.right;
        }
        if (inputBaixo && !(inputCima || inputDireita || inputEsquerda))
        {
            movimento = Vector3.back;
        }
        if (inputEsquerda && !(inputCima || inputDireita || inputBaixo))
        {
            movimento = Vector3.left;
        }

        if (inputCima || inputDireita || inputBaixo || inputEsquerda)
        {
            if (movimento != Vector3.zero && (holdTime > holdTimeMovimentacao || holdTime == 0))
            { 
                Movimentar(movimento); 
            }

            holdTime += Time.deltaTime;
        }
        else
        { 
            holdTime = 0; 
        }
    }

    public void Movimentar(Vector3 direcao) => StartCoroutine(MovimentacaoCoroutine(direcao));

    private float cooldownAtualMovimentacao = 0;
    private IEnumerator MovimentacaoCoroutine(Vector3 direcao)
    {
        if (!canMove) yield break;

        // Só permite movimentos dentro de um tempo buffer
        if (cooldownAtualMovimentacao > movimentacaoBuffer) yield break;

        canMove = false;
        // Para tratar o buffer, espera pelo fim do movimento atual
        while (cooldownAtualMovimentacao > 0) yield return null;

        cooldownAtualMovimentacao = cooldownMovimentacao;

        Quaternion rotacao = Quaternion.LookRotation(direcao, Vector3.up);
        transform.rotation = rotacao;

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
                    movimentoObstruido = bloco.MovimentoObstruido(direcao);

                    StartCoroutine(bloco.EmpurraoCoroutine(direcao));
                    yield return null;
                }
                else if (obstaculo.collider.CompareTag("Bau"))
                {
                    Bau_Radomizer bau = obstaculo.collider.GetComponent<Bau_Radomizer>();
                    yield return bau.AbrirCoroutine(direcao);

                    movimentoObstruido = true;
                }
            }

            // Se não for obstruído, movimenta
            if (!movimentoObstruido)
            {
                transform.position += direcao;

                // Queda no buraco
                RaycastHit[] abaixo = Physics.RaycastAll(transform.position, -transform.up, 1f);
                if (!abaixo.Any(hit => false // false só existe pras linhas de baixo ficarem alinhadas
                    || hit.collider.gameObject.layer == LayerMask.NameToLayer("Chao")
                    || hit.collider.gameObject.layer == LayerMask.NameToLayer("Bloqueio")))
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

        while (cooldownAtualMovimentacao > Time.deltaTime)
        {
            cooldownAtualMovimentacao -= Time.deltaTime;
            yield return null;
        }
        cooldownAtualMovimentacao = 0f;
        canMove = true;
    }

    private IEnumerator QuedaCoroutine()
    {
        yield return new WaitForSeconds(tempoDaQueda);

        yield return Sala_Controller.RespawnPlayerCoroutine();
    }

    public IEnumerator SpawnCoroutine(Vector3 posicao)
    {
        transform.position = posicao;
        Camera_Player.Reposicionar(transform.position);

        yield return new WaitForSeconds(tempoDeRespawn);
    }
}
