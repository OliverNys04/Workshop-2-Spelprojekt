using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinWin : MonoBehaviour
{
    [Header("Win Condition")]
    public int coinsToWin = 5; // Number of coins needed to win
    private int currentCoins = 0; // Tracks collected coins

    void Start()
    {
        Debug.Log("Collect " + coinsToWin + " coins to win!");
    }

    public void AddCoin()
    {
        currentCoins++;
        Debug.Log("Coins Collected: " + currentCoins);

        // Check if the player has won
        if (currentCoins >= coinsToWin)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        Debug.Log("You Win!");
        // Optionally load a new scene or stop the game
        // SceneManager.LoadScene("WinScene"); // Uncomment if you have a Win scene
        Time.timeScale = 0; // Pauses the game
    }
}