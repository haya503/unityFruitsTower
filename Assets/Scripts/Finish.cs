using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FInish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerPrefs.GetInt("score");
        Debug.Log("score:" + score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
