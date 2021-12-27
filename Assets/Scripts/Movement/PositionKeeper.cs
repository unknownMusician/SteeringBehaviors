using UnityEngine;

namespace SteeringBehaviors.Movement
{
    public sealed class PositionKeeper : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private Vector3 _localPosition;

        private void Awake()
        {
            _localPosition = transform.position - _target.position;
        }

        private void LateUpdate()
        {
            if (_target != null)
            {
                transform.position = _target.position + _localPosition;
            }
        }
    }
}
