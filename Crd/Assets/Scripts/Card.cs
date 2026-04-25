using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    // 변수 선언 부분
    public TextMeshProUGUI card; 
    private string cardNum;

    // 게임 시작 시 한 번 실행
    void Start()
    {
        // 0~9 사이의 랜덤 숫자를 생성해 문자로 변환
        cardNum = Random.Range(0, 10).ToString();
        
        // 화면 텍스트에 숫자 표시
        if (card != null)
        {
            card.text = cardNum;
        }
    }

    // 매 프레임마다 실행 (회전 기능)
    void Update()
    {
        // Y축을 기준으로 초당 20도씩 회전합니다.
        transform.Rotate(new Vector3(0.0f, 200.0f, 0.0f) * Time.deltaTime);
    }
}
