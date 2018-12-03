using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartQuit : MonoBehaviour {

    public void RestartScene()
    {   
        PlayerController.player.gameObject.transform.position = PlayerController.player.startPos;
        PlayerController.player.gameObject.SetActive(true);
        PlayerController.player.time = PlayerController.player.startTime;
        SceneManager.LoadScene("MainLevel");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
