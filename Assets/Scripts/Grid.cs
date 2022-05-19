using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private bool _occupied;
    private Material _old;
    
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
    private void Awake() {
        _occupied = false;
        _old = GetComponent<MeshRenderer>().material;
    }
    public void SetOccupied(bool occupied) {
        Occupied = occupied;
        if(_occupied){ 
                GetComponent<MeshRenderer>().material = GameManager.Instance.Material;
        }
        else if(!_occupied){
            GetComponent<MeshRenderer>().material = _old;
        }
    }

}
