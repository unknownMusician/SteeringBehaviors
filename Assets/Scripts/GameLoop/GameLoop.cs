using System;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SteeringBehaviors.GameLoop
{
    public sealed class GameLoop : MonoBehaviour
    {
        [SerializeField] private int _rabbitPrice;
        [SerializeField] private int _deerPrice;
        [SerializeField] private int _wolfPrice;
        [SerializeField] private int _scorePrice;
        [SerializeField] private KillsCounterUI _scoreUI;
        [SerializeField] private AnimalSpawner _spawner;
        [SerializeField] private GameEndHandler _gameEndHandler;
        private Score _score;

        private void Awake()
        {
            _score = Score.GetRandom(_wolfPrice, _deerPrice, _rabbitPrice, _scorePrice);
            _scoreUI.Initialize(_score);
            _spawner.StartSpawning(_score);
            _gameEndHandler.Initialize(_score);
        }

        public void Restart() => SceneManager.LoadScene(0);
        public void Exit() => Application.Quit();
    }
}
