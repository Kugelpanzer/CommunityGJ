using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardClass:MonoBehaviour
{
    #region properties 
    public int BoardWidth=0, BoardHeight=0;

    public int[,] GameBoard;

    

    #endregion



    #region methods 
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

	public void MoveGhoulW()
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
                    }
                    else if (GameBoard[i - 1, j] > 3 &&  GameBoard[i - 1, j] < 8)
                    {
                        if (GameBoard[i - 2, j] == (int)GamePiece.EmptyTile)
						{
							GameBoard[i - 2, j] = GameBoard[i - 1, j];
							GameBoard[i - 1, j] = (int)GamePiece.Ghoul;
							GameBoard[i, j] = (int)GamePiece.EmptyTile;
						}
                    }
                }
            }
		}
    }
	
	public void MoveGhoulA()
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
                    }
                    else if (GameBoard[i, j - 1] > 3 &&  GameBoard[i, j - 1] < 8)
                    {
                        if (GameBoard[i, j - 2] == (int)GamePiece.EmptyTile)
						{
							GameBoard[i, j - 2] = GameBoard[i, j - 1];
							GameBoard[i, j - 1] = (int)GamePiece.Ghoul;
							GameBoard[i, j] = (int)GamePiece.EmptyTile;
						}
                    }
                }
            }
		}
	}
	
	
	public void MoveGhoulS()
    {
        for (int i = 0; i < GameBoard.GetLength(0); i++)
        {
			for (int j = 0; j < GameBoard.GetLength(1); j++)
            {
                if (GameBoard[i, j] == (int)GamePiece.Ghoul)
                {
                    if (GameBoard[i + 1, j] == (int)GamePiece.EmptyTile)
                    {
                        GameBoard[i + 1, j] = (int)GamePiece.Ghoul;
                        GameBoard[i, j] = (int)GamePiece.EmptyTile;
                    }
                    else if (GameBoard[i + 1, j] > 3 &&  GameBoard[i + 1, j] < 8)
                    {
                        if (GameBoard[i + 2, j] == (int)GamePiece.EmptyTile)
						{
							GameBoard[i + 2, j] = GameBoard[i + 1, j];
							GameBoard[i + 1, j] = (int)GamePiece.Ghoul;
							GameBoard[i, j] = (int)GamePiece.EmptyTile;
						}
                    }
                }
            }
		}
    }
	
	
	public void MoveGhoulD()
    {
        for (int i = 0; i < GameBoard.GetLength(0); i++)
        {
			for (int j = 0; j < GameBoard.GetLength(1); j++)
            {
                if (GameBoard[i, j] == (int)GamePiece.Ghoul)
                {
                    if (GameBoard[i, j + 1] == (int)GamePiece.EmptyTile)
                    {
                        GameBoard[i, j + 1] = (int)GamePiece.Ghoul;
                        GameBoard[i, j] = (int)GamePiece.EmptyTile;
                    }
                    else if (GameBoard[i, j + 1] > 3 &&  GameBoard[i, j + 1] < 8)
                    {
                        if (GameBoard[i, j + 2] == (int)GamePiece.EmptyTile)
						{
							GameBoard[i, j + 2] = GameBoard[i, j + 1];
							GameBoard[i, j + 1] = (int)GamePiece.Ghoul;
							GameBoard[i, j] = (int)GamePiece.EmptyTile;
						}
                    }
                }
            }
		}
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
						if (GameBoard[k, j] == (int)GamePiece.Peasant)
						{
							GameBoard[k, j] = (int)GamePiece.PetrifiedPeasant;
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
							//Add event for peasant death
						}
					
					}				
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
	PetrifiedPeasant = 9
}