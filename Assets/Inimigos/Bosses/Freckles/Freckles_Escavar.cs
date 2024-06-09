using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freckles_Escavar : MonoBehaviour
{
    public GameObject[] linhaA = new GameObject[7];
    public GameObject[] linhaB = new GameObject[7];
    public GameObject[] linhaC = new GameObject[7];
    public GameObject[] linhaD = new GameObject[7];
    public GameObject[] linhaE = new GameObject[7];

    private GameObject[][] escavaveis = new GameObject[5][];

    public Empurrao[] blocos = new Empurrao[4];

    public int estado = 0;
    int contagem;
    int linha = 2, coluna = 3;
    int projeteis = 3;

    [SerializeField] float timerBuraco = 4f, timerAparece = 1f, timerAtaque = 5f, timerEntrar = 1f, timerMover = 2f, timerAtordoado = 3f;
    float ttBuraco, ttAparece, ttAtaque, ttMover, ttEntrar, ttAtordoado;
    float timerArremesso, ttArremesso, timerAjusteAtordoado;

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
        ttAtordoado = timerAtordoado;

        //Teste
        if (ColorUtility.TryParseHtmlString("#234bb4", out Color cor))
        {
            material.color = cor;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < blocos.Length; i++)
        {
            if (blocos[i] != null)
            {
                blocos[i].Queda();
            } 
        }

        switch (estado)
        {
            case 0:
                if (Cavar(escavaveis[2][3]))
                {
                    estado = 2;
                    Sortiar();
                }
                else
                {
                    // deu sinal
                    escavaveis[2][3].transform.eulerAngles = new Vector3(0f, escavaveis[linha][coluna].transform.rotation.eulerAngles.y + 0.5f, 0f);
                }
                break;

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
                    escavaveis[linha][coluna].transform.eulerAngles = new Vector3(0f, escavaveis[linha][coluna].transform.rotation.eulerAngles.y + 0.5f, 0f);
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
                            Debug.Log("atacou " + (3 - projeteis));
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
                Debug.Log("deu certo");
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



    private bool Cavar(GameObject obj)
    {
        if (timerBuraco <= 0)
        {
            timerBuraco = ttBuraco;
            obj.SetActive(false);
            contagem -= 1;
            return true;
        }
        else
        {
            timerBuraco -= Time.deltaTime;
            return false;
        }
    }

    private bool Aparecer()
    {
        if (timerAparece <= 0)
        {
            timerAparece = ttAparece;
            return true;
        }
        else
        {
            timerAparece -= Time.deltaTime;
            return false;
        }
    }

    private bool Ataque()
    {
        if (timerAtaque <= 0)
        {
            timerAtaque = ttAtaque;
            return true;
        }
        else
        {
            timerAtaque -= Time.deltaTime;
            return false;
        }
    }

    private bool Arremessar()
    {
        if (timerArremesso <= 0)
        {
            timerArremesso = ttArremesso;

            projeteis -= 1;
            return true;
        }
        else
        {
            timerArremesso -= Time.deltaTime;
            return false;
        }
    }

    private bool Entrar()
    {
        if (timerEntrar <= 0)
        {
            timerEntrar = ttEntrar;
            return true;
        }
        else
        {
            timerEntrar -= Time.deltaTime;
            return false;
        }
    }

    private bool Mover()
    {
        if (timerMover <= 0)
        {
            timerMover = ttMover;
            return true;
        }
        else
        {
            timerMover -= Time.deltaTime;
            return false;
        }
    }

    private bool Atordoado()
    {
        if (timerAtordoado <= 0)
        {
            timerAtordoado = ttAtordoado;
            return true;
        }
        else
        {
            timerAtordoado -= Time.deltaTime;
            return false;
        }
    }

    public void AjusteAtordoado()
    {
        timerAjusteAtordoado = timerAparece;
        timerAparece = ttAparece;
    }



    private void Sortiar()
    {
        while (true)
        {
            linha = Random.Range(0, 5);
            coluna = Random.Range(0, 7);

            #pragma warning disable CS0618 // O tipo ou membro é obsoleto
            if (escavaveis[linha][coluna].active == true)
            {
                break;
            }
        }
    }

    private float InterpolarDistancia(float distancia, float tt)
    {
        return distancia * (Time.deltaTime / tt);
    }
}
