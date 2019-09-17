using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region DEFAULT STATUS
    private Rigidbody2D rb2d;
    private float speed;

    void Start()
    {
        speed = 10;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        rb2d.velocity = Vector2.up * speed;

        if (Player.bullet == true)
        {
            Player.bullet = false;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
        Player.bullet = false;
    }
    #endregion

    #region COLLISIONS
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Target")
        {
            Destroy(gameObject);
            Player.bullet = false;
        }
    }
    #endregion
}