using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PlayerBehaviorRoad : PlayerBehavior
    {
        float horizontal = 0f;
        float runSpeed = 10f;



        public float Enter()
        {
            //Debug.Log("Enter Road behavior");
            return runSpeed;
        }

        public void Exit()
        {
            //Debug.Log("Exit Road behavior");
        }

        public void Update(PhysicsMovement _movement, Rigidbody rb)
        {
            Debug.Log("Update Road behavior");

            horizontal = 0f;

            if (Input.GetKey("a"))
            {
                horizontal = runSpeed;
            }
            else if (Input.GetKey("d"))
            {
                horizontal = -runSpeed;
            }

           _movement.Move(new Vector3(horizontal, 0, -runSpeed));
        }
    }

