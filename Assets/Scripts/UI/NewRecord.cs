﻿using UnityEngine;
using UnityEngine.UI;

public class NewRecord : MonoBehaviour
{
    private Text newRecord;

    private void Awake()
    {
        newRecord = this.GetComponent<Text>();
    }

    private void Start()
    {
        if (GameManager.isRecord)
        {
            newRecord.text = "New Record!";
        }
        else
        {
            newRecord.text = "";
        }
        
    }
}
