using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freckles_Escavar : MonoBehaviour
{
    public Sala_Controller controller;
    Transform player;

    public GameObject[] linhaA = new GameObject[7];
    public GameObject[] linhaB = new GameObject[7];
    public GameObject[] linhaC = new GameObject[7];
    public GameObject[] linhaD = new GameObject[7];
    public GameObject[] linhaE = new GameObject[7];

    private GameObject[][] escavaveis = new GameObject[5][];

    public Empurrao[] blocos = new Empurrao[4];

    [SerializeField] public int estado = 5;
    int contagem;
    int linha = 2, coluna = 3;
    int projeteis = 3;

    [SerializeField] float timerBuraco = 4f, timerAparece = 1f, timerAtaque = 5f, timerEntrar = 1f, timerMover = 2f, timerAtordoado = 3f;
    float ttBuraco, ttAparece, ttAtaque, ttMover, ttEntrar, ttAtordoado;
    float timerArremesso, ttArremesso, timerAjusteAtordoado;

    [SerializeField] GameObject ferramenta;
    [SerializeField] GameObject premio;

    //Teste
    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        escavaveis = new GameObject[5][] { linhaA, linhaB, linhaC, linhaD, linhaE };

        contagem = linhaA.Length * escavaveis.Length;

        ttBuraco = timerBuraco;
        ttAparece = timerAparece;
        ttAtaque = timerAtaque;
        timerArremesso = ttAtaque / 4;
        ttArremesso = timerArremesso;
        ttEntrar = timerEntrar;
        ttMover = timerMover;
        // timerMover /= 2;
        ttAtordoado = timerAtordoado;

        player = FindObjectOfType<Mov_Player>().transform;

        //Teste
        if (ColorUtility.TryParseHtmlString("#234bb4", out Color cor))
        {
            material.color = cor;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.GetSalaAtual() == controller)
        {

            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

            for (int i = 0; i < blocos.Length; i++)
            {
                if (blocos[i] != null)
                {
                    blocos[i].Queda();
                }
            }

            switch (estado)
            {
                /*case 0:
                    if (Cavar(escavaveis[2][3]))
                    {
                        estado = 2;
                        Sortiar();
                    }
                    else
                    {
                        // deu sinal
                        escavaveis[2][3].transform.eulerAngles += Vector3.up * 0.5f;
                    }
                    break;*/

                // Cava/da sinal
                case 1:
                    if (Cavar(escavaveis[linha][coluna]))
                    {
                        if (contagem <= 0)
                        {
                            estado = 6;
                        }
                        else
                        {
                            estado = 2;
                        }
                    }
                    else
                    {
                        // deu sinal
                        //escavaveis[linha][coluna].transform.GetChild(0).transform.eulerAngles += Vector3.up * 0.5f;
                        //var sinal = escavaveis[linha][coluna].transform.GetChild(0).GetComponent<MeshRenderer>().material;
                        //sinal.color = Color.red;
                        var sinal = escavaveis[linha][coluna];
                        sinal.GetComponent<Escavavel>().DarSinal();
                        
                    }
                    break;

                // Aparece
                case 2:
                    if (Aparecer())
                    {
                        estado = 3;
                    }
                    else
                    {
                        Vector3 pos = new Vector3(0f, InterpolarDistancia(2f, ttAparece), 0f);
                        transform.position += pos;
                    }
                    break;

                // Ataca 3x
                case 3:
                    if (Ataque())
                    {
                        estado = 4;
                        projeteis = 3;
                        Sortiar();
                    }
                    else
                    {
                        if (projeteis > 0)
                        {
                            if (Arremessar())
                            {
                                Vector3 pos = (transform.position + transform.forward);
                                Instantiate(this.ferramenta, new Vector3(pos.x, player.position.y, pos.z), transform.rotation);
                                //Debug.Log("atacou " + (3 - projeteis));
                            }
                        }
                    }
                    break;

                // Entrar
                case 4:
                    if (Entrar())
                    {
                        estado = 5;
                        Vector3 pos = new Vector3(escavaveis[linha][coluna].transform.position.x, transform.position.y, escavaveis[linha][coluna].transform.position.z);
                        transform.position = pos;
                    }
                    else
                    {
                        Vector3 pos = new Vector3(0f, InterpolarDistancia(3f, ttEntrar), 0f);
                        transform.position -= pos;
                    }
                    break;

                // Move
                case 5:
                    if (Mover())
                    {
                        estado = 1;
                    }
                    else
                    {
                        Vector3 pos = new Vector3(0f, InterpolarDistancia(1f, ttMover), 0f);
                        transform.position += pos;
                    }

                    break;

                // Atordoado
                case 6:
                    if (Atordoado())
                    {
                        Sortiar();
                        estado = 4;
                        if (ColorUtility.TryParseHtmlString("#234bb4", out Color cor))
                        {
                            material.color = cor;
                        }
                    }
                    else
                    {
                        if (timerAjusteAtordoado > 0)
                        {
                            Vector3 pos = new Vector3(0f, InterpolarDistancia(2f, ttAparece), 0f);
                            transform.position += pos;

                            timerAjusteAtordoado -= Time.deltaTime;

                            if (ColorUtility.TryParseHtmlString("#ebb400", out Color cor))
                            {
                                material.color = cor;
                            }
                        }
                    }
                    break;

                case 7:
                    premio.SetActive(true);
                    Destroy(gameObject);
                    break;
                case 8:
                    Debug.Log("acabou");
                    break;
            }

            if (contagem <= 0)
            {
                estado = 8;
            }

        }
    }



    private bool Cavar(GameObject obj)
    {
        bool resposta = Contador(ref timerBuraco, ttBuraco);
        if (resposta)
        {
            obj.SetActive(false);
            contagem -= 1;
        }
        return resposta;
    }

    private bool Aparecer()
    {
        return Contador(ref timerAparece, ttAparece);
    }

    private bool Ataque()
    {
        return Contador(ref timerAtaque, ttAtaque);
    }

    private bool Arremessar()
    {
        bool resposta = Contador(ref timerArremesso, ttArremesso);
        if (resposta)
        {
            projeteis -= 1;
            return true;
        }
        return resposta;
    }

    private bool Entrar()
    {
        return Contador(ref timerEntrar, ttEntrar);
    }

    private bool Mover()
    {
        return Contador(ref timerMover, ttMover);
    }

    private bool Atordoado()
    {
        return Contador(ref timerAtordoado, ttAtordoado);
    }

    public void AjusteAtordoado()
    {
        timerAjusteAtordoado = timerAparece;
        timerAparece = ttAparece;
    }



    private void Sortiar()
    {
        if (contagem > 0)
        {
            while (true)
            {
                linha = Random.Range(0, 5);
                coluna = Random.Range(0, 7);

                #pragma warning disable CS0618 // GameObject.active é obsoleto
                if (escavaveis[linha][coluna].active == true)
                {
                    break;
                }
            }
        }        
    }

    private float InterpolarDistancia(float distancia, float tt)
    {
        return distancia * (Time.deltaTime / tt);
    }

    private bool Contador(ref float timer, float tt)
    {
        if (timer <= 0)
        {
            timer = tt;
            return true;
        }
        else
        {
            timer -= Time.deltaTime;
            return false;
        }
    }
}
