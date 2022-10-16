using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject normalPath, box;
    public Transform pathParent;
    public int boxIndex;
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject path;
            if(i != boxIndex)
            {
                path = Instantiate(normalPath, pathParent);
            }
            else
            {
                path = Instantiate(box, pathParent);
            }
           
            path.transform.localPosition = new Vector3(0, 0, i * 10);
        }
    }
}
