using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funcao_Itens : MonoBehaviour
{
    public GameObject bomba;
    public GameObject tabua;
    Timer_Sombra sombra;
    Mov_Player player;

    // Start is called before the first frame update
    void Start()
    {
        sombra = FindAnyObjectByType<Timer_Sombra>();
        player = FindObjectOfType<Mov_Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool VerificarBomba(int dir)
    {
        RaycastHit hit;
        switch (dir)
        {
            case 1:
                if (Physics.Raycast(player.transform.position, Vector3.forward, out hit, 1f))
                {
                    if (hit.collider.gameObject.CompareTag("Empurravel"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                //break;
            case 2:
                if (Physics.Raycast(player.transform.position, Vector3.right, out hit, 1f))
                {
                    if (hit.collider.gameObject.CompareTag("Empurravel"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                //break;
            case 3:
                if (Physics.Raycast(player.transform.position, -Vector3.forward, out hit, 1f))
                {
                    if (hit.collider.gameObject.CompareTag("Empurravel"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                //break;
            case 4:
                if (Physics.Raycast(player.transform.position, -Vector3.right, out hit, 1f))
                {
                    if (hit.collider.gameObject.CompareTag("Empurravel"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                //break;
            default: return false;
        } 
    }
    public void ColocarBomba(int dir)
    {
        RaycastHit hit;
        switch (dir)
        {
            case 1:
                if (Physics.Raycast(player.transform.position, Vector3.forward, out hit, 1f))
                {
                    if (hit.collider.gameObject.CompareTag("Empurravel"))
                    {
                        Instantiate(bomba, new Vector3(hit.transform.position.x, hit.transform.position.y + 0.8f, hit.transform.position.z), Quaternion.identity);
                    }
                }
                break;
            case 2:
                if (Physics.Raycast(player.transform.position, Vector3.right, out hit, 1f))
                {
                    if (hit.collider.gameObject.CompareTag("Empurravel"))
                    {
                        Instantiate(bomba, new Vector3(hit.transform.position.x, hit.transform.position.y + 0.8f, hit.transform.position.z), Quaternion.identity);
                    }
                }
                break;
            case 3:
                if (Physics.Raycast(player.transform.position, -Vector3.forward, out hit, 1f))
                {
                    if (hit.collider.gameObject.CompareTag("Empurravel"))
                    {
                        Instantiate(bomba, new Vector3(hit.transform.position.x, hit.transform.position.y + 0.8f, hit.transform.position.z), Quaternion.identity);
                    }
                }
                break;
            case 4:
                if (Physics.Raycast(player.transform.position, -Vector3.right, out hit, 1f))
                {
                    if (hit.collider.gameObject.CompareTag("Empurravel"))
                    {
                        Instantiate(bomba, new Vector3(hit.transform.position.x, hit.transform.position.y + 0.8f, hit.transform.position.z), Quaternion.identity);
                    }
                }
                break;
        }
    }

    public bool VerificarTabua(int dir, int mult)
    {
        RaycastHit hit;
        switch (dir)
        {
            case 1:
                Debug.Log("cima");
                if (Physics.Raycast(player.transform.position + Vector3.forward * mult, Vector3.down, out hit, 23f))
                {
                    if (hit.collider.gameObject.CompareTag("Fundo"))
                    {
                        Debug.Log("1");
                        return true;
                    }
                    else
                    {
                        Debug.Log("2");
                        Debug.Log(hit.collider.gameObject);
                        return false;
                    }
                }
                else
                {
                    Debug.Log("3");
                    return false;
                }
            //break;
            case 2:
                Debug.Log("direita");
                if (Physics.Raycast(player.transform.position + Vector3.right * mult, Vector3.down, out hit, 24f))
                {
                    if (hit.collider.gameObject.CompareTag("Fundo"))
                    {
                        Debug.Log("1");
                        return true;
                    }
                    else
                    {
                        Debug.Log("2");
                        Debug.Log(hit.collider.gameObject);
                        return false;
                    }
                }
                else
                {
                    Debug.Log("3");
                    return false;
                }
            //break;
            case 3:
                Debug.Log("baixo");
                if (Physics.Raycast(player.transform.position + Vector3.back * mult, Vector3.down, out hit, 25f))
                {
                    if (hit.collider.gameObject.CompareTag("Fundo"))
                    {
                        Debug.Log("1");
                        return true;
                    }
                    else
                    {
                        Debug.Log("2");
                        Debug.Log(hit.collider.gameObject);
                        return false;
                    }
                }
                else
                {
                    Debug.Log("3");
                    return false;
                }
            //break;
            case 4:
                Debug.Log("esquerda");
                if (Physics.Raycast(player.transform.position + Vector3.left * mult, Vector3.down, out hit, 26f))
                {
                    if (hit.collider.gameObject.CompareTag("Fundo"))
                    {
                        Debug.Log("1");
                        return true;
                    }
                    else
                    {
                        Debug.Log("2");
                        Debug.Log(hit.collider.gameObject);
                        return false;
                    }
                }
                else
                {
                    Debug.Log("3");
                    return false;
                }
            //break;
            default:
                Debug.Log("4");
                return false;
        }
    }
    public void ColocarTabua(int dir)
    {
        switch (dir)
        {
            case 1:
                Instantiate(tabua, new Vector3(player.transform.position.x, 0, player.transform.position.z + 1), transform.rotation);
                break;
            case 2:
                Instantiate(tabua, new Vector3(player.transform.position.x + 1, 0, player.transform.position.z), transform.rotation);
                break;
            case 3:
                Instantiate(tabua, new Vector3(player.transform.position.x, 0, player.transform.position.z - 1), transform.rotation);
                break;
            case 4:
                Instantiate(tabua, new Vector3(player.transform.position.x - 1, 0, player.transform.position.z), transform.rotation);
                break;
        }
    }

    public void Kyrozene()
    {
        sombra.timerSombra += 2;
        sombra.ttSombra += 1;
    }
}
