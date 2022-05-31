using UnityEngine;

public interface PlayerBehavior
    {
        float Enter();
        void Exit();
        void Update(PhysicsMovement _movement, Rigidbody rb);
    }
