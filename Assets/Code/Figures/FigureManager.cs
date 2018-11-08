using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeLoveAero;

namespace WeLoveAero
{
    public class FigureManager : MonoBehaviour
    {
        ///////////// script////////////
        SaveContentBetweenScenesScript saveContentScript;

        private GameObject plane;
        private Vector3 planePosition;
        private Quaternion planeRotation;

        public GameObject[] prefabFigure;
        public bool alreadyPlace;

        private GameObject newFigure;
        private int futureFigure;

       // private FigureChoice scriptArrayFigure;

        private int numberStage;
        private int numberFigure;
        private int[,] figure;


        private int actualFigure;

        // Use this for initialization
        void Start()
        {
            saveContentScript = GameObject.Find("_manager").GetComponent<SaveContentBetweenScenesScript>();
            numberStage = 0;
            numberFigure = 0;
            actualFigure = 0;

            plane = GameObject.FindWithTag("planeGeneratorFigure");
            alreadyPlace = false;
            futureFigure = 0;
           // scriptArrayFigure = gameObject.GetComponent<FigureChoice>();

            Debug.Log("whé");

           // scriptArrayFigure.setTravelingVariable();
           // figure = scriptArrayFigure.travelingFigureArray;
            //figure[scriptArrayFigure.travelingLevelFigure, i]


        }

        //LoopPrefabFigure()
        //setScript()
        // Update is called once per frame

        void Update()
        {

            if (!alreadyPlace)
            {
                placePlane();
            }



        }

        void placePlane()
        {
            Debug.Log("PlacePlane");
            planePosition = plane.transform.position;
            planeRotation = Quaternion.Euler(new Vector3(0, plane.transform.rotation.eulerAngles.y, 0));
            Debug.Log(planeRotation);


            //newFigure = Instantiate(prefabFigure[figure[scriptArrayFigure.travelingLevelFigure, futureFigure]], planePosition, planeRotation);

            // figure = StaticfigureNumberTabSave
            // scriptArrayFigure.travelingLevelFigure, futureFigure devient le numero actuel de la figure
            newFigure = Instantiate(prefabFigure[saveContentScript.figureNumberTabSave[actualFigure]], planePosition, planeRotation);
            alreadyPlace = true;

            //Debug.Log(newFigure);
            LoopPrefabFigure scriptLoopPrefabFigure = plane.GetComponent<LoopPrefabFigure>();    //repere et permet d appeler le script en local


            scriptLoopPrefabFigure.setScript();
            futureFigure++;



        }

        public void allowToPlace()
        {
            Debug.Log("working");
            StartCoroutine(alreadyPlaceToFalse());
        }

        IEnumerator alreadyPlaceToFalse()
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log("placer figure");
            alreadyPlace = false;

        }
    }
}
