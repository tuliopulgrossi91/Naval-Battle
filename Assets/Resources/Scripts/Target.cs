using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public static int r, random_result;
    public static Vector2[] position = new Vector2[16];
    public static bool check_Target;
    public GameObject result;
    private readonly string[] results = new string[9] { "4", "9", "1", "0", "63", "5", "4", "11", "25" }; 

    void Start()
    {
        r = Random.Range(0, 16);
        random_result = Random.Range(0, 31);

        position[0] = new Vector2(-7, 3);
        position[1] = new Vector2(-5, 3);
        position[2] = new Vector2(-3, 3);
        position[3] = new Vector2(-1, 3);
        position[4] = new Vector2(1, 3);
        position[5] = new Vector2(3, 3);
        position[6] = new Vector2(5, 3);
        position[7] = new Vector2(7, 3);
        position[8] = new Vector2(-5, 0);
        position[9] = new Vector2(-1, 0);
        position[10] = new Vector2(3, 0);
        position[11] = new Vector2(-7, 0);
        position[12] = new Vector2(-3, 0);
        position[13] = new Vector2(1, 0);
        position[14] = new Vector2(5, 0);
        position[15] = new Vector2(7, 0);

        gameObject.GetComponent<Transform>().localPosition = position[r];
        Debug.Log(gameObject.name + " position: " + position[r]);

        if (gameObject.name == "Target(Clone)")
        {
            result.GetComponent<Text>().text = "" + results[TargetManager.q];
        }
        else
        {
            result.GetComponent<Text>().text = "" + random_result;
        }
    }

    #region COLLISIONS
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            check_Target = !check_Target;
        }
    }
    #endregion
}