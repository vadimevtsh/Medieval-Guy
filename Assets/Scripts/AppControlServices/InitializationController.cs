using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializationController : MonoBehaviour
{
    private const string GameSceneName = "MainScene";

    public static bool IsGameStarted { get; private set; }
    
    private static bool _isInitialized;
    
    private void Awake()
    {
        if (_isInitialized) {
            Destroy(this);
            return;
        }

        _isInitialized = true;
        DontDestroyOnLoad(this);

        StartGameSession();
    }
    
    private static void StartGameSession(string stateName = null, bool needToReloadScene = false) 
    {
        IsGameStarted = true;

        // Reset scene
        if (needToReloadScene) 
        {
            SceneManager.sceneLoaded += OnGameSceneLoaded;
            SceneManager.LoadSceneAsync(GameSceneName);
        } 
        else 
        {
            OnGameSceneLoaded(default, LoadSceneMode.Single);
        }
    }
    
    private static void OnGameSceneLoaded(Scene _, LoadSceneMode __) 
    {
        var appController = FindObjectOfType<AppController>();
        appController.InitializeGameState();

        SceneManager.sceneLoaded -= OnGameSceneLoaded;
    }
}
