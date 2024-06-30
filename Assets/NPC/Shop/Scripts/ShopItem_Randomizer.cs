using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopItem_Randomizer : MonoBehaviour
{
    public GameObject shopKeeper;

    public GameObject chave;
    public GameObject bomba;
    public GameObject kyrozene;
    public GameObject tabua;

    bool chaveSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(shopKeeper, new Vector3(transform.position.x - 3, transform.position.y, transform.position.z + 1), Quaternion.identity);

        int rand;
        for (int i = 4; i >= 0; i -= 2)
        {
            Vector3 pos = new Vector3((transform.position.x + 2) - i, transform.position.y, transform.position.z);

            if (!chaveSpawned)
            {
                if (i == 0)
                {
                    Instantiate(chave, pos, Quaternion.identity);
                    break;
                }
                rand = Random.Range(0, 4);
            }
            else
            {
                rand = Random.Range(1, 4);
            }

            switch (rand)
            {
                case 0:
                    Instantiate(chave, pos, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(bomba, pos, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(kyrozene, pos, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(tabua, pos, Quaternion.identity);
                    break;
            }

            if (rand == 0)
            {
                chaveSpawned = true;
            }
        }       
    }
}
