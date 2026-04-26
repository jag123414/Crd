using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGame : MonoBehaviour
{
    public List<Card> cards; // 유니티 에디터에서 카드들을 넣어줄 리스트

    void Start()
    {
        SetupGame();
    }

    void SetupGame()
    {
        // 1. 숫자 짝 생성 (예: 10개 카드면 1,1,2,2,3,3,4,4,5,5)
        List<int> numbers = GeneratePairNum(cards.Count);

        // 2. 숫자 섞기 (랜덤 셔플)
        for (int i = 0; i < numbers.Count; i++)
        {
            int randomIndex = Random.Range(i, numbers.Count);
            int temp = numbers[i];
            numbers[i] = numbers[randomIndex];
            numbers[randomIndex] = temp;
        }

        // 3. 섞인 숫자를 각 카드에 전달
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].SetCardNum(numbers[i]);
        }
    }

    private List<int> GeneratePairNum(int cardCount)
    {
        List<int> newCardNum = new List<int>();
        int pairCount = cardCount / 2;

        for (int i = 0; i < pairCount; i++)
        {
            newCardNum.Add(i); // 같은 숫자 두 개씩 추가
            newCardNum.Add(i);
        }
        return newCardNum;
    }
}
