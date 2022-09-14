using Zenject;

namespace ASAPInteractions
{
    public interface IASAPInteractableObjects : IFixedTickable
    {
        void ChangeMovementSpeed(float speed);
    }
}