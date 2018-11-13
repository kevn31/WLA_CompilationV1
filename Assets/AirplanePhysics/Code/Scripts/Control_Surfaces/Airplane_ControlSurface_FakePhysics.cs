﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FakePhysics;


namespace FakePhysics
{
    public enum ControlSurfaceType
    {
        Rudder,
        Elevator,
        Flap,
        Aileron
    }

    public class Airplane_ControlSurface_FakePhysics : MonoBehaviour 
    {
        #region Variables
        [Header("Control Surfaces Properties")]
        public ControlSurfaceType type = ControlSurfaceType.Rudder;
        public float maxAngle = 30f;
        public Vector3 axis = Vector3.right;
        public Transform controlSurfaceGraphic;
        public float smoothSpeed = 2f;

        private float wantedAngle;
        #endregion



        #region Builtin Methods
    	// Use this for initialization
    	void Start () 
        {
    		
    	}
    	
    	// Update is called once per frame
    	void Update () 
        {
            if(controlSurfaceGraphic)
            {
                Vector3 finalAngleAxis = axis * wantedAngle;
                controlSurfaceGraphic.localRotation = Quaternion.Slerp(controlSurfaceGraphic.localRotation, Quaternion.Euler(finalAngleAxis), Time.deltaTime * smoothSpeed);
            }
         



        }
        #endregion



        #region Custom Methods
        public void HandleControlSurface(Hub_Input1 input)
        {
            float inputValue = 0f;
            switch(type)
            {
                case ControlSurfaceType.Rudder:
                    inputValue = input.f_yaw;
                    Debug.Log("test yax");
                    break;

                case ControlSurfaceType.Elevator:
                    inputValue = input.f_pitch;
                    Debug.Log("Test pitch");
                    break;


                case ControlSurfaceType.Aileron:
                    inputValue = input.f_roll;
                    break;

                default:
                    break;
            }

            wantedAngle = maxAngle * inputValue;
        }
        #endregion
    }
}
