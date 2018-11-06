using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class apprentissageControl : MonoBehaviour {

    public Text instructionTxt;

    public GameObject panelInstruction;
    public GameObject panelHiding;

    public Image arrow;
    public Image altimeter;
    public Image airSpeed;

    public GameObject firstDummyCheckpoint;
    public GameObject secondDummyCheckpoint;

    public Rigidbody rb;

    public GameObject canvas_EndLevel;

    public Image joyStickL;
    public Image joyStickR;
    public GameObject manette;
   

    private Vector3 checkpointPosition;
    private Quaternion checkpointRotation;

    private bool fadeFinish = false;
    private bool unfadeFinish = true;
    float time = 0;
    

    private int stepLearning = 0;
    private bool stop;

    public Image im;

    private Color orangeColor;
    // Use this for initialization

    /////////////////////////////  joyStickR.GetComponent<Image>().color = orangeColor;

    void Start () {
       
        stepLearning = 0;
        stop = true;
        fadeFinish = true;

        orangeColor = joyStickL.GetComponent<Image>().color;


        rb = GetComponent<Rigidbody>();


        instructionTxt.text = "Push to the top the <color=#ffa500ff>left joystick</color> to move forward";
        arrow.enabled = false;

        airSpeed.enabled = false;
        foreach (Transform child in airSpeed.transform)
        {
             child.gameObject.SetActive(false);
        }


        altimeter.enabled = false;
        foreach (Transform child in altimeter.transform)
        {
            child.gameObject.SetActive(false);
        }


        panelHiding.SetActive(false);

        checkpointPosition = firstDummyCheckpoint.transform.position;
        checkpointRotation = firstDummyCheckpoint.transform.rotation;


    }
	
	// Update is called once per frame
	void Update () {

        // Debug.Log(stepLearning);
        if (stepLearning == 0)
        {
            if (Input.GetAxis("X_RV_Stick") < 0 && stop)
            {

                instructionTxt.text = "Well done";
                manette.SetActive(false);
                StartCoroutine(waitBeforeStep(2f));
                
            }

            else if (Input.GetAxis("Throttle") > 0 && stop)
            {
                instructionTxt.text = "Wrong side";
            }

            else if (stop)
            {
                instructionTxt.text = "<size=40>Push the <color=#ffa500ff>left joystick to the top</color> to move forward</size>";
            }
        }

        if(stepLearning == 1 && stop)
        {
            airSpeed.enabled = true;
            foreach (Transform child in airSpeed.transform)
            {
                child.gameObject.SetActive(true);
            }
            // panelHiding.SetActive(true);
            arrow.enabled = true;
            instructionTxt.text = "<size=40>Push the <color=#ffa500ff>left joystick up and down</color> to change the <color=#ffa500ff>speed </color></size>";

            manette.SetActive(true);
            joyStickL.transform.GetChild(0).gameObject.SetActive(true);
            joyStickL.transform.GetChild(1).gameObject.SetActive(true);

            StartCoroutine(waitBeforeStep(5f));

        }


        if (stepLearning == 2 && stop)
        {
            panelHiding.SetActive(false);
            arrow.enabled = false;
            instructionTxt.enabled = false;

            manette.SetActive(false);
            joyStickL.transform.GetChild(0).gameObject.SetActive(false);
            joyStickL.transform.GetChild(1).gameObject.SetActive(false);
           

            StartCoroutine(waitBeforeStep(2f));
        }

        if (stepLearning == 3 && stop)
        {
            //Debug.Log(stepLearning);
            instructionTxt.enabled = true;
            altimeter.enabled = true;
            foreach (Transform child in altimeter.transform)
            {
                child.gameObject.SetActive(true);
            }
            instructionTxt.text = "<size=40>Change <color=#ffa500ff>altitude</color> by moving up and down the<color=#ffa500ff> right joystick </color></size>";


            manette.SetActive(true);

            joyStickR.GetComponent<Image>().color = orangeColor;
            joyStickL.GetComponent<Image>().color = Color.white;

            joyStickR.transform.GetChild(0).gameObject.SetActive(true);
            joyStickR.transform.GetChild(1).gameObject.SetActive(true);


            StartCoroutine(waitBeforeStep(3f));

        }

        if (stepLearning == 4 && stop)
        {
            instructionTxt.enabled = false;
            manette.SetActive(false);
            joyStickR.transform.GetChild(0).gameObject.SetActive(false);
            joyStickR.transform.GetChild(1).gameObject.SetActive(false);
        }

        if (stepLearning == 5 && stop)
        {
            instructionTxt.enabled = false;
        }

        if (stepLearning == 6 && stop)
        {
            instructionTxt.enabled = true;
            instructionTxt.text = "Well Done !";
            StartCoroutine(waitBeforeStep(1.5f));
        }

        if (stepLearning == 7 && stop)
        {
            instructionTxt.enabled = true;
            //instructionTxt.text = "Now we will learn to <color=#ffa500ff>turn easly</color> !";
            StartCoroutine(waitBeforeStep(0.01f));
        }

        if (stepLearning == 8 && stop)
        {
            instructionTxt.text = "<size=40>Push the <color=#ffa500ff>left joystick, left and right</color> to turn left and right !</size>";

            manette.SetActive(true);

            joyStickL.GetComponent<Image>().color = orangeColor;
            joyStickR.GetComponent<Image>().color = Color.white;

            joyStickL.transform.GetChild(2).gameObject.SetActive(true);
            joyStickL.transform.GetChild(3).gameObject.SetActive(true);

            StartCoroutine(waitBeforeStep(3f));
        }

        if (stepLearning == 9 && stop)
        {
            instructionTxt.enabled = false;
            manette.SetActive(false);
            joyStickL.transform.GetChild(2).gameObject.SetActive(false);
            joyStickL.transform.GetChild(3).gameObject.SetActive(false);
        }

        if (stepLearning == 10 && stop)
        {
            
            instructionTxt.enabled = true;
            instructionTxt.text = "Perfect";
            StartCoroutine(waitBeforeStep(3f));
        }

        if (stepLearning == 11 && stop)
        {
            instructionTxt.text = "<size=40>you can also <color=#ffa500ff>turn</color> by moving left and right the the<color=#ffa500ff> right joystick </color></size>";

            manette.SetActive(true);

            joyStickR.GetComponent<Image>().color = orangeColor;
            joyStickL.GetComponent<Image>().color = Color.white;

            joyStickR.transform.GetChild(2).gameObject.SetActive(true);
            joyStickR.transform.GetChild(3).gameObject.SetActive(true);


            StartCoroutine(waitBeforeStep(3f));
        }

        if (stepLearning == 12 && stop)
        {
            instructionTxt.text = "<size=40>Now we'll train a little more, it stays <color=#ffa500ff>3</color> last gate</size>";
            StartCoroutine(waitBeforeStep(3f));
        }

        if (stepLearning == 13 && stop)
        {
            instructionTxt.enabled = false;
        }


        if (stepLearning == 14 && stop)
        {
            instructionTxt.enabled = true;
            instructionTxt.text = "Level clear";
            StartCoroutine(waitBeforeStep(3f));
        }

        if (stepLearning == 15 && stop)
        {
            instructionTxt.enabled = false;
            canvas_EndLevel.SetActive(true);
        }



        if (instructionTxt.enabled == false)
        {
            Debug.Log("Text et boite de text desactivé");
            panelInstruction.SetActive(false);
        }
        else
        {
            panelInstruction.SetActive(true);
        }



        if(!fadeFinish)
        {
            time += Time.deltaTime*100;

            //Debug.Log(time / 100);
            var tempColor = im.color;
            tempColor.a += time / 100;
            im.color = tempColor;


            if (time >= 100)
            {
                fadeFinish = true;
                unfadeFinish = false;
            }

            else
            {
                fadeFinish = false;
            }
        }
        

        if (!unfadeFinish)
        {
            Debug.Log(time);
            time += Time.deltaTime * 100;

            Debug.Log(im.color);
            var tempColor = im.color;
            tempColor.a -= time / 100;
            im.color = tempColor; ;


            if (time <= 0)
            {
               
                unfadeFinish = true;
            }

            else
            {
                unfadeFinish = false;
            }
        }
    }


    IEnumerator waitBeforeStep(float timer)
    {
        Debug.Log("go");
        stop = false;
        yield return new WaitForSeconds(timer);
        Debug.Log("stop");
        stepLearning +=1;
        stop = true;
    }


    void OnTriggerEnter(Collider other)
    {
      if (other.name == "Gate_001")
        {
            stepLearning = 5;
        }

      else if (other.name == "Gate_003")
        {
            stepLearning = 6;
        }

        else if (other.name == "Gate_008")
        {
            stepLearning = 10;
        }

        else if (other.name == "Gate_011")
        {
            stepLearning = 14;
        }

       
    }


    

    void OnTriggerExit(Collider other)
    {
      if(other.name == "triggerCheckpoint1" && stepLearning < 6)
        {
            fadeFinish = false;

            transform.position = checkpointPosition;
            transform.rotation = checkpointRotation;

            rb.angularVelocity = Vector3.zero;
            rb.velocity = new Vector3(-3.5f, 5.4f, 53.0f);



        }
    }
}
