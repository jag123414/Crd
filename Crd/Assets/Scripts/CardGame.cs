using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGame : MonoBehaviour
{
    public static CardGame Instance;
    public List<Card> cards;
    private Card firstSelected;
    private Card secondSelected;

    void Awake() { Instance = this; }

    void Start() { SetupGame(); }

    void SetupGame()
    {
        // 1. 카드 개수에 맞는 숫자 리스트 생성 (0,0,1,1,2,2...)
        List<int> numbers = GeneratePairNum(cards.Count);

        // 2. 숫자 리스트를 랜덤하게 섞기 (셔플)
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

    public void OnCardClicked(Card card)
    {
        if (firstSelected == card || secondSelected != null) return;

        card.isClick = true;

        if (firstSelected == null)
        {
            firstSelected = card;
        }
        else
        {
            secondSelected = card;
            StartCoroutine(CheckMatch());
        }
    }

    IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(1.0f);

        if (firstSelected.cardID == secondSelected.cardID)
        {
            firstSelected.isMatched = true;
            secondSelected.isMatched = true;
            // 맞췄을 때 사라지게 하고 싶다면 아래 주석 해제
            // firstSelected.gameObject.SetActive(false);
            // secondSelected.gameObject.SetActive(false);
        }
        else
        {
            firstSelected.FlipBack();
            secondSelected.FlipBack();
        }

        firstSelected = null;
        secondSelected = null;
    }

    private List<int> GeneratePairNum(int cardCount)
    {
        List<int> newCardNum = new List<int>();
        int pairCount = cardCount / 2;
        for (int i = 0; i < pairCount; i++)
        {
            newCardNum.Add(i);
            newCardNum.Add(i);
        }
        return newCardNum;
    }
}
