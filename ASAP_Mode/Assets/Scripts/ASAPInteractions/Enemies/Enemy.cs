using System.Collections.Generic;
using ASAP.Settings;
using UnityEngine;
using Zenject.SpaceFighter;

namespace ASAPInteractions
{
    public class Enemy : MonoBehaviour, IASAPInteractableObjects
    {
        private Vector3 currentDirection;
        private float speed;

        [SerializeField] private EnemySettings settings;
      
        public void Initialize()
        {
            speed = settings.NormalSpeed;
            currentDirection = DrawDirection(currentDirection);
        }
        public void FixedTick()
        {
            transform.Translate(currentDirection * speed * Time.fixedDeltaTime );
        }
        
        public void ChangeMovementSpeed(float speed)
        {
           this.speed = speed;
        }

        public void ResetSpeed()
        {
            speed = settings.NormalSpeed;
        }

        private void OnCollisionEnter(Collision other)
        {
             currentDirection = DrawDirection(currentDirection);
        }
        
        private void OnCollisionStay(Collision other)
        {
            currentDirection = DrawDirection(currentDirection);
        }
        
       

        Vector3 DrawDirection(Vector3 currentDirection)
        {
            List<Vector3> directions = new List<Vector3>()
                { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
            directions.Remove(currentDirection);
            int randomIndex = Random.Range(0, directions.Count);

            return directions[randomIndex];
        }

     

     
    }
}