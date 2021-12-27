using Generated.SteeringBehaviors.Hunt;
using UnityEngine;

namespace SteeringBehaviors.GameLoop
{
    public class FieldBoundsKiller : MonoBehaviour
    {
        [SerializeField] private AnimalMoverSettings _settings;
        [SerializeField] private KillableComponent _killable;

        private bool _isAlive = true;
        private void Update()
        {
            if (_isAlive && !_settings.Bounds.Contains(transform.position))
            {
                _killable.HeldType.KillMe(gameObject);
                _isAlive = false;
            }
        }
    }
}
