using ASAP.Settings;
using UnityEngine;

namespace ASAPInteractions
{
    public class SampleObject : MonoBehaviour, IASAPInteractableObjects
    {
        
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] InteractableObjectSettings settings;
        private float speed;

        public void Initialize()
        {
            speed = settings.NormalSpeed;
        }

        public void ChangeMovementSpeed(float speed)
        {
            this.speed = speed;
        }

        public void ResetSpeed()
        {
            speed = settings.NormalSpeed;;
        }

        public void FixedTick()
        {
            rigidbody.velocity *= speed;
            rigidbody.angularVelocity *= speed;
        }
        
    }
}