using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] GameObject playButton, checkButton;
    // Start is called before the first frame update
    void Start()
    {
        PlayAgain();
    }



    public void AnimationState()
    {
        playButton.GetComponent<RectTransform>().DOScale(0, 0.5f).OnComplete(() => StartCoroutine(ActivateCheckButton()) );
    }

    IEnumerator ActivateCheckButton()
    {
        yield return new WaitForSeconds(0.5f);

        playButton.SetActive(false);
        checkButton.SetActive(true);

        checkButton.GetComponent<RectTransform>().DOScale(1, 0.5f);
    }
    
    public void PlayAgain()
    {
        checkButton.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);

        playButton.SetActive(true);
        checkButton.SetActive(false);

        playButton.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);

        playButton.GetComponent<RectTransform>().DOScale(1, 0.5f);
    }


}
