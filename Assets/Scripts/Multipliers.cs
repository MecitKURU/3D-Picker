using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multipliers : MonoBehaviour
{
    public GameObject multiplier;
    void Start()
    {
        for(int i = 0; i < 13; i++)
        {
            GameObject newMultiplier = Instantiate(multiplier, transform);
            newMultiplier.transform.localPosition = new Vector3(Random.Range(-0.3f, 0.3f), 0.16f, -0.35f + i * 0.05f);
            newMultiplier.GetComponent<Multiplier>().value = i * 20;
        }
    }
}
