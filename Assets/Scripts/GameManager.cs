using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player movement;
    public float levelRestartDelay = 3f;

    public void EndGame()
    {
        movement.enabled = false;

        Invoke("RestartLevel", levelRestartDelay);
    }

    void RestartLevel()
    {
        //SceneManager.LoadScene(SceneManeger.GetActiveScene().buildIndex);
        SceneManager.LoadScene("SampleScene");
    }
}
