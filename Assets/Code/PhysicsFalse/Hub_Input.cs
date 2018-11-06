using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace FakePhysics
{
    public class Hub_Input : MonoBehaviour

    {
        #region Variables

        [SerializeField]
        private bool rollUnactive, throttleUnactive;
        [SerializeField]
        private float f_StickyThrottleValor, f_maxSpeed;
        private float f_xSpeed;
        public float reactivity;
        public Vector3 pastRotationForTheYaw;
        public Vector3 pastRotationForTheRoll;

        protected float f_pitch = 0f;
        protected float f_actualPitch = 0f;

        protected float f_roll = 0f;
        protected float f_yaw = 0f;
        protected float f_throttle = 0f;
        public float f_throttleSpeed, f_pitchSpeed = 0.5f;

        private float f_speed = 0f;

        public Slider ValeurSlider;

        public float f_stickyThrottle;
        public float f_StickyThrottle
        {
            get { return f_stickyThrottle; }
        }

        private float canTurn = 0;
        [SerializeField]
        private float maxTurn;
        #endregion



       // Use this for initialization
       void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            StickyThrottleControl();
            HandleInput();
            setSpeed();
            setPitch();
            setYaw();
            setRoll();
            ClampInputs();


            transform.Translate(Vector3.forward*Time.deltaTime * f_speed);
        }

        //Create a Throttle Value that gradually grows and shrinks
        protected virtual void StickyThrottleControl()
        {
            f_stickyThrottle = f_stickyThrottle + (-f_throttle * f_throttleSpeed * Time.deltaTime);

            //f_stickyThrottle = ValeurSlider.value;

            ValeurSlider.value = f_stickyThrottle;
        }

        protected virtual void HandleInput()
        {
            //Process Main Control Input

            f_pitch = Input.GetAxis("Pitch_manette");


            
            if (!rollUnactive)
            {
                f_roll = Input.GetAxis("Roll_manette");
            }

           
            if(Input.GetAxis("YawDroite_manette")!=0)
            {
                f_yaw = Input.GetAxis("YawDroite_manette");
            }
            else if (Input.GetAxis("YawGauche_manette") != 0)
            {

                f_yaw = -Input.GetAxis("YawGauche_manette");
            }
            else
            {
                f_yaw = 0;
            }



            if (throttleUnactive)
            {
                f_stickyThrottle = f_StickyThrottleValor;
            }
            else
            {
                f_throttle = Input.GetAxis("Throttle_manette");
            }

        }
        

        protected void ClampInputs()
        {
            f_pitch = Mathf.Clamp(f_pitch, -1f, 1f);
            f_actualPitch = Mathf.Clamp(f_actualPitch, -1f, 1f);
            f_roll = Mathf.Clamp(f_roll, -1f, 1f);
            f_yaw = Mathf.Clamp(f_yaw, -1f, 1f);
            f_throttle = Mathf.Clamp(f_throttle, -1f, 1f);
            f_stickyThrottle = Mathf.Clamp(f_stickyThrottle, 0f, 1f);
            f_speed = Mathf.Clamp(f_speed, 0f, f_maxSpeed);
        }



        protected void setSpeed()
        {
            f_xSpeed = f_maxSpeed* f_stickyThrottle;

            if (f_speed < f_xSpeed)
            {
                f_speed += (f_stickyThrottle * reactivity) * Time.deltaTime;
            }

            else if (f_speed > f_xSpeed)
            {
                f_speed -= reactivity * Time.deltaTime;
            }
            
        }

        
        protected void setPitch()
        {
            if (f_pitch == 0)
            {
                if(f_actualPitch < 0)
                {
                    f_actualPitch += 1 * Time.deltaTime * f_pitchSpeed;
                }

                else if (f_actualPitch > 0)
                {
                    f_actualPitch -= 1 * Time.deltaTime * f_pitchSpeed;
                }

            }
            else
            {
                f_actualPitch += f_pitch * Time.deltaTime * f_pitchSpeed;
            }
           
            

            transform.Rotate((f_actualPitch * Time.deltaTime)*reactivity, 0, 0, Space.Self);
        }



        protected void setYaw()
        {
            if(f_yaw == 0)
            {   //maxTurn
                canTurn = 0f;
            }

            else if (f_yaw != 0)
            {
                if (canTurn <= maxTurn)
                {

                    //transform.Rotate(0, (f_yaw * Time.deltaTime) * reactivity, 0, Space.Self);

                    pastRotationForTheYaw = transform.eulerAngles;
                    float pastRotationYaw = pastRotationForTheYaw.y + ((f_yaw * Time.deltaTime) * reactivity);
                    transform.rotation = Quaternion.Euler(pastRotationForTheYaw.x, pastRotationYaw, pastRotationForTheYaw.z);

                    canTurn += 1.5f * Time.deltaTime;
                }
            }
        }


        protected void setRoll()
        {
            pastRotationForTheRoll = transform.eulerAngles;
            float pastRotationRoll = pastRotationForTheRoll.z + ((f_roll * Time.deltaTime) * reactivity);
            transform.rotation = Quaternion.Euler(pastRotationForTheRoll.x, pastRotationForTheRoll.y, pastRotationRoll);
        }

       
    }
}
