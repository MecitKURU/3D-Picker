using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Multiplier : MonoBehaviour
{
    public int value;
    public Text myText;
    void Start()
    {
        myText.text = value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
