// Copyright takiido. All Rights Reserved

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance { get; private set; }
    
    // ToDo: add ui and audio managers

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    #endregion
    
    private void Start()
    {
        if (FirstStart())
        {
            // ToDo: run first start menu via ui manager
        }
    }
    
    private bool FirstStart()
    {
        return true;
    }

    private void StartArena()
    {
        SceneManager.LoadScene("Arena");
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
