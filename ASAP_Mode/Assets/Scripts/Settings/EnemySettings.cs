using UnityEngine;

namespace ASAP.Settings
{
    [CreateAssetMenu(menuName = "Settings/New enemy settings")]
    public class EnemySettings :  ScriptableObject
    {
        [SerializeField] private float normalSpeed = 1f;

        public float NormalSpeed => normalSpeed;
    }
}