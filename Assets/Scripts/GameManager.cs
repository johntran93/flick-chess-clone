using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Private
    public static GameManager Instance;
    [SerializeField] private MouseInput _mouseInput;
    [SerializeField] private ListMesh _listMesh;
    [SerializeField] private RaycastCheck _raycastCheck;
    [SerializeField] private float _forceMultiplier;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private TurnRound _turnRound;
    [SerializeField] private GameObject _crownWinGame;
    [SerializeField] private GridPlace _girdPlace;
    [SerializeField] private Material _material;
    [SerializeField] private CamMovement _cam;
    [SerializeField] private Data _data;
    [SerializeField] private ShowGrid _listGrid;

    private bool _gameIsWin;
    private GameObject _currentChose;

    private bool _gameIsPlay;
    private List<GameObject> _listEnemy = new List<GameObject>();
    [SerializeField] private List<GameObject> _listChessPlayer = new List<GameObject>();
    


    #endregion

    #region Public
    public Material Material => _material;
    public CamMovement Cam => _cam;
    public bool GameIsPlay => _gameIsPlay;
    public GridPlace GridPlace => _girdPlace;
    public ParticleSystem ParticleSystem => _particleSystem;
    public MouseInput MouseInput => _mouseInput;
    public ListMesh ListMesh => _listMesh;
    public RaycastCheck RaycastCheck => _raycastCheck;
    public List<GameObject> ListEnemy { get { return _listEnemy; } set { _listEnemy = value; } }
    public List<GameObject> ListPlayer { get { return _listChessPlayer; } set { _listChessPlayer = value; } }
    public ShowGrid ShowGrid { get { return _listGrid; } set { _listGrid = value; } }
    #endregion
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        _gameIsPlay = false;
        _gameIsWin = false;
    }
    public void Shoot(Vector3 force, Rigidbody rb)
    {
        
        if (_turnRound.IsPlayerTurn && _gameIsPlay && rb.GetComponent<ChessController>().ChessTeam == ChessTeam.Player && !_gameIsWin)
        {
            rb.AddForce(new Vector3(force.x, 0, force.y) * _forceMultiplier); 
            _turnRound.ChangeTeam(false);
        }
        _currentChose = null;
    }
    public void ChangeUp(bool isKing)
    {
        _currentChose = _raycastCheck.Check().transform.gameObject;
        Vector3 _currentPos = _currentChose.transform.position;

        _forceMultiplier += 1;
        _currentChose.GetComponent<Rigidbody>().mass += 1;

        if (isKing)
        {
            _currentChose.transform.localScale = new Vector3(_currentChose.transform.localScale.x + 0.1f, _currentChose.transform.localScale.y + 0.1f, _currentChose.transform.localScale.z + 0.1f);
        }
        else
        {
            Destroy(_currentChose);
            GameObject _go = Instantiate(GameManager.Instance.ListMesh.GetChess(), _currentPos, Quaternion.identity);
            // _go.transform.SetParent(gameObject.transform);
            // _go.transform.localScale = new Vector3(1.5f, 4,1.5f);
            _go.SetActive(true);
            // _go.transform.SetSiblingIndex(0);
        }
        _currentChose = null;
    }
    public void SetGameIsPlay()
    {

        _gameIsPlay = true;

    }
    public void CheckWin()
    {
        if (_listEnemy.Count == 0)
        {
            foreach (var item in _listChessPlayer)
            {
                Vector3 pos = item.transform.position;
                pos.y = item.transform.position.y + 1;
                Instantiate(_particleSystem, item.transform.position, Quaternion.identity);
                Instantiate(_crownWinGame, pos, Quaternion.identity);
            }
            _gameIsWin = true;
            Debug.Log(" ------ Win game ------- ");
        }
        //Debug.Log(" So quan con song :" + _listPlayer.Count);
    }

    public void GameWin()
    {
        _gameIsWin = true;
        foreach (var item in _listChessPlayer)
        {
            Vector3 pos = item.transform.position;
            pos.y = item.transform.position.y + 1;
            Instantiate(_particleSystem, item.transform.position, Quaternion.identity);
        }
        Instantiate(_crownWinGame,new Vector3(_listChessPlayer[0].transform.position.x,_listChessPlayer[0].transform.position.y + 1, _listChessPlayer[0].transform.position.z), Quaternion.identity);
    }
    public void GameOver()
    {
        Debug.Log(" ------ GameOver ------- ");
    }
}

