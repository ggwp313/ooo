using UnityEngine;

namespace Enemy
{
	public class EnemyAttack : MonoBehaviour
	{
		private PlayerHealth target;
		[SerializeField] private float damage = 1f;

		void Start()
		{
			target = FindObjectOfType<PlayerHealth>();
		}

		public void AttackHitEvent()
		{
			if (target == null) return;
			target.TakeDamage(damage);
			target.GetComponent<DisplayDamage>().ShowDamageImpact();
		}
	}
}