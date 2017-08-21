﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates
{

    public class Troll : Enemy
    {

        public float attackRange = 2f;
        public float meleeSpeed = 20f;
        public float meleeDelay = 0.3f;
        public GameObject attackBox;

        private bool isAttacking = false;

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
            // IF is not attacking and the target is within the attackRange
            if (!isAttacking && IsCloseToTarget(attackRange))
            {
                StartCoroutine(Attack());
            }
        }

        IEnumerator Attack()
        {
            // During attack
            isAttacking = true;
            attackBox.SetActive(true);
            behaviourIndex = Behaviour.IDLE;
            yield return new WaitForSeconds(meleeDelay);
            // After attack
            behaviourIndex = Behaviour.SEEK;
            attackBox.SetActive(false);
            isAttacking = false;
        }

    }
}
