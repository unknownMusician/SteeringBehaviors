using SteeringBehaviors.Shooting;
using UnityEngine;
using UnityEngine.UI;

namespace SteeringBehaviors
{
    public class AmmoCounter
    {

        [SerializeField] private Text _ammoCounterText;
        private IMagazine _magazine;
        private IShooter _shooter;

        public void Intialize(Magazine magazine,Shooter shooter)
        {
            _magazine = magazine;
            _shooter = shooter;

            

        }

        public void HandleShot()
        {
            
        }

        public void HanldeReload()
        {

        }

    }
}
