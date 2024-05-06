using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Bause : MonoBehaviour{



[SerializeField] GameObject pauseMenu;
 public void PauseGame ()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
public void ResumeGame ()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Home(){
    Time.timeScale = 1f;
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }}
