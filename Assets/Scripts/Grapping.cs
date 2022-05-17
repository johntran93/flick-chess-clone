using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class Grapping : MonoBehaviour
{
    //private GrapInput grapInput;
    private Transform _selected;
    private Transform _gridSelected;
    private bool _selecting = false;
    private bool _releaseable = false;
    private float mZCoord;
    private Vector3 _mOffSet;
    private Camera camera;
    private Vector3 _oldPosition;
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Vector3 _colliderPos;

    void Start()
    {
        camera = Camera.main;
        //grapInput = new GrapInput();
        //grapInput.Mouse.Enable();
        //grapInput.Mouse.LeftClick.started += OnLeftClick;
        //grapInput.Mouse.LeftClick.canceled += OnLeftClickRelease;

    }
    void Update()
    {
        //MovingSelected();
        //if(GameManager.Instance.GameIsPlay == false){
            MovingSelectedOldInput();
        //}

        if ((gameObject.transform.position.y < 2f) && gameObject.CompareTag("Chess"))
        {
            PlayerDie();
        }
    }
    private void OnMouseDown()
    {
        _oldPosition = gameObject.transform.position;
        mousePressDownPos = Input.mousePosition;
        if (_selecting == false)
        {
            _selecting = true;
            _selected = gameObject.transform;
            mZCoord = camera.WorldToScreenPoint(_selected.transform.position).z;
            mZCoord -= 1;
            _releaseable = false;
        }
    }

    private void MovingSelectedOldInput()
    {
        if (_selecting == true)
        {
            Debug.Log(_selecting);
            Vector2 pos = Input.mousePosition;
            Vector3 mousePositionForObject = new Vector3(pos.x, pos.y, mZCoord);
            _mOffSet = camera.ScreenToWorldPoint(mousePositionForObject);
            _selected.transform.position = _mOffSet;
        }
    }
    private void OnMouseUp()
    {
        OnMouseReleaseOldInput();
        mouseReleasePos = Input.mousePosition;
        _selecting = false;
        gameObject.transform.position = _gridSelected.transform.position;
    }

    private void OnMouseReleaseOldInput()
    {
        Collider[] hitColliders = Physics.OverlapSphere(_selected.transform.position, 20);
        Transform temp = gameObject.transform;
        float distance = 99999;
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].tag == "Grid" && hitColliders[i].GetComponent<Grid>()._occupied == false)
            {
                float newDistance = (_selected.transform.position - hitColliders[i].transform.position).magnitude;
                if (newDistance < distance)
                {
                    distance = newDistance;
                    _releaseable = true;
                    temp = hitColliders[i].transform;

                }
            }
        }
        if (_releaseable)
            _gridSelected = temp;


    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Ground") && !other.gameObject.CompareTag("Grid"))
        {
            ContactPoint contact = other.contacts[0];
            _colliderPos = contact.point;
            //Debug.Log(" Position on collider : " + _colliderPos);
            Instantiate(GameManager.Instance.ParticleSystem, _colliderPos, Quaternion.identity);
        }
    }

    private void PlayerDie()
    {
        Destroy(gameObject);
        GameManager.Instance.ListPlayer.Remove(gameObject);
        if (gameObject.name == "King")
        {
            Debug.Log(" ---------- Game Lose ----------");
        }
    }


    /*
private void OnLeftClickRelease(InputAction.CallbackContext context)
{
   _selecting = false;
   UpgradCollideCheck();
   //_selected = null;
}
private void UpgradCollideCheck()
{
   Collider[] hitColliders = Physics.OverlapSphere(_selected.transform.position, 40);

   float distance = 9000;
   int c = -1 ;

   for (int i =0; i< hitColliders.Length; i++)
   {
       if (hitColliders[i].tag == "Chess" && hitColliders[i].name != _selected.name)
       {
           float newDistance = (_selected.transform.position - hitColliders[i].transform.position).magnitude;
           if(newDistance< distance)
           {
                   distance = newDistance;
                   c = i;

           }
       }
   }   
   if(c >=0 )
   {
       hitColliders[c].GetComponent<SwitchingLevels>().CombineChess(_selected);
   }

}
private void OnLeftClick(InputAction.CallbackContext context)
{
   Vector2 pos = grapInput.Mouse.Position.ReadValue<Vector2>();
   ray = camera.ScreenPointToRay(pos);
   RaycastHit hit;
   if( Physics.Raycast(ray, out hit))
   {
       Transform selection = hit.transform;
       if (selection.tag == "Chess")
       {
           _selecting = true;
           _selected = hit.transform;
       }
   }
}
private void MovingSelected()
{
   if (_selecting == true)
   {
       mZCoord =camera.WorldToScreenPoint(_selected.transform.position).z;
       Vector2 pos = grapInput.Mouse.Position.ReadValue<Vector2>();
       Vector3 mousePosition = new Vector3(pos.x, pos.y, mZCoord);
       _mOffSet = camera.ScreenToWorldPoint(mousePosition);
       _selected.transform.position =  _mOffSet;
   }    
}
*/
    // Update is called once per frame


}
