using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chester : MonoBehaviour
{
    [SerializeField] private Sala_Controller controller;
    [SerializeField] private Animator animator;

    [SerializeField] private int vida = 3;

    [SerializeField] private float tempoInicioBatalha = 2f;
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private float tempoIndefeso = 4f;
    [SerializeField] private float tempoDefendendo = 3f;

    [SerializeField] private float alturaBlocos = 5f;
    [SerializeField] private float tempoQuedaBlocos = 1f;
    [SerializeField] private float raioEmpurrao = 1f;

    [SerializeField] private List<Empurrao> blocosAfetados;
    [SerializeField] private GameObject premio;

    private float cooldownBatalha;
    private Mov_Player player;
    private float defaultY;
    private Quaternion defaultRotation;
    private void Start()
    {
        defaultY = transform.position.y;
        defaultRotation = transform.rotation;

        player = FindObjectOfType<Mov_Player>();
        cooldownBatalha = tempoInicioBatalha;
    }

    private void Update()
    {
        if (controller.GetSalaAtual() == controller)
        {
            if (cooldownBatalha > 0)
            {
                if (cooldownBatalha > Time.deltaTime)
                {
                    cooldownBatalha -= Time.deltaTime;
                }
                else
                {
                    animator.SetBool("Ativo", true);
                    cooldownBatalha = 0;
                }
            }
            else
            {
                ProcessarRotacao(Time.deltaTime);

                if (!isPulando && !IsIndefeso && !isDefendendo)
                {
                    Vector3 alvo = new(
                        player.transform.position.x,
                        defaultY,
                        player.transform.position.z
                    );
                    Pular(alvo);
                }
            }
        }
        else if (cooldownBatalha == 0)
        {
            if (Pular(controller.transform.position))
            {
                cooldownBatalha = tempoInicioBatalha;
                transform.rotation = defaultRotation;
            }
        }
    }

    private bool rotacionar = false;
    private void ProcessarRotacao(float delta)
    {
        if (!rotacionar) return;

        const float fatorRotacao = 4f;

        transform.rotation = Quaternion.Lerp(
            Quaternion.LookRotation(
                Utilitarios.IgnoreY(player.transform.position - transform.position)
            ),
            transform.rotation,
            Mathf.Exp(-fatorRotacao * delta)
        );
    }

    bool isPulando = false;
    private bool Pular(Vector3 alvo)
    {
        if (!isPulando)
        {
            StartCoroutine(PuloCoroutine(alvo));
            return true;
        }

        return false;
    }

    private IEnumerator PuloCoroutine(Vector3 alvo)
    {
        isPulando = true;

        // corrige a posição conforme o grid
        Vector3 direcao = alvo - transform.position;
        alvo = new(
            Mathf.Round(alvo.x) - Mathf.Sign(direcao.x) * .5f,
            Mathf.Round(alvo.y),
            Mathf.Round(alvo.z) - Mathf.Sign(direcao.z) * .5f
        );

        animator.SetBool("Ativo", true);
        rotacionar = true;
        yield return Utilitarios.Parabola(gameObject, transform.position, 1, 2/3f);
        rotacionar = false;

        float distanciaDoPulo = (alvo - transform.position).magnitude;
        float tempoDoPulo = distanciaDoPulo / velocidade;
        foreach (var bloco in blocosAfetados)
        {
            Vector3 distanciaBloco = Utilitarios.IgnoreY(bloco.transform.position - alvo);
            Vector3 offset = Vector3.zero;
            Vector3 movimentoBloco;

            if (Mathf.Abs(distanciaBloco.x) <= raioEmpurrao && Mathf.Abs(distanciaBloco.z) <= raioEmpurrao)
            {
                movimentoBloco = Vector3.right * Mathf.Sign(distanciaBloco.x);
                if (Mathf.Abs(distanciaBloco.x) <= raioEmpurrao && !bloco.MovimentoObstruido(movimentoBloco))
                { offset += movimentoBloco; }

                movimentoBloco = Vector3.forward * Mathf.Sign(distanciaBloco.z);
                if (Mathf.Abs(distanciaBloco.z) <= raioEmpurrao && !bloco.MovimentoObstruido(movimentoBloco))
                { offset += movimentoBloco; }
            }

            bloco.Pula(offset, alturaBlocos, tempoDoPulo + tempoQuedaBlocos);
        }

        animator.SetBool("Pulando", true);
        yield return Utilitarios.Parabola(gameObject, alvo, 2, tempoDoPulo);
        animator.SetBool("Pulando", false);

        yield return CooldownPulo();
        animator.SetBool("Ativo", false);
        isPulando = false;
    }

    private float tempoIndefesoRestante = 0;
    private IEnumerator CooldownPulo()
    {
        isDefendendo = false;
        tempoIndefesoRestante = tempoIndefeso;
        while (tempoIndefesoRestante > Time.deltaTime)
        {
            tempoIndefesoRestante -= Time.deltaTime;
            yield return null;
        }
        tempoIndefesoRestante = 0;

        isDefendendo = true;
        animator.SetBool("Ativo", false);
        yield return new WaitForSeconds(tempoDefendendo);
        animator.SetBool("Ativo", true);
        isDefendendo = false;
    }
    public bool IsIndefeso => tempoIndefesoRestante > 0 && !isDefendendo;

    private bool isDefendendo = false;
    private void LevarDano()
    {
        tempoIndefesoRestante = tempoDefendendo;

        if (vida > 0)
        {
            vida--;
            if (vida == 0)
            {
                premio.SetActive(true);
                Destroy(gameObject, 0.2f);
            }
            else
            {
                isDefendendo = true;
                animator.SetBool("Ativo", false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (tempoIndefesoRestante > 0)
        {
            if (other.CompareTag("Empurravel"))
            {
                LevarDano();
                DestroiBloco(other.gameObject);
            }
        }
    }

    public void DestroiBloco(GameObject empurravel)
    {
        if (blocosAfetados.RemoveAll(bloco => bloco.gameObject == empurravel) > 0)
        { Destroy(empurravel, 0.2f); }
    }
}
