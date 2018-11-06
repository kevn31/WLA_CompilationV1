using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


    public class level2 : MonoBehaviour
    {

        public Text instructionTxt;

        public GameObject panelInstruction;
        public GameObject panelHiding;


        public Image altimeter;
        public Image airspeed;

        public GameObject canvas_EndLevel;

        public Image joyStickL;
        public Image joyStickR;
        public GameObject manette;

        public string[] nameGateCheckpoint;

        private Rigidbody rb;


        private int stepLearning = 0;
        private int numberCheckpoint = 0;
        private int numberTrigger = 1;
        private int numberGateToPass = 2;

        private bool stop;
        private bool incrementNumberCheckpoint = true;
        private bool playOnce = true;

        private Color apprentissageColor;
        private string test;

        private OutTrigger scriptTrigger;
        private LookAtArrow scriptLookAtArrow;
        [SerializeField]
        private GameObject modelArrow;
        private bool functionArrowAlreadyPlayed = false;

        private Vector3 rotationPlane;

    void Start()
        {

            rb = GetComponent<Rigidbody>();
            scriptTrigger = GetComponent<OutTrigger>();
            scriptLookAtArrow = modelArrow.GetComponent<LookAtArrow>();

        rb.angularVelocity = Vector3.zero;

            stepLearning = 0;
            stop = true;

            apprentissageColor = joyStickL.GetComponent<Image>().color;
            instructionTxt.enabled = true;
            manette.SetActive(true);
            instructionTxt.text = "<size=40><color=#ffa500ff>Start</color> by moving up the<color=#ffa500ff> left joystick </color></size>";
                       

            joyStickL.transform.GetChild(0).gameObject.SetActive(true);
            //joyStickL.transform.GetChild(1).gameObject.SetActive(true);



            airspeed.enabled = false;
            foreach (Transform child in airspeed.transform)
            {
            child.gameObject.SetActive(false);
            }


            panelHiding.SetActive(false);

        }


        void Update()
        {

        rotationPlane = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(rotationPlane.x, rotationPlane.y, 0);
        //Debug.Log(stepLearning);
        if (scriptTrigger.teleportationResetStep)
        {
            if(numberTrigger == 1)
            {
                stepLearning = 0;
                numberCheckpoint = 0;
                scriptLookAtArrow.decreaseeNumberPointArrow(0);
            }
            if (numberTrigger == 2)
            {
                stepLearning = 4;
                numberCheckpoint = 0;
                scriptLookAtArrow.decreaseeNumberPointArrow(3);
            }
            if (numberTrigger == 3)
            {
                stepLearning = 9;
                numberCheckpoint = 0;
                scriptLookAtArrow.decreaseeNumberPointArrow(6);
            }
        }



            if (stepLearning == 0)
            {
                 apprentissageColor = joyStickL.GetComponent<Image>().color;
                 instructionTxt.enabled = true;
                 manette.SetActive(true);
                 instructionTxt.text = "<size=40><color=#ffa500ff>Start</color> by moving up the<color=#ffa500ff> left joystick </color></size>";


                 joyStickL.transform.GetChild(0).gameObject.SetActive(true);
                //joyStickL.transform.GetChild(1).gameObject.SetActive(true);




            if (Input.GetAxis("Throttle_Xbox") != 0 && stop)
                {
                airspeed.enabled = true;
                    foreach (Transform child in airspeed.transform)
                    {
                        child.gameObject.SetActive(true);
                    }
                    StartCoroutine(waitBeforeStep(1.5f));
                }
            }


            if (stepLearning == 1 && stop)
            {
                manette.SetActive(false);
                instructionTxt.enabled = false;

            }

            if (stepLearning == 2 && stop)
            {
                manette.SetActive(false);
                instructionTxt.enabled = false;

            }

            if (stepLearning == 3 && stop)
            {
                instructionTxt.enabled = true;
                instructionTxt.text = "Well Done";
                joyStickR.transform.GetChild(0).gameObject.SetActive(false);
                joyStickR.transform.GetChild(1).gameObject.SetActive(false);
                StartCoroutine(waitBeforeStep(4f));

            }


            if (stepLearning == 4 && stop)
            {
                instructionTxt.enabled = true;

                manette.SetActive(true);

                joyStickL.GetComponent<Image>().color = apprentissageColor;
                joyStickR.GetComponent<Image>().color = Color.white;

                joyStickL.transform.GetChild(0).gameObject.SetActive(true);
                joyStickL.transform.GetChild(1).gameObject.SetActive(true);


                instructionTxt.text = "<size=40> To change <color=#ffa500ff>speed</color> move up and down the<color=#ffa500ff> left joystick </color></size>";
                panelHiding.SetActive(true);
                stepLearning = 5;
            }


            if (stepLearning == 5 && stop)
            {
                if (Input.GetAxis("Throttle_Xbox") != 0 && stop)
                {
                    panelHiding.SetActive(false);

                    StartCoroutine(waitBeforeStep(2f));
                }
            }


            if (stepLearning == 6 && stop)
            {
                manette.SetActive(false);
                instructionTxt.enabled = false;
            }


            if (stepLearning == 7 && stop)
            {
                panelHiding.SetActive(false);
                instructionTxt.enabled = true;
                instructionTxt.text = "Well Done";
                StartCoroutine(waitBeforeStep(2f));
            }


            if (stepLearning == 8 && stop)
            {
                instructionTxt.enabled = true;
                instructionTxt.text = "Let's practice a little !";
                StartCoroutine(waitBeforeStep(2f));
            }


            if (stepLearning == 9 && stop)
            {
                instructionTxt.enabled = true;
                instructionTxt.text = "Finish the <color=#ffa500ff>5</color> rings left";
                StartCoroutine(waitBeforeStep(2f));
            }


            if (stepLearning == 10 && stop)
            {
                instructionTxt.enabled = false;
            }


            if (stepLearning == 11 && stop)
            {
                instructionTxt.enabled = true;
                instructionTxt.text = "Level clear";
                StartCoroutine(waitBeforeStep(3f));
            }

            if (stepLearning == 12 && stop)
            {
                instructionTxt.enabled = false;
                canvas_EndLevel.SetActive(true);
            }





            if (instructionTxt.enabled == false)
            {
                //Debug.Log("Text et boite de text desactivé");
                panelInstruction.SetActive(false);
            }
            else
            {
                panelInstruction.SetActive(true);
            }


            if (numberCheckpoint == numberGateToPass)
            {
                numberTrigger++;
                scriptTrigger.getValor(false, numberTrigger, false);
                numberCheckpoint = 0;

            }


            if (numberTrigger == 3)
            {
                numberGateToPass = 4;
            }

            if (numberTrigger == 2)
            {
                numberGateToPass = 3;
            }
    }



        IEnumerator waitBeforeStep(float timer)
        {

            stop = false;
            yield return new WaitForSeconds(timer);
            stepLearning += 1;
            stop = true;
        }


        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "gate")
            {
                if (incrementNumberCheckpoint)
                {
                    numberCheckpoint += 1;
                    incrementNumberCheckpoint = false;
                }
                if(!functionArrowAlreadyPlayed)
            {
                scriptLookAtArrow.increaseNumberPointArrow();
                functionArrowAlreadyPlayed = true;
            }
             
        }

            if (other.name == "NextSequence01" && numberTrigger != 1)
            {
                numberCheckpoint = 0;
                stepLearning = 3;
            }

            if (other.name == "NextSequence02" && numberTrigger != 2)
            {
                numberCheckpoint = 0;
                stepLearning = 7;
            }

            if (other.name == "NextSequence03" && numberTrigger != 3)
            {
                numberCheckpoint = 0;
                stepLearning = 11;
            }
            

            if (numberTrigger == 1)
            {

                if (other.name == "NextSequence01")
                {
                    scriptTrigger.failLevel(true);
                    stepLearning = 0;
                }
            }

            if (numberTrigger == 2)
            {

                if (other.name == "NextSequence02")
                {
                    scriptTrigger.failLevel(false);
                    stepLearning = 4;
                }
            }

            if (numberTrigger == 3)
            {

                if (other.name == "NextSequence03")
                {
                    scriptTrigger.failLevel(false);
                    stepLearning = 9;
                }
            }


    }


        void OnTriggerExit(Collider other)
        {
            if (other.tag == "gate")
            {
                functionArrowAlreadyPlayed = false;
                incrementNumberCheckpoint = true;
                //Debug.Log(nameGateCheckpoint.Length);

                for (int i = 0; i < nameGateCheckpoint.Length; i++)
                {
                    if (other.name == nameGateCheckpoint[i])
                    {
                        numberCheckpoint = 0;


                        if (other.name == "Gate_006")
                        {
                            numberGateToPass = 4;
                        }

                        //Debug.Log("TRIGER NUMBER = " + numberTrigger);
                        //Debug.Log("number checkpoint = " + numberCheckpoint);
                    }
                }

        }
    }
 }
