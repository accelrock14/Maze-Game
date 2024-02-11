using UnityEngine;

public class Spring : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public Animator animator;

    public float springForce = 20f;

    private void Start()
    {
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Impact");
            playerRb.AddForce(transform.up * springForce, ForceMode2D.Impulse);
        }
    }
}
