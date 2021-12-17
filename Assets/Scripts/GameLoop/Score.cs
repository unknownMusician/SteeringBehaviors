using UnityEngine;
using Action = System.Action;

namespace SteeringBehaviors.GameLoop
{
    public class Score
    {
        public readonly int WolvesToKillAmount;
        public readonly int DeersToKillAmount;
        public readonly int RabbitsToKillAmount;

        public event Action OnWolfKilled;
        public event Action OnDeersKilled;
        public event Action OnRabbitsKilled;


        public int WolvesKilledAmount { get; private set; }
        public int DeersKilledAmount { get; private set; }
        public int RabbitsKilledAmount { get; private set; }

        public Score(int wolvesToKillAmount, int deersToKillAmount, int rabbitsToKillAmount)
        {
            WolvesToKillAmount = wolvesToKillAmount;
            DeersToKillAmount = deersToKillAmount;
            RabbitsToKillAmount = rabbitsToKillAmount;
        }

        public void HandleWolfKill()
        {
            WolvesKilledAmount++;
            OnWolfKilled?.Invoke();
        }

        public void HandleDeerKill()
        {
            DeersKilledAmount++;
            OnDeersKilled?.Invoke();
        }

        public void HandleRabbitKill()
        {
            RabbitsKilledAmount++;
            OnRabbitsKilled?.Invoke();
        }

        public static Score GetRandom(int wolfPrice,int deerPrice,int rabbitPrice,int neededPrice)
        {
            int wolvesToKill = 0;
            int deersToKill = 0;
            int rabbitsToKill = 0;
            int totalPrice = 0;

            while (totalPrice < neededPrice)
            {
                float randomNumber = Random.Range(0, 2);
                const int wolfIndex = 0;
                const int deerIndex = 1;
                const int rabbitIndex = 2;

                switch (randomNumber)
                {
                    case wolfIndex:
                        totalPrice += wolfPrice;
                        wolvesToKill++;
                        break;
                    case deerIndex:
                        totalPrice += deerPrice;
                        deersToKill++;
                        break;
                    case rabbitIndex:
                        totalPrice += rabbitPrice;
                        rabbitsToKill++;
                        break;
                    default:
                        throw new System.ArgumentOutOfRangeException();
                }
            }

            return new Score(wolvesToKill, deersToKill, rabbitsToKill);
        }

    }
}
