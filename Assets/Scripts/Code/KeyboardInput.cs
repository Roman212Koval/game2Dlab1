using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class KeyboardInput : MonoBehaviour
    {
        [SerializeField] private PhysicsMovement _movement;

        private void Update()
        {
            float horizontal = -1f * Input.GetAxis("Mouse Y");
            float vertical = 1f * Input.GetAxis("Mouse X");

            _movement.Move(new Vector3(-vertical, 0, horizontal));
        }
    }
}
