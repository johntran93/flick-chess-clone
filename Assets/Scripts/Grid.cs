using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public bool occupied = false;
    // Start is called before the first frame update
    private void Update() {
        if(occupied){
            
                GetComponent<MeshRenderer>().material = GameManager.Instance.Material;
        }
    }

}
