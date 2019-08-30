using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulLevelController : LevelController
{
    public int Turns;
    public int CurrentTurns;
    // Start is called before the first frame update
    void Start()
    {
        CurrentTurns = Turns;   
    }
    public override void TakeTurn()
    {
        base.TakeTurn();
        if (CurrentTurns > 0)
            CurrentTurns--;
        else
            NextScene();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
