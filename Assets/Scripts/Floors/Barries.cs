using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barries : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision other)
    {
        
         if (gameObject.CompareTag ("Barries"))
        {
            if (other.gameObject.CompareTag("EndBarries"))
            {
               Destroy(gameObject);
            }
        }
    }
}
