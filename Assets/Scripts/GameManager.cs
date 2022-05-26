using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player movement;
    public float levelRestartDelay = 3f;
    public float level;

    public void EndGame()
    {
        movement.enabled = false;

        Invoke("RestartLevel", levelRestartDelay);
    }

    void RestartLevel()
    {
        switch (level)
        {
            case 1:
                SceneManager.LoadScene("SampleScene");
                break;

            case 2:
                SceneManager.LoadScene("SampleScene2");
                break;

            case 3:
                SceneManager.LoadScene("SampleScene3");
                break;
        }
    }
}
