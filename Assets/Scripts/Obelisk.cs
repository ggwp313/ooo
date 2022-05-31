using UnityEngine;

public class Obelisk : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.EndGame();
        }
    }
}
