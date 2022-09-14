using UnityEngine;

namespace ASAP.Settings
{
    [CreateAssetMenu(menuName = "Settings/New interactable Object settings")]
    public class InteractableObjectSettings : ScriptableObject
    {
        [SerializeField] private float normalSpeed = 1f;
        public float NormalSpeed => normalSpeed;
    }
}