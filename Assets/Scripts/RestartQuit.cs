using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartQuit : MonoBehaviour {
    AudioSource src;
    public AudioClip button;

    private void Awake()
    {
        src = GetComponent<AudioSource>();
    }

    public void RestartScene()
    {
        src.PlayOneShot(button);
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
