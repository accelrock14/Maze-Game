using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;

    private int coinsCollected = 0;

    public void Destroy()
    {
        gameManager.GameOver();
        Destroy(gameObject);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            gameManager.Victory(coinsCollected);
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinsCollected++;
            Destroy(collision.gameObject);
        }
    }
}
