using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VelocidadeSombra_GameTest : MonoBehaviour
{
    [HideInInspector][SerializeField] VelocidadeSombra_Replace replace;
    Text display;

    // Start is called before the first frame update
    void Start()
    {
        display = GetComponent<Text>();
    }

    private void Update()
    {
        display.text = replace.velocidade.ToString();
    }

    public void Diminuir()
    {
        if (replace.velocidade > 1)
        {
            replace.velocidade -= 1;
        }
    }
    public void Aumentar()
    {
        if (replace.velocidade < 50)
        {
            replace.velocidade += 1;
        }
    }
}
