using System.Threading.Tasks;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;

namespace SteeringBehaviors.Movement
{
    [GenerateMonoBehaviour]
    public class Test
    {
        private readonly Rigidbody _rigidbody;
            
        private bool _isWalking = false;
        
        public Test(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
            
            Walking();
        }

        private async Task Walking()
        {
            _isWalking = true;

            while (_isWalking)
            {
                // do smth...
                
                await Task.Yield();
            }
        }
    }
}
