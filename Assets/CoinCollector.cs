using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Find the CoinWin script on the player and add coin
            CoinWin coinWin = other.GetComponent<CoinWin>();
            if (coinWin != null)
            {
                coinWin.AddCoin();
            }

            // Destroy the coin
            Destroy(gameObject);
        }
    }
}