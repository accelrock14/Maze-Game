using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;

    public void Destroy()
    {
        gameManager.GameOver();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            gameManager.Victory();
        }
    }
}
