using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ferramenta_Freckles : MonoBehaviour
{
    [SerializeField] float spd = 3f;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        dir = transform.forward.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += Vector3.up * 1f;
        transform.Translate(dir * spd * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Untagged"))
        {
            if (other.CompareTag("Player"))
            {
                //other.gameObject.GetComponent<Hit_Timer>().CausarDano(0.5f);
                Debug.Log("Tomou gep do vo");
            }
            Debug.Log("Destruiu");
            Destroy(gameObject);
        }
    }
}
