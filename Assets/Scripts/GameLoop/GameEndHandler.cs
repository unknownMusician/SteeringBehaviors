#nullable enable


using UnityEngine;
using UnityEngine.UI;

namespace SteeringBehaviors.GameLoop
{
    public class GameEndHandler : MonoBehaviour
    {
        [SerializeField] private GameObject gameEndPanel;
        [SerializeField] private Text gameEndText;
        [SerializeField] private Text totalPointsText;
        [SerializeField] private AudioSource winAudio;
        [SerializeField] private AudioSource loseAudio;
        [SerializeField] private GameObject player;
        private bool _isGameEnded = false;
        private int _totalPointsToEndGame;
        private Score _score;
        public void Intialize(Score score)
        {
            _score = score;
            _totalPointsToEndGame = score.DeerToKillAmount + score.RabbitsKilledAmount + score.WolvesToKillAmount;
            score.OnDeerKilled += HandleWin;
            score.OnRabbitsKilled += HandleWin;
            score.OnWolfKilled += HandleWin;

        }

        private void Update()
        {
            if(player == null && !_isGameEnded)
            {
                HandleLose();
            }      
        }

        private void HandleWin()
        {
            if(HasEnoughPoints())
            {
                _isGameEnded = true;
                gameEndText.text = "You win!";
                HandleEnd();
                winAudio.Play();
                Time.timeScale = 0;
            }
        }

        private void HandleLose()
        {
            _isGameEnded = true;
            gameEndText.text = "You lost!";
            HandleEnd();
            loseAudio.Play();
            Time.timeScale = 0;
        }

        private void HandleEnd()
        {
            totalPointsText.text = $"Total points : {GetTotalEarnedPoints()}";
            gameEndPanel.SetActive(true);
            Time.timeScale = 0;
        }

        private bool HasEnoughPoints()
        {
            return (_score.RabbitsKilledAmount >= _score.RabbitsToKillAmount) &&
                (_score.DeerKilledAmount >= _score.DeerToKillAmount) &&
                (_score.WolvesKilledAmount >= _score.WolvesToKillAmount);
        }

        private int GetTotalEarnedPoints()
        {
            return _score.DeerKilledAmount + _score.RabbitsKilledAmount + _score.WolvesKilledAmount;
        }

    }
}
