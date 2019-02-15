using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScreenController : MonoBehaviour
{
    public Button startGameBtn;

    void Start()
    {
        startGameBtn.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
