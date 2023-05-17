using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPanel : MonoBehaviour
{
    [SerializeField] GameObject panel;
    void Start()
    {
    }
    public void Close()
    {
        panel.SetActive(false);
        SceneManager.LoadScene("MainMenu");

    }
}
