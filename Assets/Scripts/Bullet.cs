using UnityEngine;

public class Bullet : Obstacle
{

    public float speed = 20f;

    void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out var player))
        {
            player.Destroy();
        }
        Destroy(gameObject);
    }
}
