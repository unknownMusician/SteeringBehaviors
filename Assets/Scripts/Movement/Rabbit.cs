using System.Threading.Tasks;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;

namespace SteeringBehaviors.Movement
{
    namespace Rabbit
    {
        public class Rabbit
        {
            private readonly IState _walkingState;
            private readonly IState _runningState;

            private readonly Info _info;
            private IState _state;

            private bool _isAlive = true;
            private IState _lastState;

            public Rabbit([FromThisObject] IMover mover, [FromThisObject] Transform transform)
            {
                _info = new Info() { Mover = mover, Transform = transform };

                _walkingState = new WalkingState(_info);
                _runningState = new RunningState(_info);

                _state = new WalkingState(_info);
                _lastState = new WalkingState(_info);

                SeekForEnemiesAsync();
            }

            public bool TryFindEnemy(out Transform transform)
            {
                transform = default;

                return false;
            }

            private async Task MoveAsync()
            {
                while (_isAlive)
                {
                    _state.Move();

                    await Task.Yield();
                }
            }

            private async Task SeekForEnemiesAsync()
            {
                while (_isAlive)
                {
                    if (_state == _lastState)
                    {
                        continue;
                    }

                    _lastState = _state;

                    _state = TryFindEnemy(out _info.EnemyTransform) ? _runningState : _walkingState;

                    await Task.Yield();
                }
            }
        }

        public class Info
        {
            public Transform Transform;
            public Transform EnemyTransform;
            public IMover Mover;
        }

        public interface IState
        {
            void Move();
        }

        public readonly struct WalkingState : IState
        {
            private readonly Info _info;

            public WalkingState(Info info)
            {
                _info = info;
            }

            public void Move()
            {
                Vector2 directionXZ = Random.insideUnitCircle;

                Vector3 direction = new Vector3(directionXZ.x, 0.0f, directionXZ.y);

                _info.Mover.StartMoving(direction);
            }
        }

        public readonly struct RunningState : IState
        {
            private readonly Info _info;

            public RunningState(Info info)
            {
                _info = info;
            }

            public void Move()
            {
                const float safeDistance = 10;
                _info.Mover.StartEscapingFrom(_info.EnemyTransform, safeDistance);
            }
        }
    }
}
