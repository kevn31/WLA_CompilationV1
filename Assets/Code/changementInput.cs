using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeLoveAero;

public class changementInput : MonoBehaviour {

    /// <summary>
    /// Si les changements sur les cripts sont effectués avant que le booleane soit bon, mettre toutes les fonctions dans le Start() dans une public void appellé juste après changeInput()
    /// </summary>

    public bool mobileInput = true;

    [SerializeField]
    private GameObject Mobile_Canvas, Throttle_Lever,manette1;
    public RectTransform Panel_InstructionTxt;


    private XboxAirplane_Input xboxScript;
    private MobileAirplane_Input mobileScript;
    

    // Use this for initialization
    void Start () {
        

        xboxScript = GetComponent<XboxAirplane_Input>(); //ligne OK
        mobileScript = GetComponent<MobileAirplane_Input>(); //ligne OK

        if (mobileInput)
        {
            Mobile_Canvas.SetActive(true);
            Throttle_Lever.SetActive(false);

            Panel_InstructionTxt.position = new Vector2(Screen.width/2, Screen.height/1.25f);

            manette1.SetActive(false);

            xboxScript.enabled = false;
            mobileScript.enabled = true;
        }


        else
        {
            Mobile_Canvas.SetActive(false);
            Throttle_Lever.SetActive(true);
            xboxScript.enabled = true;
            mobileScript.enabled = false;
        }

    }
	
	// Update is called once per frame
	void Update () {

		
	}

    public void changeInput(bool mobile)
    {
        mobileInput = mobile;
    }
}
