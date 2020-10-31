using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public void StartGameButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }
}
