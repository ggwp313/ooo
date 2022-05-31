using UnityEngine;
using Random = UnityEngine.Random;

public class Collectable : MonoBehaviour
{
    public bool isActive = true;
    
    private AudioSource audioSource;

    private void Awake()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!isActive)
            return;

        audioSource.Play();
        GetComponent<Renderer>().enabled = false;
        isActive = false;
        
        FindObjectOfType<GameManager>().GemsCounter();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(45f, Time.timeSinceLevelLoad * 60f, 45f);
    }
}
