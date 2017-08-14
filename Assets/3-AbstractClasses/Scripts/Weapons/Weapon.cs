using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{

    public abstract class Weapon : MonoBehaviour
    {
        public int maxAmmo = 30;
        public float fireInterval = 0.2f;
        public int damage = 10;
        public bool isReady = true;



        [SerializeField]
        protected int ammo = 0;


        public abstract void Fire();
        public virtual void Reload()
        {
            ammo = maxAmmo;
        }


        
    }
}
