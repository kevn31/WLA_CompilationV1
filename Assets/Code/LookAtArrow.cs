using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtArrow : MonoBehaviour {

    public Transform[] target;
    public int numberPointArrow;
    private float dist;
    [SerializeField]
    private int numberGate;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if(numberPointArrow < numberGate)
        {
            dist = Vector3.Distance(transform.position, target[numberPointArrow].position);
            if (dist > 40)
            {
                transform.LookAt(target[numberPointArrow]);
            }
            else
            {
                transform.LookAt(target[numberPointArrow + 1]);
            }
        }
        
    }

    public void increaseNumberPointArrow()
    {
        Debug.Log("scriptLookAtArrow launching");
        numberPointArrow++;
    }

    public void decreaseeNumberPointArrow(int number)
    {
        numberPointArrow = number;
    }
}
