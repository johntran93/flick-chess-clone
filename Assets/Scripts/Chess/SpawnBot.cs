using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBot : MonoBehaviour
{
    [SerializeField] public List<Transform> pos = new List<Transform>();

    private void Start()
    {
        GameObject goKingEnemy = Instantiate(GameManager.Instance.ListMesh.ListChess[5], pos[0].position, Quaternion.identity);
        goKingEnemy.GetComponent<ChessController>().ChessTeam = ChessTeam.Enemy;
        //Debug.Log("Enemy have : " + goKingEnemy.GetComponent<ChessController>().ChessPiece);
        GameManager.Instance.ListEnemy.Add(goKingEnemy);

        for (int i = 1; i < pos.Count; i++)
        {
            GameObject Go = Instantiate(GameManager.Instance.ListMesh.ListChess[Random.Range(0, 4)], pos[i].position, Quaternion.identity);
            Go.GetComponent<ChessController>().ChessTeam = ChessTeam.Enemy;
            Go.SetActive(true);
            GameManager.Instance.ListEnemy.Add(Go);
        }
        //Instantiate(GameManager.Instance.ListMesh.ListChess[Random.Range(0,4)], pos[5].position, Quaternion.identity).gameObject.tag = "Enemy";
    }
}
