using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChessController : MonoBehaviour
{
    [SerializeField] private ChessPiece _chessPiece;
    [SerializeField] private ChessTeam _chessTeam;
    private Transform _selected;
    private Transform _gridSelected;
    private bool _selecting = false;
    private bool _releaseable = false;
    private float mZCoord;
    private Vector3 _mOffSet;
    private Vector3 _oldPosition;
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private Vector3 _colliderPos;

    public ChessTeam ChessTeam
    {
        get
        {
            return _chessTeam;
        }
        set
        {
            _chessTeam = value;
        }
    }
    public ChessPiece ChessPiece => _chessPiece;
    void Start()
    {
        if (gameObject.GetComponent<ChessController>().ChessTeam == ChessTeam.Enemy)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        //grapInput = new GrapInput();
        //grapInput.Mouse.Enable();
        //grapInput.Mouse.LeftClick.started += OnLeftClick;
        //grapInput.Mouse.LeftClick.canceled += OnLeftClickRelease;
    }
    void Update()
    {
        if (gameObject.transform.position.y < 2f && gameObject.GetComponent<ChessController>().ChessTeam == ChessTeam.Enemy)
        {
            Die();
        }
        //MovingSelected();
        if (GameManager.Instance.GameIsPlay == false)
        {
            MovingSelectedOldInput();
            GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
        if ((gameObject.transform.position.y < 2f) && _chessTeam == ChessTeam.Player)
        {
            Die();
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
            //_selected = GameManager.Instance.RaycastCheck.Check().transform;
            mZCoord = Camera.main.WorldToScreenPoint(_selected.transform.position).z;
            mZCoord -= 1;
            _releaseable = false;
        }
    }

    private void MovingSelectedOldInput()
    {
        if (_selecting == true)
        {
            Vector2 pos = Input.mousePosition;
            Vector3 mousePositionForObject = new Vector3(pos.x, pos.y, mZCoord);
            _mOffSet = Camera.main.ScreenToWorldPoint(mousePositionForObject);
            _selected.transform.position = _mOffSet;
        }
    }
    private void OnMouseUp()
    {
        if (!GameManager.Instance.GameIsPlay)
        {
            OnMouseReleaseOldInput();
            mouseReleasePos = Input.mousePosition;
            _selecting = false;

            gameObject.transform.position = _gridSelected.transform.position;
        }
    }

    private void OnMouseReleaseOldInput()
    {
        Collider[] hitColliders = Physics.OverlapSphere(_selected.transform.position, 20);
        Transform temp = gameObject.transform;

        float distance = 99999;


        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].CompareTag("Grid") && hitColliders[i].GetComponent<Grid>()._occupied == false)
            {
                float newDistance = (_selected.transform.position - hitColliders[i].transform.position).magnitude;
                // Debug.Log(newDistance);
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
        if (!other.gameObject.CompareTag("Ground") && !other.gameObject.CompareTag("Grid") && !other.gameObject.CompareTag("Chess"))
        {
            ContactPoint contact = other.contacts[0];
            _colliderPos = contact.point;
            //Debug.Log(" Position on collider : " + _colliderPos);
            Instantiate(GameManager.Instance.ParticleSystem, _colliderPos, Quaternion.identity);
        }
    }


    public void Die()
    {
        if (_chessTeam == ChessTeam.Enemy)
        {
            GameManager.Instance.ListEnemy.Remove(gameObject);
            GameManager.Instance.CheckWin();
            GameManager.Instance.ChangeUp(GameManager.Instance.RaycastCheck.Check().transform.GetComponent<ChessController>().ChessPiece == ChessPiece.King);
            if (gameObject.GetComponent<ChessController>().ChessPiece == ChessPiece.King)
            {
                GameManager.Instance.GameWin();
            }
        }
        else{
            GameManager.Instance.GameOver();
        }
        Destroy(gameObject);
    }
}
