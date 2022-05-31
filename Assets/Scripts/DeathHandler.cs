using UnityEngine;
using StarterAssets;
using Weapons;

public class DeathHandler : MonoBehaviour
{
	[SerializeField] private Canvas gameOverCanvas;

	private void Start()
	{
		gameOverCanvas.enabled = false;
	}

	public void HandleDeath()
	{
		gameOverCanvas.enabled = true;
		Time.timeScale = 0;
		FindObjectOfType<WeaponSwitcher>().enabled = false;
		GetComponent<FirstPersonController>().enabled = false;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
}