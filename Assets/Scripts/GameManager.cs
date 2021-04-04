using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Pano1 p1;
    Pano2 p2;
    TextScript ts;
    ButtonScript bs;
    CoinMove cm;

    [SerializeField] GameObject PopUpMenu;
    [SerializeField] Text totalScoreText;
    [SerializeField] GameObject RedCircles, GreenCircles;
    [SerializeField] Text scoreText;
    private int score = 0;

    private int questionCount = 0;

    private void Start()
    {
        p1 = Object.FindObjectOfType<Pano1>();
        p2 = Object.FindObjectOfType<Pano2>();
        ts = Object.FindObjectOfType<TextScript>();
        bs = Object.FindObjectOfType<ButtonScript>();
        cm = Object.FindObjectOfType<CoinMove>();


    }

    public void PlayButton()
    {
        p1.MixImages();
        p2.MixImages();
        Animations(); 
    }

    public void CheckButton()
    {
        if (p1.random1 == p1.choosenNum1)
        {
            p1.WinAnim();
        }
        else
        {
            p1.LostAnim();
        }

        if (p2.random2 == p2.choosenNum2)
        {
            p2.WinAnim();
        }
        else
        {
            p2.LostAnim();
        }

        if(p1.random1 == p1.choosenNum1 && p2.random2 == p2.choosenNum2)
        {
            GreenCircles.transform.GetChild(questionCount).gameObject.SetActive(true);
            score = score + 15;
            scoreText.text = score.ToString();
            cm.CoinWinEffect();

            SoundManager.instance.CorrectSound();
        }
        else
        {
            RedCircles.transform.GetChild(questionCount).gameObject.SetActive(true);

            SoundManager.instance.WrongSound();
        }


        StartCoroutine(PlayAgain());

    }

 

    private void Animations()
    {
        ts.AnimationState();
        p1.AnimationState();
        p2.AnimationState();
        bs.AnimationState();
        
    }

    IEnumerator PlayAgain()
    {
        yield return new WaitForSeconds(1f);

        p1.PlayAgain();
        p2.PlayAgain();
        bs.PlayAgain();

        questionCount++;

        if (questionCount > 5)
        {
            PopUpMenu.gameObject.SetActive(true);
            PopUpMenu.GetComponent<CanvasGroup>().DOFade(1, 0.5f);

            totalScoreText.text = "TOPLAM PUAN : " + score;
        }
            
    }

    // OnClick
    public void PlayAgainButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // OnCkick
    public void QuitButton()
    {
        Application.Quit();
    }

} // Class
