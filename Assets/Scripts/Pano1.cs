using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Pano1 : MonoBehaviour
{
    [SerializeField] private Image[] Gezegenler1 = new Image[15];
    private bool isButtonActive = true;

    public int random1;
    public int choosenNum1;

    [SerializeField] public GameObject thick, cross;
    [SerializeField] private GameObject rightButton,leftButton;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Start1());
    }

    // Right Arrow - OnClick
    public void RightButton1()
    {
        if (isButtonActive && choosenNum1<14)
        {
            SoundManager.instance.ButtonSound();
            isButtonActive = false;
            choosenNum1++;
            Debug.Log(choosenNum1);

            for (int i = 0; i < 15; i++)
            {
                float targetPos = Gezegenler1[i].GetComponent<RectTransform>().anchoredPosition.x - 300f;
                Gezegenler1[i].GetComponent<RectTransform>().DOAnchorPos(new Vector2(targetPos, 0), 0.3f).OnComplete(() => isButtonActive = true);
            }
        }

        if(choosenNum1 == 14)
        {
            rightButton.SetActive(false);
            leftButton.SetActive(true);
        }
        else
        {
            leftButton.SetActive(true);
            rightButton.SetActive(true);
        }
        
    }

    // Left Arrow - OnClick
    public void LeftButton1()
    {
        if (isButtonActive && choosenNum1 > 0 )
        {
            SoundManager.instance.ButtonSound();
            isButtonActive = false;
            choosenNum1--;
            Debug.Log(choosenNum1);

            for (int i = 0; i < 15; i++)
            {
                float targetPos = Gezegenler1[i].GetComponent<RectTransform>().anchoredPosition.x + 300f;
                Gezegenler1[i].GetComponent<RectTransform>().DOAnchorPos(new Vector2(targetPos, 0), 0.3f).OnComplete(() => isButtonActive = true);
            }
        }
        if(choosenNum1 == 0)
        {
            leftButton.SetActive(false);
        }
        else
        {
            rightButton.SetActive(true);
            leftButton.SetActive(true);
        }
    }

    IEnumerator Start1()
    {
        random1 = Random.Range(0, 15);
        GetComponent<CanvasGroup>().alpha = 0;

        yield return new WaitForSeconds(0.2f);

        for (int k = 0; k < random1; k++)
        {
            for (int i = 0; i < 15; i++)
            {
                float targetPos = Gezegenler1[i].GetComponent<RectTransform>().anchoredPosition.x - 300f;
                Gezegenler1[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(targetPos, 0, 0);
            }
        }

        GetComponent<CanvasGroup>().DOFade(1, 2f);

        cross.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        cross.SetActive(false);
        thick.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        thick.SetActive(false);

        choosenNum1 = random1;

        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);    
    }

    public void AnimationState()
    {
        GetComponent<RectTransform>().DOScale(0, 0.5f).OnComplete(() => AnimOpenAgain());
    }

    private void AnimOpenAgain()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);


        GetComponent<RectTransform>().DOScale(1, 1f);
    }

    // Mix planets locations
    IEnumerator Mix()
    {
        choosenNum1 = Random.Range(0, 15);


        yield return new WaitForSeconds(0.4f);

        SetDefaultPosition();

        yield return new WaitForSeconds(0.2f);

        for (int k = 0; k < choosenNum1; k++)
        {
            for (int i = 0; i < 15; i++)
            {

                float targetPos = Gezegenler1[i].GetComponent<RectTransform>().anchoredPosition.x - 300f;
                Gezegenler1[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(targetPos, 0, 0);
            }
        }
    }

    public void MixImages()
    {
        StartCoroutine(Mix());
        //Debug.Log(choosenNum1);
    }

    public void WinAnim()
    {
        Vector3 temp = new Vector3(1, 1, 1);
        Gezegenler1[choosenNum1].GetComponent<RectTransform>().DOScale(0f, 0.5f).OnComplete(() => Gezegenler1[choosenNum1].GetComponent<RectTransform>().localScale = temp);
        thick.SetActive(true);
        thick.GetComponent<RectTransform>().DOScale(1f, 0.5f);
    }
    public void LostAnim()
    {
        Vector3 temp = new Vector3(1, 1, 1);
        Gezegenler1[choosenNum1].GetComponent<RectTransform>().DOScale(0f, 0.5f).OnComplete(() => Gezegenler1[choosenNum1].GetComponent<RectTransform>().localScale = temp);
        cross.SetActive(true);
        cross.GetComponent<RectTransform>().DOScale(1f, 0.5f);
    }

    // Move to Default Position
    private void SetDefaultPosition()
    {
        for (int i = 0; i < 15; i++)
        {
            float defaultPos = 300 * i;
            Gezegenler1[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(defaultPos, 0, 0);

        }
    }

    // Ask new question ( Switching between questions)
    public void PlayAgain()
    {
        SetDefaultPosition();
        StartCoroutine(Start1());
    }


}
