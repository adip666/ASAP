using Zenject;

namespace ASAPInteractions
{
    public interface IASAPInteractableObjects : IFixedTickable
    {
        void Initialize();
        void ChangeMovementSpeed(float speed);
        void ResetSpeed();
    }
}