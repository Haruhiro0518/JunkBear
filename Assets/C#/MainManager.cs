using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [SerializeField, Header("メニューボタン")]
    private GameObject menuButton;
    
    [SerializeField, Header("メニューUI")]
    private GameObject menuUI;

    [SerializeField, Header("ゲームコンプUI")]
    private GameObject gamecompleteUI;
    
    [SerializeField, Header("ゲームクリアUI")]
    private GameObject gameclearUI;
    
    [SerializeField, Header("ゲームオーバーUI")]
    private GameObject gameoverUI;

    [Header("終了判定")]
    public Player player;

    private ItemCounter counter;

    private AudioSource bgm;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        menuButton.SetActive(true);
        menuUI.SetActive(false);
        gamecompleteUI.SetActive(false);
        gameclearUI.SetActive(false);
        gameoverUI.SetActive(false);

        counter = FindObjectOfType<ItemCounter>();

        bgm = GetComponent<AudioSource>();
        bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(bgm.time > 86.3f)
        {
            bgm.Stop();
            bgm.time = 0.7f;
            bgm.Play();
        }

        ShowGameClear();
        ShowGameOver();
    }

    public void OnMenu()
    {
        Time.timeScale = 0;

        menuButton.SetActive(false);
        menuUI.SetActive(true);
    }

    public void OnResume()
    {
        Time.timeScale = 1;

        menuButton.SetActive(true);
        menuUI.SetActive(false);
    }

    public void OnRetry()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    private void ShowGameClear() 
    {
        if(player.bclear)
        {
            Time.timeScale = 0;

            menuButton.SetActive(false);
            if(counter.score == counter.sum)
            {
                gamecompleteUI.SetActive(true);
            }
            else
            {
                gameclearUI.SetActive(true);
            }

            bgm.Stop();
        }
    }

    private void ShowGameOver() 
    {
        if(player.bdead)
        {
            Time.timeScale = 0;
            menuButton.SetActive(false);
            gameoverUI.SetActive(true);

            bgm.Stop();
        }
    }
}
