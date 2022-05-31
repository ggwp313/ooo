using System;
using System.Collections;
using Enemy;
using TMPro;
using UnityEngine;

namespace Weapons
{
    public class Weapon : MonoBehaviour
    {
        [Header("Object references")]
        [SerializeField] private Camera fpCamera;
        [SerializeField] private ParticleSystem muzzleFlashVFX;
        //[SerializeField] private GameObject hitImpactVFX;
        [SerializeField] private Ammo ammoSlot;
        [SerializeField] private AmmoType ammoType;
        [Header("Weapon's properties")]
        [SerializeField] private float shootRange = 100f;
        [SerializeField] private float damage = 25f;
        [SerializeField] private float timeBetweenShoots = 2f;
        [SerializeField] private TextMeshProUGUI ammoText;

        private bool canShoot = true;

        private void OnEnable()
        {
            canShoot = true;
        }

        private void Update()
        {
            DisplayAmmo();
            if (Input.GetMouseButton(0) && canShoot)
            {
                StartCoroutine(Shoot());
            }
        }

        private IEnumerator Shoot()
        {
            canShoot = false;
            if (ammoSlot.GetCurrentAmmo(ammoType) <= 0) yield break;
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
            yield return new WaitForSeconds(timeBetweenShoots);
            canShoot = true;
        }
        
        private void DisplayAmmo()
        {
            int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
            ammoText.text = currentAmmo.ToString();
        }

        private void PlayMuzzleFlash()
        {
            muzzleFlashVFX.Play();
        }

        private void ProcessRaycast()
        {
            if (!Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out var hit, shootRange)) return;
            //CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }

        /*private void CreateHitImpact(RaycastHit hitInfo)
        {
            GameObject impact = Instantiate(hitImpactVFX, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(impact, 1f);
        }*/
    }
}
