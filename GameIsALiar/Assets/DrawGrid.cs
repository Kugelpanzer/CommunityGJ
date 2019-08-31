using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawGrid : MonoBehaviour
{
    [System.Serializable]
    public struct IdObj
    {
        public GameObject gj;
        public int id;
    }


    [Tooltip("if true moves ghoul, if false moves peasents")]
    public bool LevelFlag;

    public int PeasentVictory = 10;
    public Text ScoreUI;
    public Text RemainingPeasentsUI;
    public GameObject backgroundObj,grassObj,teleport;
    public List<IdObj> ConvertList = new List<IdObj>();



    #region PrivateProperties
    BoardClass br;
    LevelController lc;
    Dictionary<int,GameObject> DictList= new Dictionary<int,GameObject>();
    List<GameObject> ExistingObjects = new List<GameObject>();
    public List<GameObject> ExistingPeasents = new List<GameObject>();
    #endregion

    //public GridObject[,] Board;
    // Start is called before the first frame update

    void Start()
    {
        foreach (IdObj io in ConvertList)
        {
            DictList.Add(io.id, io.gj);
        }
        // Board = new GridObject[5, 5];

        br = GameObject.Find("BoardObj").GetComponent<BoardClass>();
        lc = GetComponent<LevelController>();
        SpawnBackground();

        br.SpawnWalls();
        /*br.SpawnGhoul(1, 1);
        br.SpawnPeasant(4,4);
        br.SpawnPeasant(5, 4);
        br.SpawnPeasant(5, 5);
        br.SpawnBlock(5, 6);
        br.SpawnBlock(6, 6);
        br.SpawnBlock(3, 3);*/
        if (!LevelFlag)
        {
            br.DestroyGhoul();
            br.SpawnRandomPeasants(5);
        }
        else
        {
            br.SpawnGhoul(4, 4);
        }
        UpdateGrid();
        br.DebugBoard();


        
    }


    private void ClearExisting()
    {
        if (ExistingObjects.Count != 0)
        {
            for (int i = 0; i < ExistingObjects.Count; i++)
            {
                if (ExistingObjects[i] != null)
                    Destroy(ExistingObjects[i]);
            }
            ExistingObjects.Clear();
        }
    }
    public void UpdateGrid(bool check=false) // Destroys all objects in grid and creates new ones
    {
        //Debug.Log(ExistingObjects.Count);
        if (check)
        {
            /*for (int i = 0; i < ExistingPeasents.Count; i++)
            {
                int xx, yy;
                xx=ExistingPeasents[i].GetComponent<PeasentScript>().posx;
                yy=ExistingPeasents[i].GetComponent<PeasentScript>().posy;
                if (br.GameBoard[yy,xx]!= (int)GamePiece.Peasant)
                {
                    ExistingPeasents[i].GetComponent<PeasentScript>().PeasentDeath();
                }
            }   */
        }

        ClearExisting();
        Sprite spr = backgroundObj.GetComponent<SpriteRenderer>().sprite;
        for (int i = 0; i < br.GameBoard.GetLength(0); i++)
            for (int j = 0; j < br.GameBoard.GetLength(1); j++)
            {
                //Debug.Log(br.GameBoard[i, j]);
                //gj = Instantiate(DictList[1]);
                if (DictList.ContainsKey(br.GameBoard[i, j]))
                {

                    //Debug.Log("z");
                    ExistingObjects.Add(Instantiate(DictList[br.GameBoard[i, j]]));
                    if (br.GameBoard[i, j] == (int)GamePiece.Peasant)
                    {
                        ExistingPeasents.Add(DictList[br.GameBoard[i, j]]);
                        ExistingPeasents[ExistingPeasents.Count - 1].GetComponent<PeasentScript>().posx = j;
                        ExistingPeasents[ExistingPeasents.Count - 1].GetComponent<PeasentScript>().posy = i;
                    }

                    //Sprite spr = ExistingObjects[ExistingObjects.Count - 1].GetComponent<SpriteRenderer>().sprite;
                    ExistingObjects[ExistingObjects.Count - 1].GetComponent<SortSprites>().CalcOrder(i);
                    ExistingObjects[ExistingObjects.Count - 1].transform.position = new Vector2(j * (spr.rect.width / 100), -i * (spr.rect.height / 100));

                    if (br.GameBoard[i, j] == (int)GamePiece.Tower2)
                    {
                        ExistingObjects.Add(Instantiate(teleport));
                        ExistingObjects[ExistingObjects.Count - 1].transform.position = new Vector2(j * (spr.rect.width / 100), -(i+5) * (spr.rect.height / 100));

                    }
                }
            }

    }
    public void SpawnBackground() //spawns background in a grid thats size of map
    {
        GameObject gj;
        Sprite spr = backgroundObj.GetComponent<SpriteRenderer>().sprite;
        for (int i = 0; i < br.GameBoard.GetLength(0)/2; i++)
            for (int j = 0; j < br.GameBoard.GetLength(1); j++)
            {

                gj = Instantiate(backgroundObj);
                gj.transform.position = new Vector2(j * (spr.rect.width / 100), -i * (spr.rect.height / 100));
            }
        spr = grassObj.GetComponent<SpriteRenderer>().sprite;
        for (int i = br.GameBoard.GetLength(0) / 2; i < br.GameBoard.GetLength(0) ; i++)
            for (int j = 0; j < br.GameBoard.GetLength(1); j++)
            {

                gj = Instantiate(grassObj);
                gj.transform.position = new Vector2(j * (spr.rect.width / 100), -i * (spr.rect.height / 100));
            }


    }
    public bool InputMoveGhoul()//keyboard input for ghoul
    {
       if(Input.GetKeyDown(KeyCode.D))
        {
            if (br.MoveGhoulD())
                return true;
            else
                return false;
        }
       if (Input.GetKeyDown(KeyCode.A))
        {
            if (br.MoveGhoulA())
                return true;
            else
                return false;
        }
       if (Input.GetKeyDown(KeyCode.S))
        {
            if (br.MoveGhoulS())
                return true;
            else
                return false;
        }
       if (Input.GetKeyDown(KeyCode.W))
        {
            if (br.MoveGhoulW())
                return true;
            else
                return false;

        }
        return false;

    }
    public bool InputMovePeasent()// keyboard input for peasent
    {

        InputMoveGhoul();
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

    public void CheckVictory()
    {
        ScoreUI.text = PeasentVictory.ToString() + " / " + br.Score;
        if (br.Score >= PeasentVictory)
        {
            lc.NextScene();
        }
        
        RemainingPeasentsUI.text = br.PeasantsAlive.ToString();
        if (br.Score + br.PeasantsAlive < PeasentVictory)
        {
            //Lose
        }
    }
    public void FireTowers()
    {
        br.FireDislocatingBeam();
        br.FirePetrificationRay();
        br.FireTornadoGenerator();
    }
    //Make move is called when any button is pressed 
    public void MakeMove()
    {
        if (LevelFlag)  //for first level when ghoul is moving
        {
            if (InputMoveGhoul())
            {
                UpdateGrid();
                lc.TakeTurn();
            }
        }
        else    //second level when peasents are moving 
        {
            if (InputMovePeasent())
            {


                UpdateGrid();
                FireTowers();

                //tower animation
                //peasent death
                ExistingPeasents.Clear();
                //UpdateGrid(true);
                br.ResetPeasents();
                CheckVictory();
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
