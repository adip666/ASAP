using UnityEngine;

namespace ASAP.Settings
{
    [CreateAssetMenu(menuName = "Settings/New Game Settings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private float asapModeSpeed = .8f;

        public float AsapModeSpeed => asapModeSpeed;

        [SerializeField] private int asapModeMaxTime = 5;

        public float AsapModeMaxTime => asapModeMaxTime;
    }
}