using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class FollowCamera : MonoBehaviour
    {
        public Transform player;
        public Vector3 offset;

        // Update is called once per frame
        void Update()
        {
            transform.position = player.position + offset;
        }
    }
}
