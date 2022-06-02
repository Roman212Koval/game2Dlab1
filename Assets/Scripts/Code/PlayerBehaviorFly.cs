using UnityEngine;


    public class PlayerBehaviorFly : PlayerBehavior
    {
        public float jumpForce = 30f;
        public float runSpeed = 7f;
        public bool jump = true;

    public float Enter()
        {
        //Debug.Log("Enter Fly behavior");


        return runSpeed;
    }

        public void Exit()
        {
            //Debug.Log("Exit Fly behavior");
        }

        public void Update(PhysicsMovement _movement, Rigidbody rb)
        {



            _movement.Move(new Vector3(0, 0, -runSpeed));
            Debug.Log("Update Fly behavior");


    }
    }

