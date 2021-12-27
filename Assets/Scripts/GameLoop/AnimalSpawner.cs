using Generated.SteeringBehaviors.Animals.Deer;
using Generated.SteeringBehaviors.Animals.Rabbit;
using Generated.SteeringBehaviors.Animals.Wolf;
using Generated.SteeringBehaviors.Hunt;
using SteeringBehaviors.Hunt;
using UnityEngine;

namespace SteeringBehaviors.GameLoop
{
    public sealed class AnimalSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _rabbitPrefab;
        [SerializeField] private GameObject _deerPrefab;
        [SerializeField] private GameObject _wolfPrefab;
        [SerializeField] private int _rabbitCount;
        [SerializeField] private int _deerCount;
        [SerializeField] private int _wolfCount;
        [SerializeField] private Bounds _fieldBounds;

        private Score _score;

        public void StartSpawning(Score score)
        {
            _score = score;
            SpawnAnimals(_rabbitCount, _rabbitPrefab);
            SpawnAnimals(_deerCount, _deerPrefab);
            SpawnAnimals(_wolfCount, _wolfPrefab);
        }

        private void SpawnAnimals(int count, GameObject prefab)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject animal = Instantiate(prefab);

                animal.transform.position = new Vector3(
                    Random.Range(_fieldBounds.min.x, _fieldBounds.max.x),
                    0.0f,
                    Random.Range(_fieldBounds.min.z, _fieldBounds.max.z)
                );

                Killable killable = animal.GetComponent<KillableComponent>().HeldType;
                killable.OnKill += killer => HandleKilled(killable, killer);
            }
        }

        private void HandleKilled(Killable killable, GameObject killer)
        {
            if (killer != _player)
            {
                return;
            }
            
            if (killable.ThisObject.GetComponent<RabbitComponent>())
            {
                _score.HandleRabbitKill();
            }
            else if (killable.ThisObject.GetComponent<DeerComponent>())
            {
                _score.HandleDeerKill();
            }
            else if (killable.ThisObject.GetComponent<WolfComponent>())
            {
                _score.HandleWolfKill();
            }
        }
    }
}
