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
    LevelController lc;

    [Tooltip("if false moves ghoul, if true moves peasents")]
    public bool LevelFlag;

    public GameObject backgroundObj;
    public List<IdObj> ConvertList = new List<IdObj>();
    Dictionary<int,GameObject> DictList= new Dictionary<int,GameObject>();

    List<GameObject> ExistingObjects = new List<GameObject>();
    //public GridObject[,] Board;
    // Start is called before the first frame update
    
    void Start()
    {
        foreach (IdObj io in ConvertList)
        {
            DictList.Add(io.id, io.gj);
        }
        // Board = new GridObject[5, 5];

        br = GetComponent<BoardClass>();
        lc = GetComponent<LevelController>();
        SpawnBackground();

        br.SpawnWalls();
        br.SpawnGhoul(1, 1);
        br.SpawnPeasant(4,4);
        br.SpawnPeasant(5, 4);
        br.SpawnPeasant(5, 5);
        br.SpawnBlock(5, 6);
        br.SpawnBlock(6, 6);
        br.SpawnBlock(3, 3);
        UpdateGrid();
        br.DebugBoard();


        
    }

    public void UpdateGrid()
    {
        //Debug.Log(ExistingObjects.Count);
        if (ExistingObjects.Count != 0)
        {
            for (int i = 0; i < ExistingObjects.Count; i++)
            {
                Destroy(ExistingObjects[i]);
            }
            ExistingObjects.Clear();
        }
        for (int i = 0; i < br.GameBoard.GetLength(0); i++)
            for (int j = 0; j < br.GameBoard.GetLength(1); j++)
            {
                //Debug.Log(br.GameBoard[i, j]);
                //gj = Instantiate(DictList[1]);
                if (DictList.ContainsKey(br.GameBoard[i, j]))
                {
                    //Debug.Log("z");
                    ExistingObjects.Add(Instantiate(DictList[br.GameBoard[i, j]]));
                    Sprite spr = ExistingObjects[ExistingObjects.Count - 1].GetComponent<SpriteRenderer>().sprite;
                    ExistingObjects[ExistingObjects.Count - 1].transform.position = new Vector2(j * (spr.rect.width / 100), -i * (spr.rect.height / 100));
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
                gj.transform.position = new Vector2(j * (spr.rect.width / 100), -i * (spr.rect.height / 100));
            }


    }
    public bool InputMoveGhoul()
    {
       if(Input.GetKeyDown(KeyCode.D))
        {
            br.MoveGhoulD();

            return true;
        }
       if (Input.GetKeyDown(KeyCode.A))
        {
            br.MoveGhoulA();

            return true;
        }
       if (Input.GetKeyDown(KeyCode.S))
        {
            br.MoveGhoulS();

            return true;
        }
       if (Input.GetKeyDown(KeyCode.W))
        {
            br.MoveGhoulW();

            return true;
        }
        return false;

    }
    public bool InputMovePeasent()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            br.MoveAllPeasantsD();

            return true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            br.MoveAllPeasantsA();

            return true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            br.MoveAllPeasantsS();

            return true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            br.MoveAllPeasantsW();

            return true;
        }

        return false;
    }

    public void MakeMove()
    {
        if (LevelFlag)
        {
            if (InputMoveGhoul())
            {
                UpdateGrid();
                lc.TakeTurn();
            }
        }
        else
        {
            if (InputMovePeasent())
            {
                UpdateGrid();
                br.ResetPeasents();
                lc.TakeTurn();

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        MakeMove();
    }
}
