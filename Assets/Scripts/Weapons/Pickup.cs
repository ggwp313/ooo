using System;
using UnityEngine;

namespace Weapons
{
    public class Pickup : MonoBehaviour
    {
        [SerializeField] int ammoAmount = 5;
        [SerializeField] AmmoType ammoType;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmount);
                Destroy(gameObject);
            }
        }
    }
}
