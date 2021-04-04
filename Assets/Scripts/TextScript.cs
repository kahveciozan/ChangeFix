using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimationState() 
    {
        GetComponent<RectTransform>().DOScale(0, 0.5f).OnComplete(() => StartCoroutine(OpenAgain()) );
    }

    IEnumerator OpenAgain()
    {
        GetComponent<Text>().text = "AKLINDA TUTUĞUN GEZEGENLERİ BUL";

        yield return new WaitForSeconds(0.5f);

        GetComponent<RectTransform>().DOScale(1, 1f);
    }
}
