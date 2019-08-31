using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasentScript : MonoBehaviour
{
   public  int posx, posy;

    public void PeasentDeath()
    {
        GetComponent<Animator>().SetBool("Smrt", true);
        Debug.Log("zzz");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
