using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public Transform[] target_Prefabs;
    public static int q;
    public static string[] questions = new string[9] { "2 + 2", "3 x 3", "4 / 4", "5 - 5", "7 x 9", "8 - 3", "16 / 4", "7 + 4", "5 x 5" };

    void Start()
    {
        for (int i = 0; i < target_Prefabs.Length; i++)
        {
            Instantiate(target_Prefabs[i], Target.position[Target.r], Quaternion.identity);
        }
    }

    void Update()
    {
        if (Target.check_Target == true && Manager.n > 0)
        {
            Target.check_Target = false;

            for (int i = 0; i < target_Prefabs.Length; i++)
            {
                DestroyImmediate(GameObject.FindGameObjectWithTag("Target"));
                Instantiate(target_Prefabs[i], Target.position[Target.r], Quaternion.identity);
            }
        }
    }
}