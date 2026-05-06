using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private string sceneName;

    [SerializeField]
    private bool isGameOver;

    [SerializeField]
    private bool lockCursor;

    private void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void Update()
    {
        if (isGameOver)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void GameIsOver()
    {
        isGameOver = true;
    }

    public void SwitchToScene()
    {
        SwitchToScene(sceneName);
    }
    public void SwitchToScene(string pSceneName)
    {
        SceneManager.LoadScene(pSceneName);
    }




}
