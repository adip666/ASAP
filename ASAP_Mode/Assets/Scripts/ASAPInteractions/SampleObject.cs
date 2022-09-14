using UnityEngine;

namespace ASAPInteractions
{
    public class SampleObject : MonoBehaviour, IASAPInteractableObjects
    {
        private float speed = 1;
        [SerializeField] private Rigidbody rigidbody;

        public void ChangeMovementSpeed(float speed)
        {
            this.speed = speed;
        }

        public void FixedTick()
        {
            rigidbody.velocity *= speed;
            rigidbody.angularVelocity *= speed;
        }

        [ContextMenu("ResetSpeed")]
        void ResetSpeed()
        {
            speed = 1;
        }
    }
}