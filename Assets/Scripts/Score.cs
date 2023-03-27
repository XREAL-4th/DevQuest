using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // text를 사용하기 위해 이 네임스페이스 반드시 추가.

public class Score : MonoBehaviour
{
    Text text;
    public static int coinAmount;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = coinAmount.ToString(); // 코인획득시 Coin.cs의 1씩 증가되는 값을 문자로 변환하여 text변수에 저장.
    }
}
