using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBlock : MonoBehaviour
{
    public int HP;

    private void OnTriggerEnter(Collider other)
    {

        if (CompareTag("Player"))
        {
            HP--;

            Debug.Log("Задел блок");
        }

        if (HP == 0)
        {
            Destroy(gameObject);
        }
    }
 
}
