using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBlock : MonoBehaviour
{
    public int HP;

    private void OnTriggerEnter(Collider other)
    {

        if (CompareTag("Box"))
        {
            HP--;
        }

        if (CompareTag("Eat"))
        {
            HP--;
        }

        if (HP == 0)
        {
            Destroy(gameObject);
        }
    }
 
}
