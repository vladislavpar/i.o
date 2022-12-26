using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject pause;
    [SerializeField] GameObject start;
    [SerializeField] GameObject ReplayButton;
    [SerializeField] GameObject ExitButton;
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        SceneManager.LoadScene(1);
    }
    public void Pause()
    {
        ReplayButton.SetActive(true);
        ExitButton.SetActive(true);
        start.SetActive(true);
        pause.SetActive(false);
        Time.timeScale = 0;
    }
    public void SetStart()
    {
        ExitButton.SetActive(false);
        ReplayButton.SetActive(false);
        start.SetActive(false);
        pause.SetActive(true);
        Time.timeScale = 1;
    }
}
