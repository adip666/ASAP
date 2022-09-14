using UnityEngine;

namespace ASAPInteractions
{
    public class SampleObject : MonoBehaviour, IASAPInteractableObjects
    {
        
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private float startSpeed = 1;
        private float speed;

        public void Initialize()
        {
            speed = startSpeed;
        }

        public void ChangeMovementSpeed(float speed)
        {
            this.speed = speed;
        }

        public void ResetSpeed()
        {
            speed = startSpeed;
        }

        public void FixedTick()
        {
            rigidbody.velocity *= speed;
            rigidbody.angularVelocity *= speed;
        }
        
    }
}