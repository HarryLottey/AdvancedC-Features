using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Delegates
{
public abstract class Enemy : MonoBehaviour
{
    public enum Behaviour
        {
            IDLE = 0,
            SEEK = 1
        }


        delegate void BehaviourFunc();

        public Transform target;
        public Behaviour behaviourIndex = Behaviour.SEEK;

        private List<BehaviourFunc> behaviourFuncs = new List<BehaviourFunc>();
        private NavMeshAgent agent;

   public virtual void Awake()
    {
            agent = GetComponent<NavMeshAgent>();
            // Assign delegates to list here
            behaviourFuncs.Add(Idle);
            behaviourFuncs.Add(Seek);
    }

    
        void Idle()
        {
            // Stop the Nav Agent
            agent.Stop();
        }   
        
        void Seek()
        {
            agent.Resume();
            // Check if target is not null
            if(target != null)
            {
                // Move agent to the target
                agent.SetDestination(target.position);
            }
        } 
         
        
        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        public bool IsCloseToTarget(float distance)
        {
            // IF target is not null
            if(target != null)
            {
                float distToTarget = Vector3.Distance(transform.position, target.position);
                // IF distToTarget is less than or equal to distance
                if(distToTarget <= distance)
                {
                    // Return true
                    return true;
                }      
            }
            return false;
        }
           
    protected virtual void Update()
    {
            // Call the correct delegate function
            behaviourFuncs[(int)behaviourIndex]();

    }
}
}
