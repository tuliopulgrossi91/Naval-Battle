using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    #region DEFAULT STATES
    /// <summary> 
    /// objects0 - level
    /// objects1 - confirm
    /// objects2 - infos
    /// objects3 - settings
    /// objects4 - panel
    /// objects5 - panel text
    /// objects6 - text back
    /// objects7 - text confirm
    /// </summary>

    [Header("Game Object Arrays")] public GameObject[] objects;
    private readonly string[] painel_Title = new string[4] { "Levels", "Settings", "Credits", "Exit" };
    private readonly string[] credits = { "Programmer" + "\n" + "by Tulio Pulgrossi", "SFX by Chiptone", "Assets" + "\n" + "by Kenney", "Music by Eric Matyas" + "\n" + "www.soundimage.org" };
    private bool check;
    #endregion

    #region UI MANAGER
    public void PanelManager(int i) // i is a index panel
    {
        // button back = 0
        #region CLICK MODE
        // check false
        if (check == false) // panel true
        {
            check = true;
            objects[4].SetActive(check);
            CancelInvoke("Credits");
        }
        else // panel false
        {
            check = false;
            objects[4].SetActive(check);
        }
        #endregion

        #region SELECT MODE
        if (i >= 0)
        {
            objects[5].GetComponent<Text>().text = "" + painel_Title[i]; // show title index panel title
            objects[6].GetComponent<Text>().text = "back";
            if (i == 0) // levels
            {
                objects[0].SetActive(check);
                objects[1].SetActive(!check);
                objects[2].SetActive(!check);
                objects[3].SetActive(!check);
            }
            if (i == 1) // settings
            {
                objects[0].SetActive(!check);
                objects[1].SetActive(!check);
                objects[2].SetActive(!check);
                objects[3].SetActive(check);
            }
            if (i == 2) // credits
            {
                objects[0].SetActive(!check);
                objects[1].SetActive(!check);
                objects[2].SetActive(check);
                objects[3].SetActive(!check);
                InvokeRepeating("Credits", 0.5f, 3f); // info credits
            }
            if (i == 3) // exit
            {
                objects[0].SetActive(!check);
                objects[1].SetActive(check);
                objects[2].SetActive(!check);
                objects[3].SetActive(!check);
                objects[6].GetComponent<Text>().text = "no";
                objects[7].GetComponent<Text>().text = "yes";
            }
        }
        #endregion
    }

    public void SelectManager(int j)
    {
        if (j == 0)
        {
            SceneManager.LoadSceneAsync(1); // load scene
        }
        else
        {
            Application.Quit(); // confirm exit
        }
    }

    void Credits()
    {
        objects[2].GetComponent<Text>().text = "" + credits[Random.Range(0, 4)];
    }
    #endregion
}