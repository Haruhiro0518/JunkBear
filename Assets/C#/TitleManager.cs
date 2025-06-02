using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField, Header("開始")]
    private GameObject start;

    public void OnStart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
