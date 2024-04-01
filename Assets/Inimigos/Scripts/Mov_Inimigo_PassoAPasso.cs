using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_Inimigo_PassoAPasso : MonoBehaviour
{
    public enum Direcao
    {
        PositiveZ,
        PositiveX,
        NegativeZ,
        NegativeX,
    }

    public bool moving = false;
    public Direcao direcao;
    public int destino;
    private int passo;
    public float timerMov = 1f;
    private float ttMov;
    private Quaternion inicial;

    #region // INSTRUCOES

    /* MOVING:
     * se está se movendo
     */

    /* DIRECAO:
     * PosZ -> frente
     * PosX -> direita
     * NegZ -> traz
     * NegX -> esquerda
     */

    /* PASSO:
     * numero de casas que já andou
     */

    /* DESTINO:
     * numero de casas total do movimento
     */

    /* TIMER:
     * tempo entre cada passo
     */

    #endregion

    //public Sala_Controller controller;
    public Mov_Inimigo_PassoAPasso next;
    private Mov_Inimigo_PassoAPasso prev;
    private bool forward;

    // Start is called before the first frame update
    void Start()
    {
        inicial = new Quaternion(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z, 1f);
        passo = 0;
        forward = true;
        ttMov = timerMov;
        if (next != null)
        {
            next.prev = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // (verifica se esta ativo)
        if (moving)
        {
            // (verifica o timer)
            if (timerMov <= 0)
            {
                // (verifica se ainda deve andar)
                if ((forward && passo < destino) || (!forward && passo > 0))
                {
                    // (verifica a direcao do passo)
                    if (forward)
                    {
                        transform.rotation = direcao switch
                        {
                            // Frente
                            Direcao.PositiveZ => Quaternion.Euler(inicial.eulerAngles + new Vector3(0f, 0f, 0f)),

                            // Direita
                            Direcao.PositiveX => Quaternion.Euler(inicial.eulerAngles + new Vector3(0f, 90f, 0f)),

                            // Traz
                            Direcao.NegativeZ => Quaternion.Euler(inicial.eulerAngles + new Vector3(0f, 180f, 0f)),

                            // Esquerda
                            Direcao.NegativeX => Quaternion.Euler(inicial.eulerAngles + new Vector3(0f, 270f, 0f)),

                            _ => transform.rotation,
                        };
                    }
                    else /* if (!forward) */
                    {
                        transform.rotation = direcao switch
                        {
                            // Traz (Frente ao contrário)
                            Direcao.PositiveZ => Quaternion.Euler(inicial.eulerAngles + new Vector3(0f, 180f, 0f)),

                            // Esquerda (Direita ao contrário)
                            Direcao.PositiveX => Quaternion.Euler(inicial.eulerAngles + new Vector3(0f, 270f, 0f)),

                            // Frente (Traz ao contrário)
                            Direcao.NegativeZ => Quaternion.Euler(inicial.eulerAngles + new Vector3(0f, 0f, 0f)),

                            // Direita (Esquerda ao contrário)
                            Direcao.NegativeX => Quaternion.Euler(inicial.eulerAngles + new Vector3(0f, 90f, 0f)),

                            _ => transform.rotation,
                        };
                    }

                    // (verifica se há um obstáculo na frente)
                    if (Physics.Raycast(new Ray(transform.position, transform.forward), 1f, 128, QueryTriggerInteraction.Collide))
                    {
                        forward = !forward;
                    }
                    else
                    {
                        transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z)) + transform.forward;

                        passo += forward ? 1 : -1;
                    }

                    timerMov = ttMov;
                }
                else
                {
                    // (verifica se esta conectado a outro movimento, e ativa-o se positivo)
                    if (forward && next != null)
                    {
                        next.passo = 0;
                        next.forward = true;
                        next.moving = true;

                    }
                    else if (!forward && prev != null)
                    {
                        prev.passo = next.destino;
                        prev.forward = false;
                        prev.moving = true;
                    }

                    moving = false;
                }
            }
            else /* if (timerMov > 0) */
            {
                timerMov -= Time.deltaTime;
            }
        }
    }
}