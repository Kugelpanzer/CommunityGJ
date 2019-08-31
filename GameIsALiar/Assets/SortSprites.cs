using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortSprites : MonoBehaviour
{
    //GameObject cont;
    public int OrderInLayer = 0;
    // Start is called before the first frame update
    void Start()
    {
        //cont=GameObject.Find("Controller")

    }
    public void CalcOrder(int order)
    {
        GetComponent<SpriteRenderer>().sortingOrder = order;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
