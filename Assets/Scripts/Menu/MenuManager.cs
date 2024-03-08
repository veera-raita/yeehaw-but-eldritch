using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button StartButton;
    [SerializeField] private Button SettingsButton;
    [SerializeField] private Button CloseSettingsButton;
    [SerializeField] private Button QuitButton;

    //[SerializeField] private AudioClip MenuClick;
    //[SerializeField] private AudioClip MenuHover;
    //[SerializeField] private AudioSource MenuPlayer;

    [SerializeField] private GameObject SettingsScreen;

    // Start is called before the first frame update
    private void Start()
    {
        StartButton.onClick.AddListener(() => ClickSound());
        StartButton.onClick.AddListener(() => StartGame ());
        SettingsButton.onClick.AddListener(() => ClickSound());
        SettingsButton.onClick.AddListener(() => OpenSettings());
        CloseSettingsButton.onClick.AddListener(() => ClickSound());
        CloseSettingsButton.onClick.AddListener(() => CloseSettings());
        QuitButton.onClick.AddListener(() => ClickSound());
        QuitButton.onClick.AddListener(() => Die());
    }

    private void ClickSound()
    {
        //MenuPlayer.PlayOneShot(MenuClick, 1.0f);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void OpenSettings()
    {
        SettingsScreen.SetActive(true);
    }

    private void CloseSettings()
    {
        SettingsScreen.SetActive(false);
    }

    private void Die()
    {
        Application.Quit();   
    }
}
