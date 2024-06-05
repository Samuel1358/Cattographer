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

    public bool VerificarTabua(int dir)
    {
        RaycastHit hit;
        switch (dir)
        {
            case 1:
                if (Physics.Raycast(player.transform.position, Vector3.forward, out hit, 1f))
                {
                    if (hit.collider.gameObject.CompareTag("Buraco"))
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
                    if (hit.collider.gameObject.CompareTag("Buraco"))
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
                    if (hit.collider.gameObject.CompareTag("Buraco"))
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
                    if (hit.collider.gameObject.CompareTag("Buraco"))
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
    public void ColocarTabua(int dir)
    {
        RaycastHit hit;
        switch (dir)
        {
            case 1:
                if (Physics.Raycast(player.transform.position, Vector3.forward, out hit, 1f))
                {
                    if (hit.collider.gameObject.CompareTag("Buraco"))
                    {
                        Instantiate(tabua, new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z), transform.rotation);
                    }
                }
                break;
            case 2:
                if (Physics.Raycast(player.transform.position, Vector3.right, out hit, 1f))
                {
                    if (hit.collider.gameObject.CompareTag("Buraco"))
                    {
                        Instantiate(tabua, new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z), transform.rotation);
                    }
                }
                break;
            case 3:
                if (Physics.Raycast(player.transform.position, -Vector3.forward, out hit, 1f))
                {
                    if (hit.collider.gameObject.CompareTag("Buraco"))
                    {
                        Instantiate(tabua, new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z), transform.rotation);
                    }
                }
                break;
            case 4:
                if (Physics.Raycast(player.transform.position, -Vector3.right, out hit, 1f))
                {
                    if (hit.collider.gameObject.CompareTag("Buraco"))
                    {
                        Instantiate(tabua, new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z), transform.rotation);
                    }
                }
                break;
        }
    }

    public void Kyrozene()
    {
        sombra.timerSombra += 2;
        sombra.ttSombra += 1;
    }
}
