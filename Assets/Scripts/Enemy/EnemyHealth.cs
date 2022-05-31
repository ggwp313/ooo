using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
	public class EnemyHealth : MonoBehaviour
	{
		[SerializeField] private float hitPoints = 5f;

		private bool isDead;

		public bool IsDead()
		{
			return isDead;
		}

		public void TakeDamage(float damage)
		{
			BroadcastMessage("OnDamageTaken");
			hitPoints -= damage;
			if (hitPoints <= 0)
			{
				Die();
			}
		}

		private void Die()
		{
			if (isDead) return;
			isDead = true;
			GetComponent<Animator>().SetTrigger("die");
		}
	}
}