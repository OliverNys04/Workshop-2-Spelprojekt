using UnityEngine;
using UnityEngine.SceneManagement; // For scene reloading

public class PlayerRestart : MonoBehaviour
{
    [Header("Fall Settings")]
    public float fallThreshold = -10f; // Y-coordinate to trigger the restart

    void Update()
    {
        // Check if the player falls below the threshold
        if (transform.position.y < fallThreshold)
        {
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        Debug.Log("Player fell off! Restarting level...");
        SceneManager.LoadScene("LossScene");
    }
}