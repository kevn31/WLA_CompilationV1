﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace WeLoveAero
{

    public class Throttle_Percentage : MonoBehaviour
    {
       Text percentageText;

        // Use this for initialization
        void Start()
        {
            percentageText = GetComponent<Text> ();
         
        }

        public void textUpdate (float Value)
        {
            percentageText.text = Mathf.Round(Value * 100) + " %";
           

        }
    }
}
