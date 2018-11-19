using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WeLoveAero;

namespace WeLoveAero
{
    public class testInGameData : MonoBehaviour
    {
        SaveContentBetweenScenesScript saveContentScript;
        public SaveContentBetweenScenesScript testSccript;
        public bool test;

        // Use this for initialization
        void Start()
        {
            saveContentScript = GameObject.Find("_manager").GetComponent<SaveContentBetweenScenesScript>();


       //     Debug.Log("model de l avion:  " + testSccript.ModelAvion);
            test = false;
            // Debug.Log( "model de l avion:  " + testSccript.StaticModelAvionTest);
         
            

        }

        void Update()
        {
            if (saveContentScript != null)
            {
               // Debug.Log("marche ");
               //saveContentScript.WritheValuesEvent();
                for (int i = 0; i < 5; i++) //assigne valeurs
                {
                   // Debug.Log("figure numero" + i + " : " + saveContentScript.figureNumberTabSave[i]);
                }
            }
           else
            {
                Debug.Log("marche pas");
            }    
            if (test == true)
            {
                //testSccript.ModelAvion = null;
                Debug.Log("model de l avion:  " + testSccript.ModelAvion);
            }
        }
    }
}
