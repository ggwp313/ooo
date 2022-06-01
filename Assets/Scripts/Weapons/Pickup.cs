using System;
using UnityEngine;

namespace Weapons
{
    public class Pickup : MonoBehaviour
    {
        [SerializeField] int ammoAmount = 5;
        [SerializeField] AmmoType ammoType;
        [SerializeField] private AudioSource audioSource;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                audioSource.Play();
                FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmount);
                Destroy(gameObject);
            }
        }
    }
}
