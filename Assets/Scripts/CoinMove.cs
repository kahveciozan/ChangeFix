using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinMove : MonoBehaviour
{
    [SerializeField] List<RectTransform> Coins;

   
    private void Start()
    {
        foreach (RectTransform g in Coins)
        {
            g.localScale = new Vector3(0, 0, 0);
        }
    }

    public void CoinWinEffect()
    {
        foreach(RectTransform g in Coins)
        {
            g.DOScale(1, 0.3f).OnComplete(   
                () => g.DOAnchorPos(new Vector2(218, 666), 2f).OnComplete(    
                    ()=> g.DOScale(new Vector2(0,0) , 0.1f).OnComplete(()=> ReMove(g))    )      

                    
                );
        }
    }


    private void ReMove(RectTransform g)
    {
        Vector2 temp = new Vector2(Random.Range(-160,160), Random.Range(-160,160));
        g.DOAnchorPos(temp, 0.1f);
    }

        
 



    
}
