using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerador_Itens : MonoBehaviour
{
    GameObject item;

    [SerializeField] GameObject bomba;
    [SerializeField] GameObject tabua;
    [SerializeField] GameObject kyrozene;

    // Start is called before the first frame update
    void Start()
    {
        switch(Random.Range(1, 4))
        {
            case 1:
                item = bomba;
                break;
            case 2:
                item = tabua;
                break;
            case 3:
                item = kyrozene;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(item, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
