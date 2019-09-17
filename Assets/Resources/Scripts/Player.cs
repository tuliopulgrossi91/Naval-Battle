using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float speed;
    public static bool bullet;
    public GameObject bullet_Prefab;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        speed = 5;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bullet == false)
            {
                bullet = true;
                Instantiate(bullet_Prefab, transform.position, Quaternion.identity);
            }
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb2d.velocity = Vector2.left * speed;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb2d.velocity = Vector2.right * speed;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            rb2d.velocity = Vector2.zero * 0;
        }
    }

    //public void MovePlayer(int i)
    //{
    //    if (i == 0)
    //    {
    //        rb2d.velocity = Vector2.left * speed; // pointer enter
    //    }
    //    if (i == 1)
    //    {
    //        rb2d.velocity = Vector2.right * speed; // pointer enter
    //    }
    //    if (i == 2)
    //    {
    //        rb2d.velocity = Vector2.zero * 0; // pointer up
    //    }
    //}
}