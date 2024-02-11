using UnityEngine;

public class AntiGravity : MonoBehaviour
{
    public float upwardForce = 10f;

    private bool isColliding = false;

    private Rigidbody2D playerRb;

    private void Start()
    {
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColliding = false;
        }
    }

    private void FixedUpdate()
    {
        if (isColliding)
        {
            playerRb.AddForce(transform.up * upwardForce, ForceMode2D.Force);
        }
    }
}
