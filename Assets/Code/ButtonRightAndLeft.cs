using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using FakePhysics;

public class ButtonRightAndLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{

    public GameObject plane;
    private Hub_Input Hub_InputScript;
    [SerializeField]
    private bool isRight;


    void Start()
    {
        Hub_InputScript = plane.GetComponent<Hub_Input>();
    }


    void Update()
    {
        if (!ispressed)
        {
          //  Hub_InputScript.buttonNotOnClick(isRight);
        }

        else
        {
            Hub_InputScript.buttonOnClick(isRight);
        }
    }


    bool ispressed = false;


    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ispressed = false;
    }
}
