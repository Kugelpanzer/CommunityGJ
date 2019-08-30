using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardClass:MonoBehaviour
{
    #region properties 
    public int BoardWidth=0, BoardHeight=0;

    public int[,] GameBoard;

    public int Score = 0;
	public int PeasantsAlive = 15;
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
	
	public void killPeasant()
	{
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
					for (int k = i; k < GameBoard.GetLength(0); k++)
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
							GameBoard[i + 1, j] = (int)GamePiece.EmptyTile;
							GameBoard[i + 5, j] = (int)GamePiece.EmptyTile;
							killPeasant();
							killPeasant();
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
					
					for(int k = 0; k < 7; k++)
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
								killPeasant();
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
							killPeasant();
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

    public void SpawnPeasant(int i, int j)
    {
        GameBoard[i, j] = (int)GamePiece.Peasant;
    }
    public void SpawnGhoul (int i, int j)
    {
        GameBoard[i, j] = (int)GamePiece.Ghoul;
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
        for (int i = 0; i < GameBoard.GetLength(0); i++)
        {
			for (int j = 0; j < GameBoard.GetLength(1); j++)
            {
                if (i == 0 || j == 0 || i == GameBoard.GetLength(0) - 1 || j == GameBoard.GetLength(1) - 1)
                {
                    GameBoard[i, j] = (int)GamePiece.ImmovableBlock;
					
                }
            }
		}
		GameBoard[0, GameBoard.GetLength(1)/2] = (int)GamePiece.Door;
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
        GameBoard = new int[BoardWidth, BoardHeight]; 
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
	Door = 10
}