using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private bool _occupied = false;
    
     public bool Occupied
    {
        get
        {
            return _occupied;
        }
        set
        {
            _occupied = value;
        }
    }
    private void Update() {
        if(_occupied){
            
                GetComponent<MeshRenderer>().material = GameManager.Instance.Material;
        }
    }

}
