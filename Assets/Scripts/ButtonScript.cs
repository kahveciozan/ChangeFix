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


    // Start Button Click Animation
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
    
    // Reset Values when game restart
    public void PlayAgain()
    {
        checkButton.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);

        playButton.SetActive(true);
        checkButton.SetActive(false);

        playButton.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);

        playButton.GetComponent<RectTransform>().DOScale(1, 0.5f);
    }

    // Check Button Click Animation
    public void CheckButtonAnim()
    {
        checkButton.GetComponent<Button>().interactable = false;
        checkButton.GetComponent<RectTransform>().DOScale(0, 1f).OnComplete(()=> checkButton.GetComponent<Button>().interactable = true );
        
    }

}
