using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Player : MonoBehaviour
{
    static private Camera_Player instance;
    private void Awake()
    {
        if (instance == null)
        { instance = this; }
        else
        { Destroy(gameObject); }
    }

    private float ofssetUI;

    // Start is called before the first frame update
    void Start()
    {
        ofssetUI = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y / 2;
    }

    public static void Reposicionar(Vector3 alvo)
    {
        Vector3 posicaoNoGrid = Gride.PosicaoNoGrid(alvo);
        Vector3 posicaoNoMundo = Gride.PosicaoNoMundo(posicaoNoGrid);

        instance.transform.position = new(posicaoNoMundo.x, instance.transform.position.y, posicaoNoMundo.z - instance.ofssetUI);
    }
}
