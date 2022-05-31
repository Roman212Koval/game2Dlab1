using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviorOffRoad : PlayerBehavior
{
    float horizontal = 0f;
    float runSpeed = 4f;


    public float Enter()
    {
        //Debug.Log("Enter OffRoad behavior");
        return runSpeed;
    }

    public void Exit()
    {
        //Debug.Log("Exit OffRoad behavior");
    }

    public void Update(PhysicsMovement _movement, Rigidbody rb)
    {
        Debug.Log("Update OffRoad behavior");

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

