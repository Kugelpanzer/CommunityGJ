using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGrid : MonoBehaviour
{
    [System.Serializable]
    public struct IdObj
    {
        public GameObject gj;
        public int id;
    }
    BoardClass br;

    public List<IdObj> ConvertList = new List<IdObj>();
    //public GridObject[,] Board;
    // Start is called before the first frame update
    
    void Start()
    {
        // Board = new GridObject[5, 5];

        br = GetComponent<BoardClass>();
        br.SpawnWalls();
        br.DebugBoard();

    }

    public void UpdateGrid()
    {
        for (int i = br.GameBoard.GetLength(0) - 1; i >= 0; i--)
            for (int j = br.GameBoard.GetLength(1) - 1; j >= 0; j--)
            {

            }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
