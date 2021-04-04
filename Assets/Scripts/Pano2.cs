using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Pano2 : MonoBehaviour
{
    [SerializeField] private Image[] Gezegenler2 = new Image[15];
    private bool isButtonActive = true;

    public int random2;
    public int choosenNum2;

    [SerializeField] public GameObject thick, cross;

    [SerializeField] private GameObject rightButton, leftButton;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Start2());
        choosenNum2 = random2;
    }

    public void RightButton2()
    {
        if (isButtonActive && choosenNum2 < 14)
        {
            isButtonActive = false;
            choosenNum2++;
            Debug.Log(choosenNum2);

            for (int i = 0; i < 15; i++)
            {
                float targetPos = Gezegenler2[i].GetComponent<RectTransform>().anchoredPosition.x - 300f;
                Gezegenler2[i].GetComponent<RectTransform>().DOAnchorPos(new Vector2(targetPos, 0), 0.3f).OnComplete(() => isButtonActive = true);
            }
        }

        if (choosenNum2 == 14)
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

    public void LeftButton2()
    {
        if (isButtonActive && choosenNum2 > 0)
        {
            isButtonActive = false;
            choosenNum2--;
            Debug.Log(choosenNum2);

            for (int i = 0; i < 15; i++)
            {
                float targetPos = Gezegenler2[i].GetComponent<RectTransform>().anchoredPosition.x + 300f;
                Gezegenler2[i].GetComponent<RectTransform>().DOAnchorPos(new Vector2(targetPos, 0), 0.3f).OnComplete(() => isButtonActive = true);
            }
        }

        if (choosenNum2 == 0)
        {
            leftButton.SetActive(false);
        }
        else
        {
            rightButton.SetActive(true);
            leftButton.SetActive(true);
        }
    }

    IEnumerator Start2()
    {
        random2 = Random.Range(0, 15);
        GetComponent<CanvasGroup>().alpha = 0;
        yield return new WaitForSeconds(0.2f);

        for (int k = 0; k < random2; k++)
        {
            for (int i = 0; i < 15; i++)
            {
                float targetPos = Gezegenler2[i].GetComponent<RectTransform>().anchoredPosition.x - 300f;
                Gezegenler2[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(targetPos, 0, 0);
            }
        }

        
        GetComponent<CanvasGroup>().DOFade(1, 1f);

        cross.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        cross.SetActive(false);
        thick.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        thick.SetActive(false);

        choosenNum2 = random2;

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


    IEnumerator Mix()
    {
        choosenNum2 = Random.Range(0, 15);


        yield return new WaitForSeconds(0.4f);

        SetDefaultPosition();

        yield return new WaitForSeconds(0.2f);

        for (int k = 0; k < choosenNum2; k++)
        {
            for (int i = 0; i < 15; i++)
            {

                float targetPos = Gezegenler2[i].GetComponent<RectTransform>().anchoredPosition.x - 300f;
                Gezegenler2[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(targetPos, 0, 0);
            }
        }
    }

    public void MixImages()
    {
        StartCoroutine(Mix());
        //Debug.Log(choosenNum2);
    }


    public void WinAnim()
    {
        Vector3 temp = new Vector3(1, 1, 1);
        Gezegenler2[choosenNum2].GetComponent<RectTransform>().DOScale(0f, 0.5f).OnComplete(() => Gezegenler2[choosenNum2].GetComponent<RectTransform>().localScale = temp);
        thick.SetActive(true);
        thick.GetComponent<RectTransform>().DOScale(1f, 0.5f);
    }
    public void LostAnim()
    {
        Vector3 temp = new Vector3(1, 1, 1);
        Gezegenler2[choosenNum2].GetComponent<RectTransform>().DOScale(0f, 0.5f).OnComplete(() => Gezegenler2[choosenNum2].GetComponent<RectTransform>().localScale = temp);
        cross.SetActive(true);
        cross.GetComponent<RectTransform>().DOScale(1f, 0.5f);
    }

    private void SetDefaultPosition()
    {
        for (int i = 0; i < 15; i++)
        {
            float defaultPos = 300 * i;
            Gezegenler2[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(defaultPos, 0, 0);

        }
    }

    public void PlayAgain()
    {
        SetDefaultPosition();

        StartCoroutine(Start2());
    }
}
