using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomba : MonoBehaviour
{
    Timer_Sombra sombra;
    Mov_Player player;

    public Slider marcador;
    GameObject bloco;
    float explodir = 2f, ttx;

    // Start is called before the first frame update
    void Start()
    {
        sombra = FindObjectOfType<Timer_Sombra>();
        player = FindObjectOfType<Mov_Player>();

        ttx = explodir;
        marcador.maxValue = ttx;
    }

    // Update is called once per frame
    void Update()
    {
        marcador.value = ttx - explodir;

        if (bloco == null)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -Vector2.up, out hit, 0.5f))
            {
                bloco = hit.collider.gameObject;
            }
        }

        if (explodir <= 0)
        {
            if (Mathf.Sqrt(Mathf.Pow(player.transform.position.x - transform.position.x, 2) + Mathf.Pow(player.transform.position.z - transform.position.z, 2)) <= 2.5f)
            {
                sombra.timerSombra -= 1f;
            }

            Destroy(bloco);
            Destroy(gameObject);
        }
        if (explodir > 0)
        {
            explodir -= Time.deltaTime;
        }
    }
}
