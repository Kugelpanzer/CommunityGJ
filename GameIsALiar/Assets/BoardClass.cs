﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardClass:MonoBehaviour
{
    #region properties 
    public int BoardWidth=0, BoardHeight=0;

    public int[,] GameBoard;

    public int Score = 0;
	public int PeasantsAlive = 15;

    struct posToElem
    {
        public int x, y, elem;
    };

    public static BoardClass instance;
    #endregion



    #region methods 
	public void increaseScore()
	{
		Score++;
        /*
		//Display Score
		if(Score >= WinCondition)
		{
			//Win
		}
        */	
	}

    public void killPeasant(int i = -1, int j = -1)
    {
        DrawGrid dg = GameObject.Find("Controller").GetComponent<DrawGrid>();
        if (i != -1 && j != -1)
        {
           foreach(GameObject gj in dg.ExistingPeasents)
            { int xx=gj.GetComponent<PeasentScript>().posx, yy = gj.GetComponent<PeasentScript>().posy;
                if(yy==i && xx == j)
                {
                    gj.GetComponent<PeasentScript>().PeasentDeath();
                }
            }
        }
		PeasantsAlive--;
		/*
         //Display Number of living peasants
		if(Score + PeasantsAlive < WinCondition)
		{
			//Lose
		}	
        */
	}
	
    public void MoveAllPeasantsW()
    {
        for (int i = 0; i < GameBoard.GetLength(0); i++)
        {
			for (int j = 0; j < GameBoard.GetLength(1); j++)
            {
                if (GameBoard[i, j] == (int)GamePiece.Peasant)
                {
                    if (GameBoard[i - 1, j] == (int)GamePiece.EmptyTile)
                    {
                        GameBoard[i - 1, j] = (int)GamePiece.Peasant;
                        GameBoard[i, j] = (int)GamePiece.EmptyTile;
                    } 
					else if (GameBoard[i - 1, j] == (int)GamePiece.Door)
					{
						increaseScore();
						killPeasant();
						GameBoard[i, j] = (int)GamePiece.EmptyTile;
					}
                    else
                    {
                        GameBoard[i, j] = (int)GamePiece.StunnedPeasant;
                    }
                }
            }
		}
    }

    public void MoveAllPeasantsA()
    {
        for (int i = 0; i < GameBoard.GetLength(0); i++)
        {
			for (int j = 0; j < GameBoard.GetLength(1); j++)
            {
                if (GameBoard[i, j] == (int)GamePiece.Peasant)
                {
                    if (GameBoard[i, j - 1] == (int)GamePiece.EmptyTile)
                    {
                        GameBoard[i, j - 1] = (int)GamePiece.Peasant;
                        GameBoard[i, j] = (int)GamePiece.EmptyTile;
                    }
                    else
                    {
                        GameBoard[i, j] = (int)GamePiece.StunnedPeasant;
                    }
                }
            }
		}
    }


    public void MoveAllPeasantsS()
    {
        for (int i = GameBoard.GetLength(0) - 1; i >= 0; i--)
        {   
			for (int j = GameBoard.GetLength(1) - 1; j >= 0; j--)
            {
                if (GameBoard[i, j] == (int)GamePiece.Peasant)
                {
                    if (GameBoard[i + 1, j] == (int)GamePiece.EmptyTile)
                    {
                        GameBoard[i + 1, j] = (int)GamePiece.Peasant;
                        GameBoard[i, j] = (int)GamePiece.EmptyTile;
                    }
                    else
                    {
                        GameBoard[i, j] = (int)GamePiece.StunnedPeasant;
                    }
                }
            }
		}
    }

    public void MoveAllPeasantsD()
    {
        for (int i = GameBoard.GetLength(0) - 1; i >= 0; i--)
        {
			for (int j = GameBoard.GetLength(1) - 1; j >= 0; j--)
            {
                if (GameBoard[i, j] == (int)GamePiece.Peasant)
                {
                    if (GameBoard[i, j + 1] == (int)GamePiece.EmptyTile)
                    {
                        GameBoard[i, j + 1] = (int)GamePiece.Peasant;
                        GameBoard[i, j] = (int)GamePiece.EmptyTile;
                    }
                    else
                    {
                        GameBoard[i, j] = (int)GamePiece.StunnedPeasant;
                    }
                }
            }
		}
    }

	public bool MoveGhoulW()
    {
        for (int i = 0; i < GameBoard.GetLength(0); i++)
        {
			for (int j = 0; j < GameBoard.GetLength(1); j++)
            {
                if (GameBoard[i, j] == (int)GamePiece.Ghoul)
                {
                    if (GameBoard[i - 1, j] == (int)GamePiece.EmptyTile)
                    {
                        GameBoard[i - 1, j] = (int)GamePiece.Ghoul;
                        GameBoard[i, j] = (int)GamePiece.EmptyTile;
                        return true;
                    }
                    else if (GameBoard[i - 1, j] > 3 &&  GameBoard[i - 1, j] < 8)
                    {
                        if (GameBoard[i - 2, j] == (int)GamePiece.EmptyTile)
						{
							GameBoard[i - 2, j] = GameBoard[i - 1, j];
							GameBoard[i - 1, j] = (int)GamePiece.Ghoul;
							GameBoard[i, j] = (int)GamePiece.EmptyTile;
                            return true;
						}
                    }
                }
            }
		}
        return false;
    }
	
	public bool MoveGhoulA()
    {
        for (int i = 0; i < GameBoard.GetLength(0); i++)
        {
			for (int j = 0; j < GameBoard.GetLength(1); j++)
            {
                if (GameBoard[i, j] == (int)GamePiece.Ghoul)
                {
                    if (GameBoard[i, j - 1] == (int)GamePiece.EmptyTile)
                    {
                        GameBoard[i, j - 1] = (int)GamePiece.Ghoul;
                        GameBoard[i, j] = (int)GamePiece.EmptyTile;
                        return true;
                    }
                    else if (GameBoard[i, j - 1] > 3 &&  GameBoard[i, j - 1] < 8)
                    {
                        if (GameBoard[i, j - 2] == (int)GamePiece.EmptyTile)
                        {
                            GameBoard[i, j - 2] = GameBoard[i, j - 1];
                            GameBoard[i, j - 1] = (int)GamePiece.Ghoul;
                            GameBoard[i, j] = (int)GamePiece.EmptyTile;
                            return true;
                        }

                    }
                }
            }
		}
        return false;
	}
	
	
	public bool MoveGhoulS()
    {
        int pomX = 0, pomY = 0;
        bool flag = false;
        for (int i = 0; i < GameBoard.GetLength(0); i++)
        {
			for (int j = 0; j < GameBoard.GetLength(1); j++)
            {
                if (GameBoard[i, j] == (int)GamePiece.Ghoul)
                {
                    flag = true;
                    pomX = j;
                    pomY = i;
                }
            }
		}
        if (flag)
        {
            if (GameBoard[pomY + 1, pomX] == (int)GamePiece.EmptyTile)
            {
                GameBoard[pomY + 1, pomX] = (int)GamePiece.Ghoul;
                GameBoard[pomY, pomX] = (int)GamePiece.EmptyTile;
                return true;
            }
            else if (GameBoard[pomY + 1, pomX] > 3 && GameBoard[pomY + 1, pomX] < 8)
            {
                if (GameBoard[pomY + 2, pomX] == (int)GamePiece.EmptyTile)
                {
                    GameBoard[pomY + 2, pomX] = GameBoard[pomY + 1, pomX];
                    GameBoard[pomY + 1, pomX] = (int)GamePiece.Ghoul;
                    GameBoard[pomY, pomX] = (int)GamePiece.EmptyTile;
                    return true;
                }
            }
        }
        return false;
    }
	
	
	public bool MoveGhoulD()
    {
        int pomX=0, pomY=0;
        bool flag = false;
        for (int i = 0; i < GameBoard.GetLength(0); i++)
        {
			for (int j = 0; j < GameBoard.GetLength(1); j++)
            {
                if (GameBoard[i, j] == (int)GamePiece.Ghoul)
                {
                    flag = true;
                    pomX = j;
                    pomY = i;
                }
            }
		}
        if (flag)
        {
            if (GameBoard[pomY, pomX + 1] == (int)GamePiece.EmptyTile)
            {
                GameBoard[pomY, pomX + 1] = (int)GamePiece.Ghoul;
                GameBoard[pomY, pomX] = (int)GamePiece.EmptyTile;
                return true;
            }
            else if (GameBoard[pomY, pomX + 1] > 3 && GameBoard[pomY, pomX + 1] < 8)
            {
                if (GameBoard[pomY, pomX + 2] == (int)GamePiece.EmptyTile)
                {
                    GameBoard[pomY, pomX + 2] = GameBoard[pomY, pomX + 1];
                    GameBoard[pomY, pomX + 1] = (int)GamePiece.Ghoul;
                    GameBoard[pomY, pomX] = (int)GamePiece.EmptyTile;
                    return true;
                }
            }
        }
        return false;
    }
	
	public void FirePetrificationRay()
    {
        for (int i = 0; i < GameBoard.GetLength(0); i++)
        {
			for (int j = 0; j < GameBoard.GetLength(1); j++)
            {
                if (GameBoard[i, j] == (int)GamePiece.Tower1)
                {
					for (int k = i+1; k < GameBoard.GetLength(0); k++)
					{
						if (GameBoard[k, j] != (int)GamePiece.EmptyTile)
						{
							if (GameBoard[k, j] == (int)GamePiece.Peasant)
							{
								GameBoard[k, j] = (int)GamePiece.PetrifiedPeasant;
								killPeasant();
								return;
							}
							return;
						}
					}					
                }
            }
		}
    }
	
	public void FireDislocatingBeam()
    {
        for (int i = 0; i < GameBoard.GetLength(0); i++)
        {
			for (int j = 0; j < GameBoard.GetLength(1); j++)
            {
                if (GameBoard[i, j] == (int)GamePiece.Tower2)
                {
					if (GameBoard[i + 1, j] == (int)GamePiece.Peasant)
					{
						if (GameBoard[i + 5, j] == (int)GamePiece.EmptyTile)
						{
							GameBoard[i + 1, j] = (int)GamePiece.EmptyTile;
							GameBoard[i + 5, j] = (int)GamePiece.Peasant;
						} 
						else if (GameBoard[i + 5, j] == (int)GamePiece.Peasant)
						{
                            killPeasant(i + 5, j);
                            killPeasant(i+1,j);
                            GameBoard[i + 1, j] = (int)GamePiece.EmptyTile;
							GameBoard[i + 5, j] = (int)GamePiece.EmptyTile;

						}
					
					}				
                }
            }
		}
    }
	
	
	public void FireTornadoGenerator()
    {
		int [] MoveElements = new int[8];
		bool [] ContainsPeasant = new bool[8] { false,  false, false, false, false, false, false, false};

        for (int i = 0; i < GameBoard.GetLength(0); i++)
        {
			for (int j = 0; j < GameBoard.GetLength(1); j++)
            {
                if (GameBoard[i, j] == (int)GamePiece.Tower3)
                {
					MoveElements[0] = GameBoard[i+1, j-1];
					MoveElements[1] = GameBoard[i+1, j];
					MoveElements[2] = GameBoard[i+1, j+1];
					MoveElements[3] = GameBoard[i, j+1];
					MoveElements[4] = GameBoard[i-1, j+1];
					MoveElements[5] = GameBoard[i-1, j];
					MoveElements[6] = GameBoard[i-1, j-1];
					MoveElements[7] = GameBoard[i, j-1];
                    // nisam znao kako lakse animaciju za smrt da uradim
                    List<posToElem> curr = new List<posToElem>();
                    posToElem p= new posToElem();
                    p = new posToElem();
                    p.elem = 0;p.y = i + 1; p.x = j - 1;
                    curr.Add(p);
                    p = new posToElem();
                    p.elem = 1;  p.y = i + 1; p.x = j;
                    curr.Add(p);
                    p = new posToElem();
                    p.elem = 2; p.y = i + 1; p.x = j+1;
                    curr.Add(p);
                    p = new posToElem();
                    p.elem = 3; p.y = i; p.x = j + 1;
                    curr.Add(p);
                    p = new posToElem();
                    p.elem = 4; p.y = i - 1; p.x = j + 1;
                    curr.Add(p);
                    p = new posToElem();
                    p.elem = 5; p.y = i -1; p.x = j;
                    curr.Add(p);
                    p = new posToElem();
                    p.elem = 6; p.y = i - 1; p.x = j-1;
                    curr.Add(p);
                    p = new posToElem();
                    p.elem = 7; p.y = i; p.x = j-1;
                    curr.Add(p);



                    //curr.Add()
                    for (int k = 0; k < 7; k++)
					{
						if (MoveElements[k] == (int)GamePiece.Peasant)
						{
							if (MoveElements[k+1] == (int)GamePiece.EmptyTile || MoveElements[k+1] == (int)GamePiece.Peasant)
							{
								MoveElements[k] = (int)GamePiece.EmptyTile;
								ContainsPeasant[k+1] = true;
							}
							else 
							{
								MoveElements[k] = (int)GamePiece.EmptyTile;
								killPeasant(curr[k].y,curr[k].x);
							}
						}
					}
					if (MoveElements[7] == (int)GamePiece.Peasant)
					{
						if (MoveElements[0] == (int)GamePiece.EmptyTile || MoveElements[0] == (int)GamePiece.Peasant)
						{
							MoveElements[7] = (int)GamePiece.EmptyTile;
							ContainsPeasant[0] = true;
						}
						else 
						{
							MoveElements[7] = (int)GamePiece.EmptyTile;
							killPeasant(curr[7].y, curr[7].x);
						}
					}		
					for(int k = 0; k < 7; k++)
					{
						if(ContainsPeasant[k])
						{
							MoveElements[k] = (int)GamePiece.Peasant;
						}
					}
					GameBoard[i+1, j-1] = MoveElements[0];
					GameBoard[i+1, j] = MoveElements[1];
					GameBoard[i+1, j+1] = MoveElements[2];
					GameBoard[i, j+1] = MoveElements[3];
					GameBoard[i-1, j+1] = MoveElements[4];
					GameBoard[i-1, j] = MoveElements[5];
					GameBoard[i-1, j-1] = MoveElements[6];
					GameBoard[i, j-1] = MoveElements[7];					
                }
            }
		}
    }
    public void SpawnRandomPeasants(int startY)
    {
        int startX = BoardWidth / 2;
        SpawnGhoul(startY, startX);
        int currentPeasants = PeasantsAlive;
        int checker = 0;
        while (currentPeasants >= 0)
        {
            checker++;
            if (checker == 10)
                break;
            int br = 0;
            for (int i = startY + 1; i < BoardHeight; i++)
            {
                if(br*2+1<BoardWidth)
                    br++;
                    
                for (int j =startX-br;j<startX+br+1;j++)
                    if (Random.Range(0f, 1f) > 0.15f)
                    {
                        if (SpawnPeasant(i, j))
                            currentPeasants--;
                        if (currentPeasants <= 0)
                            return;
                    }

            }
        }
    }
    public bool SpawnPeasant(int i, int j)
    {
        if (GameBoard[i, j] == (int)GamePiece.EmptyTile)
        {
            GameBoard[i, j] = (int)GamePiece.Peasant;
            return true;
        }
        return false;
    }
    public void SpawnGhoul (int i, int j)
    {
        GameBoard[i, j] = (int)GamePiece.Ghoul;
    }
    public void DestroyGhoul()
    {
        for (int i = 0; i < GameBoard.GetLength(0); i++)
            for (int j = 0; j < GameBoard.GetLength(1); j++)
            {
                if (GameBoard[i, j] == (int)GamePiece.Ghoul)
                {
                    GameBoard[i, j] = (int)GamePiece.EmptyTile;
                }
            }
    }
    public void SpawnBlock(int i, int j)
    {
        GameBoard[i, j] = (int)GamePiece.MovableBlock;
    }

    public void ResetPeasents()
    {
        for (int i = 0; i < GameBoard.GetLength(0); i++)
            for (int j = 0; j < GameBoard.GetLength(1); j++)
                if (GameBoard[i, j] == (int)GamePiece.StunnedPeasant)
                    GameBoard[i, j] = (int)GamePiece.Peasant;
    }

    public void SpawnWalls()
    {
		for (int i = 0; i < 13; i++)
        {
			for (int j = 0; j < GameBoard.GetLength(1); j++)
            {
                if (i == 0 || j == 0 || i == 12 || j == GameBoard.GetLength(1) - 1)
                {
                    GameBoard[i, j] = (int)GamePiece.ImmovableBlock;
					
                }
            }
		}
		GameBoard[0, GameBoard.GetLength(1)/2] = (int)GamePiece.Door;
		
		GameBoard[12, 3] = (int)GamePiece.Door;
		GameBoard[12, 6] = (int)GamePiece.Door;
		GameBoard[12, 9] = (int)GamePiece.Door;
		
		GameBoard[4,5] = (int)GamePiece.Tower1;
		GameBoard[4,6] = (int)GamePiece.Tower2;
		GameBoard[4,7] = (int)GamePiece.Tower3;
		GameBoard[5,6] = (int)GamePiece.MovableBlock;
		GameBoard[8,7] = (int)GamePiece.MovableBlock;
		GameBoard[10,6] = (int)GamePiece.MovableBlock;
		GameBoard[3,10] = (int)GamePiece.MovableBlock;
        GameBoard[4, 10] = (int)GamePiece.MovableBlock;
        GameBoard[5, 10] = (int)GamePiece.MovableBlock;
        GameBoard[6, 8] = (int)GamePiece.MovableBlock;
        GameBoard[5, 11] = (int)GamePiece.MovableBlock;
        GameBoard[4, 2] = (int)GamePiece.MovableBlock;
        GameBoard[3, 4] = (int)GamePiece.MovableBlock;

    }
	

	

    public void DebugBoard()
    {
        string debugStr="";
        for (int i = 0; i < GameBoard.GetLength(0); i++)
        {
            debugStr += "\n";
            for (int j = 0; j < GameBoard.GetLength(1); j++)
            {
                debugStr += GameBoard[i, j].ToString();
            }
        }
        Debug.Log(debugStr);
    }

    private void Awake()
    {
        GameBoard = new int[BoardHeight, BoardWidth];

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }    
        DontDestroyOnLoad(gameObject);
    }
    #endregion



}
enum GamePiece
{
    EmptyTile = 0,
    ImmovableBlock = 1,
    Ghoul = 2,
    Peasant = 3,
	MovableBlock = 4,
    Tower1 = 5,
    Tower2 = 6,
    Tower3 = 7,
    StunnedPeasant = 8,
	PetrifiedPeasant = 9,
	Door = 10,
	
}