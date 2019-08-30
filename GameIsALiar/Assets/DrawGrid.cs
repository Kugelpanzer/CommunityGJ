﻿using System.Collections;
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

    public void UpdateGrid() // Destroys all objects in grid and creates new ones
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
    public void SpawnBackground() //spawns background in a grid thats size of map
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
