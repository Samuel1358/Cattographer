using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mov_Inimigo_PassoAPasso : MonoBehaviour
{
    public int move = 0;
    public int direcao;
    public int destino;
    private int dest;
    public float timerMov = 1f;
    private float ttMov;
    Quaternion inicial, dir;

    RaycastHit hit;

    #region // INSTRUCOES

    /* MOVE:
     * 0 -> não ativo
     * 1 -> ativo
     * 2 -> concluido
     */

    /* DIRECAO:
     * 1 -> frente ----- (+z)
     * 2 -> direita -- (+x)
     * 3 -> traz ---- (-z)
     * 4 -> esquerda - (-x)
     */

    /* DESTINO:
     * numero de casas que a se andar
     */

    /* TIMER:
     * tempo entre cada passo
     */

    /* CONNECT:
     * ativado -> caso passe para outro movimento ao terminar
     * desativado -> caso não 
     */

    #endregion

    //public Sala_Controller controller;
    public Mov_Inimigo_PassoAPasso next;
    public bool connect = false;

    // Start is called before the first frame update
    void Start()
    {
        inicial = new Quaternion(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z, 1f);
        dest = destino;
        ttMov = timerMov;
    }

    // Update is called once per frame
    void Update()
    {
        // (verifica se esta ativo)
        if (move == 1)
        {
            // (verifica se ainda deve andar)
            if (destino > 0)
            {
                // (verifica o timer)
                if (timerMov <= 0)
                { 
                    // (verifica a diracao do passo)
                    switch (direcao)
                    {
                        // Frente
                        case 1:
                            dir = Quaternion.Euler(inicial.x, inicial.y, inicial.z);
                            transform.rotation = dir;
                            //transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z)) + transform.forward;
                            break;
                        // Direita
                        case 2:
                            dir = Quaternion.Euler(inicial.x, inicial.y + 90f, inicial.z);
                            transform.rotation = dir;
                            //transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z)) + transform.forward;
                            break;
                        // Traz
                        case 3:
                            dir = Quaternion.Euler(inicial.x, inicial.y + 180f, inicial.z);
                            transform.rotation = dir;
                            //transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z)) + transform.forward;
                            break;
                        // Esquerda
                        case 4:
                            dir = Quaternion.Euler(inicial.x, inicial.y + 270f, inicial.z);
                            transform.rotation = dir;
                            break;
                    }
                    if (Physics.Raycast(new Ray(transform.position, transform.forward), out hit, 1f, 128, QueryTriggerInteraction.Collide))
                    {
                        destino = 0;
                    }
                    else
                    {
                        transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z)) + transform.forward;

                        destino -= 1;
                        timerMov = ttMov;
                    }
                }
                if (timerMov > 0)
                {
                    timerMov -= Time.deltaTime;
                }
            }
            if (destino <= 0)
            {
                move = 2;
            }
        }
        if (move == 2)
        {
            // (verifica se esta conectado a outro movimento, e ativa-o se positivo)
            if (connect == true)
            {
                next.destino = next.dest;
                next.move = 1;
            }
            move = 0;
        }
    }

}
