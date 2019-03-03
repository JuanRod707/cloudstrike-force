using UnityEngine;
using UnityEngine.AI;

namespace Campaign.Movement
{
    public class Navigator : MonoBehaviour
    {
        public NavMeshAgent Agent;
        public ParticleSystem MoveEffect;

        public void GoTo(Vector3 position)
        {
            Agent.SetDestination(position);
            Agent.isStopped = false;
            MoveEffect?.Play();
        } 
    }
}
