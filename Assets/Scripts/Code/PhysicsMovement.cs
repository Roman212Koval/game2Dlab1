using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PhysicsMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private SurfaceSlider _surfaceSlider;
        [SerializeField] private Player pl;

        public void Move(Vector3 direction)
        {
            Vector3 directionAlongSurfase = _surfaceSlider.Project(direction.normalized);
            Vector3 offset = directionAlongSurfase * (pl.Speed * Time.deltaTime);

            _rigidbody.MovePosition(_rigidbody.position + offset);
        }
    }
