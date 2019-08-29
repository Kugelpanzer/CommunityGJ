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

    public GameObject backgroundObj;
    public List<IdObj> ConvertList = new List<IdObj>();
    Dictionary<int,GameObject> DictList= new Dictionary<int,GameObject>();

    List<GameObject> ExistingObjects = new List<GameObject>();
    //public GridObject[,] Board;
    // Start is called before the first frame update
    
    void Start()
    {
        // Board = new GridObject[5, 5];

        br = GetComponent<BoardClass>();
        br.SpawnWalls();
        br.SpawnGhoul(1, 1);
        UpdateGrid();
        br.DebugBoard();

        foreach(IdObj io in ConvertList)
        {
            DictList.Add(io.id, io.gj);
        }
        SpawnBackground();
    }

    public void UpdateGrid()
    {

        if(ExistingObjects.Count!=0)
            for (int i = 0; i < ExistingObjects.Count - 1; i++)
            {
                 Destroy(ExistingObjects[i]);
            }
        Debug.Log(ExistingObjects.Count);
        for (int i = 0; i < br.GameBoard.GetLength(0); i++)
            for (int j = 0; j < br.GameBoard.GetLength(1); j++)
            {

                //gj = Instantiate(DictList[1]);
                if (DictList.ContainsKey(br.GameBoard[i, j]))
                {
                    ExistingObjects[ExistingObjects.Count - 1] = Instantiate(DictList[br.GameBoard[i, j]]);
                    Sprite spr = ExistingObjects[ExistingObjects.Count - 1].GetComponent<SpriteRenderer>().sprite;
                    ExistingObjects[ExistingObjects.Count - 1].transform.position = new Vector2(j * (spr.rect.width / 100), i * (spr.rect.height / 100));
                }
            }

    }
    public void SpawnBackground()
    {
        GameObject gj;

        for (int i = 0; i < br.GameBoard.GetLength(0); i++)
            for (int j = 0; j < br.GameBoard.GetLength(1); j++)
            {

                gj = Instantiate(backgroundObj);
                Sprite spr = gj.GetComponent<SpriteRenderer>().sprite;
                gj.transform.position = new Vector2(j * (spr.rect.width / 100), i * (spr.rect.height / 100));
            }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
