public class GameManager : Singleton<GameManager>
{
    public static bool isRunning = false;

    public static void OnStartGame()
    {
        if (isRunning) return;

        isRunning = true;
    }

    public static void PrizeTaken()
    {
        if (isRunning)
        {
            isRunning = false;
        }
    }

    public static void OnLevelFailed()
    {
        if (isRunning)
        {
            isRunning = false;
            UIManager.I.OnFail();
        }
       
    }

    public static void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}