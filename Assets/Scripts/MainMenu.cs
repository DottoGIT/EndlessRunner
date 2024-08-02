using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highscore;

    void Start()
    {
        Time.timeScale = 1f;
        highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
