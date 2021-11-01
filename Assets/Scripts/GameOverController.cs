using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button buttonLobby;
    private void Awake()
    {
    buttonRestart.onClick.AddListener(ReloadLevel); 
    buttonLobby.onClick.AddListener(LobbyScreen);   
    }
    public void PlayerDied()
    {
    gameObject.SetActive(true);
    }
     public void ReloadLevel()
    {
      Debug.Log("Reloading scene...");
      Scene scene = SceneManager.GetActiveScene();
      SceneManager.LoadScene(scene.buildIndex);

      //SceneManager.LoadScene(1);
    }
    public void LobbyScreen()
    {
      SceneManager.LoadScene(0);
    }

}