using TMPro;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private TextMeshProUGUI countObjects;
    [SerializeField] private GameObject endGameView;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        GemsCounter();
    }

    /// <summary>
    /// Counts all active and inactive gems on the map and write them in HUD
    /// </summary>
    public void GemsCounter()
    {
        Collectable[] gems = FindObjectsOfType<Collectable>();

        int gemsCount = gems.Length;
        int gemsInactive = gems.Count(gem => !gem.isActive);

        string text = $"Gems: {gemsInactive} / {gemsCount}";

        countObjects.text = text;
    }

    /// <summary>
    /// Return to main menu if there are no more gems on the map
    /// </summary>
    public void EndGame()
    {
        bool endOfGame = FindObjectsOfType<Collectable>().All(gem => !gem.isActive);

        if (endOfGame)
        {
            endGameView.SetActive(true);
            Cursor.visible = true;
        }
    }
}
