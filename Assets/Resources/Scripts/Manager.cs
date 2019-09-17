using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject[] game_UI;
    public static int n;
    public static float t;
    private bool pause;

    void Start()
    {
        Time.timeScale = 1;
        n = 18;
        TargetManager.q = Random.Range(0, 9);
        t = 120f;
        game_UI[3].GetComponent<Text>().text = "" + TargetManager.questions[TargetManager.q];
    }

    void Update()
    {
        t -= Time.deltaTime;
        game_UI[1].GetComponent<Text>().text = "" + Mathf.Round(t);
        game_UI[2].GetComponent<Text>().text = "" + n;

        if (Target.check_Target == true && n > 0)
        {
            TargetManager.q = Random.Range(0, 9);
            game_UI[3].GetComponent<Text>().text = "" + TargetManager.questions[TargetManager.q];
            n--;
        }

        if (n == 0 || t < 0)
        {
            Time.timeScale = 0;
            game_UI[4].SetActive(true);

            if (n == 0)
            {
                game_UI[5].GetComponent<Text>().text = "WINNER!";
            }
            if (t < 0)
            {
                game_UI[5].GetComponent<Text>().text = "GAME OVER!";
            }
        }

        #region CHECK PAUSE GAME
        // pause on
        if (Input.GetKeyDown(KeyCode.Return) && pause == false)
        {
            game_UI[4].SetActive(true);
            Time.timeScale = 0;
            pause = !pause;
        }
        // pause of
        else if (Input.GetKeyDown(KeyCode.Return) && pause == true)
        {
            game_UI[4].SetActive(false);
            Time.timeScale = 1;
            pause = !pause;
        }
        #endregion
    }
}