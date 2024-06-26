using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chester : MonoBehaviour
{
    [SerializeField] private Sala_Controller controller;

    [SerializeField] private int vida = 3;

    [SerializeField] private float tempoInicioBatalha = 2f;
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private float cooldownPulo = 2f;
    [SerializeField] private float tempoAtordoado = 1.5f;

    [SerializeField] private float alturaBlocos = 5f;
    [SerializeField] private float tempoQuedaBlocos = 1f;
    [SerializeField] private float raioEmpurrao = 1f;

    [SerializeField] private List<Empurrao> blocosAfetados;
    [SerializeField] private GameObject premio;

    private float cooldownBatalha;
    private Mov_Player player;
    private float defaultY;
    private void Start()
    {
        defaultY = transform.position.y;
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
                    cooldownBatalha = 0;
                }
            }
            else // if (isAtivo)
            {
                if (!isPulando && !IsIndefeso)
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
            { cooldownBatalha = tempoInicioBatalha; }
        }
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

        yield return Utilitarios.Parabola(gameObject, transform.position, 1, 0.6f);

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

        yield return Utilitarios.Parabola(gameObject, alvo, 2, tempoDoPulo);

        yield return TempoIndefeso();

        isPulando = false;
    }

    private float tempoIndefesoRestante = 0;
    private IEnumerator TempoIndefeso()
    {
        tempoIndefesoRestante = cooldownPulo;
        while (tempoIndefesoRestante > Time.deltaTime)
        {
            tempoIndefesoRestante -= Time.deltaTime;
            yield return null;
        }
        tempoIndefesoRestante = 0;
    }
    public bool IsIndefeso => tempoIndefesoRestante > 0;

    private void LevarDano()
    {
        tempoIndefesoRestante += tempoAtordoado;

        if (vida > 0)
        {
            vida--;
            if (vida == 0)
            {
                premio.SetActive(true);
                Destroy(gameObject, 0.2f);
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
