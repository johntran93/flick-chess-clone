using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCheck : MonoBehaviour
{
    public LayerMask mask;
    RaycastHit hit;
    public void Update()
    {
        // Vector3 mousePos = Input.mousePosition;
        // mousePos.z = 100f;
        // mousePos = cam.ScreenToWorldPoint(mousePos);
        // Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);
        if (Input.GetMouseButtonDown(0))
        {
             Check();
        }  
    }
    public RaycastHit Check(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo ;
            if (Physics.Raycast(ray,out hitInfo,100,mask))
            {
                //Debug.Log("Hit is : " + hitInfo.transform.GetComponent<ChessController>().ChessPiece);
                    hit = hitInfo; 
            }
        return hit;
    }

}

