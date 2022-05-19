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
    private float _mZCoord;
    private Vector3 _mOffSet;
    private Vector3 _oldPosition;
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private Vector3 _colliderPos;
    private Rigidbody _rb;

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
        
        _rb = GetComponent<Rigidbody>();
        if (gameObject.GetComponent<ChessController>().ChessTeam == ChessTeam.Enemy)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        if(!GameManager.Instance.GameIsPlay)
        CheckGrid();
        //grapInput = new GrapInput();
        //grapInput.Mouse.Enable();
        //grapInput.Mouse.LeftClick.started += OnLeftClick;
        //grapInput.Mouse.LeftClick.canceled += OnLeftClickRelease;

    }
    void Update()
    {

        if (gameObject.transform.position.y < 1f && (_chessTeam == ChessTeam.Enemy))
        {
            Die();
        }
        if (gameObject.transform.position.y < 1f && (_chessTeam == ChessTeam.Player))
        {
            Die();
        }
        //MovingSelected();
        if (GameManager.Instance.GameIsPlay == false)
        {
            MovingSelectedOldInput();
            _rb.isKinematic = true;
        }
        else
        {
            _rb.isKinematic = false;
        }
    }
    private void OnMouseDown()
    {

        _oldPosition = gameObject.transform.position;
        mousePressDownPos = Input.mousePosition;
        if (_selecting == false && _chessPiece != ChessPiece.King)
        {
            _selecting = true;
            _selected = gameObject.transform;

            //_selected = GameManager.Instance.RaycastCheck.Check().transform;
            _mZCoord = Camera.main.WorldToScreenPoint(_selected.transform.position).z;
            _mZCoord -= 1;
            _releaseable = false;
        }
    }

    private void MovingSelectedOldInput()
    {
        if (_selecting == true)
        { 
            Vector3 posOld = _selected.transform.position;
            Vector2 pos = Input.mousePosition;
            Vector3 mousePositionForObject = new Vector3(pos.x, pos.y, _mZCoord);
            _mOffSet = Camera.main.ScreenToWorldPoint(mousePositionForObject);
            _selected.transform.position = _mOffSet;

            for(int i = 0 ; i < GameManager.Instance.ShowGrid.ListCell.Count; i++)
            {
                if(posOld.x == GameManager.Instance.ShowGrid.ListCell[i].transform.position.x){
                   
                    GameManager.Instance.ShowGrid.ListCell[i].GetComponent<Grid>().SetOccupied(false);
                }
            }
        }
    }
        private void OnMouseUp()
        {
            if (!GameManager.Instance.GameIsPlay &&  _chessPiece != ChessPiece.King)
            {

                OnMouseReleaseOldInput();
                mouseReleasePos = Input.mousePosition;
                _selecting = false;

                gameObject.transform.position = new Vector3(_gridSelected.transform.position.x, _gridSelected.transform.position.y + 0.3f, _gridSelected.transform.position.z);
            }
        }

        private void OnMouseReleaseOldInput()
        {
             if (_chessTeam != ChessTeam.Player || _chessPiece == ChessPiece.King)
                return;
            Collider[] hitColliders = Physics.OverlapSphere(_selected.transform.position, 20);
            Transform temp = gameObject.transform;
            Collider lastcolider = hitColliders[0];
            float distance = 99999;

            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].CompareTag("Grid") && hitColliders[i].GetComponent<Grid>().Occupied == false)
                {
                    float newDistance = (_selected.transform.position - hitColliders[i].transform.position).magnitude;
                    // Debug.Log(newDistance);
                    if (newDistance < distance)
                    {
                        distance = newDistance;
                        _releaseable = true;
                        temp = hitColliders[i].transform;
                        lastcolider = hitColliders[i];
                    }

                }

            }
            lastcolider.GetComponent<Grid>().SetOccupied(true);
            if (_releaseable)
                _gridSelected = temp;
        }

        public void CheckGrid()
        {
            if (_chessTeam != ChessTeam.Player || _chessPiece == ChessPiece.King)
                return;
            Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.localPosition, 20);
            Transform temp = gameObject.transform;
            Collider lastcolider = hitColliders[0];
            float distance = 99999;
            bool tempReleaseable = false;
            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].CompareTag("Grid") && hitColliders[i].GetComponent<Grid>().Occupied == false)
                {
                    float newDistance = (gameObject.transform.position - hitColliders[i].transform.position).magnitude;
                    if (newDistance < distance)
                    {
                        distance = newDistance;
                        tempReleaseable = true;
                        temp = hitColliders[i].transform;
                        lastcolider = hitColliders[i];
                    }
                }
            }
            lastcolider.GetComponent<Grid>().SetOccupied(true);
            if (tempReleaseable)
            {
                _gridSelected = temp;
                gameObject.transform.position = new Vector3(_gridSelected.transform.position.x, _gridSelected.transform.position.y + 0.3f, _gridSelected.transform.position.z);
            }

        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Ground") && !other.gameObject.CompareTag("Grid") && !other.gameObject.CompareTag("Chess"))
            {
                ContactPoint contact = other.contacts[0];
                _colliderPos = contact.point;
                Instantiate(GameManager.Instance.ParticleSystem, _colliderPos, Quaternion.identity);
            }
        }
        public void Die()
        {
            if (_chessTeam == ChessTeam.Enemy)
            {
                GameManager.Instance.ListEnemy.Remove(gameObject);
                GameManager.Instance.CheckWin();
                GameManager.Instance.ChangeUp(_chessPiece == ChessPiece.King);
                if (_chessPiece == ChessPiece.King)
                {
                    GameManager.Instance.GameWin();
                }
            }
            if (_chessTeam == ChessTeam.Player)
            {
                GameManager.Instance.ListPlayer.Remove(gameObject);
                if (_chessPiece == ChessPiece.King)
                {
                    GameManager.Instance.GameOver();
                }
            }
            Destroy(gameObject);
        }
    }
