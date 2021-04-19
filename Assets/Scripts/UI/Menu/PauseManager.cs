using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        UnPauseGame();
    }
    public void PauseGame()
    {
        var pauseables = FindObjectsOfType<MonoBehaviour>().OfType<IPauseable>();

        foreach (IPauseable pauseable in pauseables)
        {
            pauseable.PauseMenu();
        }
        Time.timeScale = 0;
        AppEvents.Invoke_OnMouseCursorEnable(true);
    }

    public void UnPauseGame()
    {
        var pauseables = FindObjectsOfType<MonoBehaviour>().OfType<IPauseable>();

        foreach (IPauseable pauseable in pauseables)
        {
            pauseable.UnPauseMenu();
        }
        Time.timeScale = 1;
        AppEvents.Invoke_OnMouseCursorEnable(false);
    }

    private void OnDestroy()
    {
        UnPauseGame();
    }
}

interface IPauseable
{
    void PauseMenu();
    void UnPauseMenu();
}
