using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        SceneManager.LoadScene(1);
    }
}
