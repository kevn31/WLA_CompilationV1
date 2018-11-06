using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using WeLoveAero;


public class level3 : MonoBehaviour
    {

        public Text instructionTxt;

        public GameObject panelInstruction;
        public GameObject panelHiding;
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

        public Button btn_nextLevel;

        private OutTrigger scriptTrigger;
        public BaseAirplane_Input inputScript; //ligne OK

        private changementInput changementInputScript;


    void Start()
        {
            changementInputScript = GetComponent<changementInput>();

            if(changementInputScript.mobileInput)
            {
            level3 level3Script = GetComponent<level3>();
            level3Script.enabled = false;
            }
            rb = GetComponent<Rigidbody>();
            scriptTrigger = GetComponent<OutTrigger>();
            inputScript = GetComponent<XboxAirplane_Input>(); //ligne OK

            rb.angularVelocity = Vector3.zero;//ligne OK
            rb.velocity = new Vector3(0, 0, 53.0f);

            stepLearning = 0;
            stop = true;
            inputScript.stickyThrottle = 1f;

            apprentissageColor = joyStickL.GetComponent<Image>().color;

        }


        void Update()
        {

        //Debug.Log(stepLearning);
        if (scriptTrigger.teleportationResetStep)
        {
            if(numberTrigger == 1)
            {
                stepLearning = 0;
                numberCheckpoint = 0;
            }
            if (numberTrigger == 2)
            {
                stepLearning = 4;
                numberCheckpoint = 0;
            }
            if (numberTrigger == 3)
            {
                stepLearning = 9;
                numberCheckpoint = 0;
            }
        }
        


        if (stepLearning == 0)
            { 

                instructionTxt.enabled = true;
                manette.SetActive(true);
                instructionTxt.text = "<size=80>Move <color=#ffa500ff>right joystick</color> left and right</size>";

                joyStickR.GetComponent<Image>().color = apprentissageColor;
                joyStickL.GetComponent<Image>().color = Color.white;

                joyStickR.transform.GetChild(2).gameObject.SetActive(true);
                joyStickR.transform.GetChild(3).gameObject.SetActive(true);

            if (Input.GetAxis("Roll_Xbox") != 0 && stop)
            {
                StartCoroutine(waitBeforeStep(1f));
            }
        }


            if (stepLearning == 1 && stop)
            {
                

                instructionTxt.text = "Well Done, you used the <color=#ffa500ff>roll</color>";
                manette.SetActive(false);

                StartCoroutine(waitBeforeStep(4f));
            }

            if (stepLearning == 2 && stop)
            {
                manette.SetActive(false);
                instructionTxt.enabled = false;

                if (transform.rotation.eulerAngles.z < 5 || transform.rotation.eulerAngles.z > 350)
                {
                    Debug.Log("lancer phase suivante");
                    StartCoroutine(waitBeforeStep(1f));
                }
                else
                {
                    instructionTxt.enabled = true;
                    instructionTxt.text = "<size=80>To begin next phase put yourself straight in comparison to the floor</size>";
            }

                
            }

            if (stepLearning == 3 && stop)
            {
                instructionTxt.enabled = true;
                instructionTxt.text = "Now try to make a <color=#ffa500ff>360°</color> rotation";
                manette.SetActive(true);

            if (transform.rotation.eulerAngles.z > 170 && transform.rotation.eulerAngles.z < 190)
                {
                    stepLearning = 4; ;
                }
           
            }


            if (stepLearning == 4 && stop)
            {
            
                instructionTxt.enabled = true;

                manette.SetActive(false);
                instructionTxt.text = "Good ! Continue to finish the rotation !";
               

                if (transform.rotation.eulerAngles.z < 5 || transform.rotation.eulerAngles.z > 350)
                {
                    stepLearning = 5; ;
                }
        }


             if (stepLearning == 5 && stop)
             {
                instructionTxt.text = "<color=#ffa500ff>STOP</color>";
                StartCoroutine(waitBeforeStep(1f));
             }

             if (stepLearning == 6 && stop)
             {
                  instructionTxt.text = "<size=80>Well Done, you made your first figure.</size>";
                  StartCoroutine(waitBeforeStep(4f));
             }


            if (stepLearning == 7 && stop)
            {
            instructionTxt.text = "<size=80>This figure is called a <color=#ffa500ff>bareel roll</color>.</size>";
            StartCoroutine(waitBeforeStep(4f));
            }


            if (stepLearning == 8 && stop)
            {
                instructionTxt.enabled = false;
                instructionTxt.text = "Well Done";
               // StartCoroutine(waitBeforeStep(2f));
            }


            if (stepLearning ==9 && stop)
            {
                instructionTxt.enabled = true;
                instructionTxt.text = "Let's practice a little !";
                StartCoroutine(waitBeforeStep(2f));
            }


            if (stepLearning == 10 && stop)
            {
                instructionTxt.enabled = true;
                instructionTxt.text = "Finish the <color=#ffa500ff>5</color> rings left";
                StartCoroutine(waitBeforeStep(2f));
            }


            if (stepLearning == 11 && stop)
            {
                instructionTxt.enabled = false;
            }


            if (stepLearning == 12 && stop)
            {
                instructionTxt.enabled = true;
                instructionTxt.text = "Level clear";
                StartCoroutine(waitBeforeStep(3f));
            }

            if (stepLearning == 13 && stop)
            {
                instructionTxt.enabled = false;
                btn_nextLevel.interactable = true;
                btn_nextLevel.interactable = true;
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
            }

            if (other.name == "NextSequence01" && numberTrigger != 1)
            {
                numberCheckpoint = 0;
                stepLearning = 3;
            }

            if (other.name == "NextSequence02")
            {
                numberCheckpoint = 0;
                stepLearning = 7;
            }

            if (other.name == "NextSequence03")
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


    }


        void OnTriggerExit(Collider other)
        {
            if (other.tag == "gate")
            {
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
