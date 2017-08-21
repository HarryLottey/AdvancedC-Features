using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{


    [RequireComponent(typeof(Rigidbody2D))]
    public class Shooting : MonoBehaviour
    {
        public int weaponIndex = 0;

        private Weapon[] attachedWeapons;
        private Rigidbody2D rigi;

        // Occurs during instantiation aswell
        void Awake()
        {
            rigi = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            // Get all attached weapons in children.
            attachedWeapons = GetComponentsInChildren<Weapon>();
            // Set the first weapon
            SwitchWeapon(weaponIndex);
        }
        void Update()
        {
            CheckFire();
            WeaponSwitching();
        }
        // Checks if the user pressed a button to fire the current weapon
        void CheckFire()
        {
            // Set currentWeapon to attatchedWeapons[weaponIndex]
            Weapon currentWeapon = attachedWeapons[weaponIndex];
            // IF user pressed down space
            if (Input.GetButtonDown("Fire1"))
            {
                // Fire currentWeapon
                currentWeapon.Fire();
                // add recoil to player from weapon's recoil
                Vector3 force = -transform.right * currentWeapon.recoil;
                rigi.AddForce(force, ForceMode2D.Impulse);
            }



        }
        // Handles weapon switching
        void WeaponSwitching()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CycleWeapon(-1);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                CycleWeapon(1);
            }
        }
        // Cycles throuhg weapons using amount as an index for selected weapon.
        void CycleWeapon(int amount)
        {
            // SET desired index to weaponIndex + amount
            int desiredIndex = weaponIndex + amount;
            // IF desiredIndex >= length of weapons
            if (desiredIndex >= attachedWeapons.Length)
            {
                // SET desired index to zero
                desiredIndex = 0;
            }
            // ELSE IF desiredIndex < zero
            else if (desiredIndex < 0)
            {
                // SET desiredIndex to length of weapons - 1
                desiredIndex = attachedWeapons.Length - 1;
            }
            // SET weaponIndex to desiredIndex
            weaponIndex = desiredIndex;
            // SwitchWeapon() to weaponIndex
            SwitchWeapon(weaponIndex);
        }

        // Disables all other weapons in the list, and returns the selected one.
        Weapon SwitchWeapon(int weaponIndex)
        {
            // Check if index is outside of bounds.
            if (weaponIndex < 0 || weaponIndex > attachedWeapons.Length)
            {
                return null;
            }
            // Looping through all the weapons
            for (int i = 0; i < attachedWeapons.Length; i++)
            {
                // Get the weapon at index
                Weapon w = attachedWeapons[i];
                // IF index == weapon idex
                if (i == weaponIndex)
                {
                    // Activate the weapon
                    w.gameObject.SetActive(true);
                }
                // Else
                else
                {
                    // Deactivate the weapon
                    w.gameObject.SetActive(false);
                }
            }
            // Return selected weapon
            return attachedWeapons[weaponIndex];
        }

    }
}
