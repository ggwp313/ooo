using System;
using UnityEngine;

namespace Weapons
{
    public class WeaponSwitcher : MonoBehaviour
    {
        [SerializeField] private int currentWeapon;
        private void Start()
        {
            SetWeaponActive();
        }

        private void Update()
        {
            int previousWeapon = currentWeapon;
            
            ProcessInputKey();
            ProcessMouseWheel();

            if (previousWeapon != currentWeapon)
            {
                SetWeaponActive();
            }
        }

        private void ProcessInputKey()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentWeapon = 0;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentWeapon = 1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                currentWeapon = 2;
            }
        }

        private void ProcessMouseWheel()
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (currentWeapon >= transform.childCount - 1)
                {
                    currentWeapon = 0;
                }
                else
                {
                    currentWeapon++;
                }
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (currentWeapon <= 0)
                {
                    currentWeapon = transform.childCount - 1;
                }
                else
                {
                    currentWeapon--;
                }
            }
            
        }

        private void SetWeaponActive()
        {
            int weaponIndex = 0;

            foreach (Transform weapon in transform)
            {
                weapon.gameObject.SetActive(weaponIndex == currentWeapon);

                weaponIndex++;
            }
        }
    }
}
