using SteeringBehaviors.GameLoop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SteeringBehaviors
{
    public class CounterUI : MonoBehaviour
    {

        [SerializeField] private Text _deerToKillText;
        [SerializeField] private Text _rabbitsToKillText;
        [SerializeField] private Text _wolvesToKillText;
        private Score _score;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Intialize(Score score)
        {
            _score = score;
            score.OnDeerKilled += () => HandleKill(Animal.Deer);
            score.OnRabbitsKilled += () => HandleKill(Animal.Rabbit);
            score.OnWolfKilled += () => HandleKill(Animal.Wolf);
        }

        private void HandleKill(Animal animal)
        {
            switch (animal)
            {
                case Animal.Deer:
                    _deerToKillText.text = $"Deers to kill {_score.DeerKilledAmount} / {_score.DeerToKillAmount}";
                    break;
                case Animal.Rabbit:
                    _rabbitsToKillText.text =  $"Rabbits to kill {_score.RabbitsKilledAmount} / {_score.RabbitsToKillAmount}";
                    break;
                case Animal.Wolf:
                    _wolvesToKillText.text = $"Wolves to kill {_score.WolvesKilledAmount} / {_score.WolvesToKillAmount}";
                    break;
            }
        }
    }
}
