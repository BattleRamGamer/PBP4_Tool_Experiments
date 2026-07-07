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
            SetCursorLock(true);
            //Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void Update()
    {
        if (isGameOver)
        {
            SetCursorLock(false);
            //Cursor.lockState = CursorLockMode.None;
        }
    }

    public void GameIsOver()
    {
        isGameOver = true;
    }

    public void SetCursorLock(bool pLockCursor)
    {
        if (pLockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
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
