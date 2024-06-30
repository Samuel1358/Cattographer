using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressBotao_Saida : MonoBehaviour
{
    //[SerializeField] float distancia;
    float press = -1, referncia;
    Vector3 posINI, posFIN;

    // Start is called before the first frame update
    void Start()
    {
        posINI = transform.localPosition;
        posFIN = new Vector3(transform.localPosition.x, transform.localPosition.y - 0.01f, transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (press > 0)
        {
            transform.Translate(0, -(((posINI.y - posFIN.y) * (press / referncia))/2), 0, Space.Self);
            press -= Time.deltaTime;
        } 
        else if (press != -1)
        {
            MeshRenderer mesh = GetComponent<MeshRenderer>();
            mesh.material.color = Color.blue;
            press = -1;
        }
    }

    public void Precionar(float timer)
    {
        Gerenciador_Audio.TocarSFX(Gerenciador_Audio.SFX.revelation);
        press = timer;
        referncia = timer;
    }
}
