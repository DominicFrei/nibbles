using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text gameWonText = default;
    [SerializeField] Text gameOverText = default;

    GameManager gameManager = default;

    bool gameFinished = default;

    void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        if (!gameManager)
        {
            Debug.Log("gameManager must not be null.");
        }
    }

    void Update()
    {
        if (gameFinished && Input.GetKeyDown(KeyCode.R))
        {
            gameManager.PlayerClickedRestart();
        }

        if (gameFinished && Input.GetKeyDown(KeyCode.Q))
        {
            gameManager.PlayerClickedQuit();
        }
    }

    public void showGameWonText()
    {
        gameFinished = true;
        gameWonText.gameObject.SetActive(true);
    }

    public void showGameOverText()
    {
        gameFinished = true;
        gameOverText.gameObject.SetActive(true);
    }

}
