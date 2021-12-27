#nullable enable

using UnityEngine;
using Action = System.Action;

namespace SteeringBehaviors.GameLoop
{
    public class Score
    {
        public readonly int WolvesToKillAmount;
        public readonly int DeerToKillAmount;
        public readonly int RabbitsToKillAmount;

        public event Action? OnWolfKilled;
        public event Action? OnDeerKilled;
        public event Action? OnRabbitsKilled;
        
        public int WolvesKilledAmount { get; private set; }
        public int DeerKilledAmount { get; private set; }
        public int RabbitsKilledAmount { get; private set; }

        public Score(int wolvesToKillAmount, int deerToKillAmount, int rabbitsToKillAmount)
        {
            WolvesToKillAmount = wolvesToKillAmount;
            DeerToKillAmount = deerToKillAmount;
            RabbitsToKillAmount = rabbitsToKillAmount;
        }

        public void HandleWolfKill()
        {
            WolvesKilledAmount++;
            OnWolfKilled?.Invoke();
        }

        public void HandleDeerKill()
        {
            DeerKilledAmount++;
            OnDeerKilled?.Invoke();
        }

        public void HandleRabbitKill()
        {
            RabbitsKilledAmount++;
            OnRabbitsKilled?.Invoke();
        }

        public static Score GetRandom(int wolfPrice, int deerPrice, int rabbitPrice, int neededPrice)
        {
            int wolvesToKill = 0;
            int deerToKill = 0;
            int rabbitsToKill = 0;
            
            int totalPrice = 0;

            while (totalPrice < neededPrice)
            {
                int randomNumber = Random.Range(0, 3);
                
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
                        deerToKill++;
                        break;
                    case rabbitIndex:
                        totalPrice += rabbitPrice;
                        rabbitsToKill++;
                        break;
                    default:
                        throw new System.ArgumentOutOfRangeException();
                }
            }

            return new Score(wolvesToKill, deerToKill, rabbitsToKill);
        }
    }
}
