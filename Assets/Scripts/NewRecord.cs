using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewRecord : MonoBehaviour
{
    GameObject nR;


    void Start()
    {
        nR = this.gameObject;
        if (Basket.newRec == true)
        {
            nR.SetActive(true);
        }
        else
        {
           nR.SetActive(false);
        }
    }


}
