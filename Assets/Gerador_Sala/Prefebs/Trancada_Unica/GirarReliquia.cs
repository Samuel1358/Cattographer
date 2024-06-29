using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarReliquia : MonoBehaviour
{
    public enum Eixo
    {
        X, Y, Z,
    }
    

    [SerializeField] Eixo eixo;
    [SerializeField] Space referancia;
    [SerializeField] float spd;
    Vector3 vec;

    private void Start()
    {
        switch(eixo)
        {
            case Eixo.X:
                vec = new Vector3(1, 0, 0);
                break;
            case Eixo.Y:
                vec = new Vector3(0, 1, 0);
                break;
            case Eixo.Z:
                vec = new Vector3(0, 0, 1);
                break;
        }
    }

    void Update()
    {
        transform.Rotate(vec * spd, referancia);
    }
}
