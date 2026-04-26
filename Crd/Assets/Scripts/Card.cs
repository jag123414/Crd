using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    public TextMeshProUGUI cardText;
    public int cardID; 
    public float rotateSpeed = 10f;
    public bool isClick = false;
    public bool isMatched = false;

    public Quaternion frontRotation = Quaternion.Euler(0, 0, 0);
    public Quaternion backRotation = Quaternion.Euler(0, 180f, 0);

    void Start()
    {
        if (cardText == null) cardText = GetComponentInChildren<TextMeshProUGUI>();
        transform.rotation = backRotation;
    }

    void Update()
    {
        if (!isMatched)
        {
            Quaternion target = isClick ? frontRotation : backRotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, target, rotateSpeed * Time.deltaTime);
        }
    }

    // [중요] 매니저가 이 함수를 호출해서 숫자를 바꿔줍니다.
    public void SetCardNum(int num)
    {
        cardID = num;
        if (cardText != null)
        {
            cardText.text = cardID.ToString();
        }
    }

    public void ClickCard()
    {
        if (isMatched || isClick) return;
        CardGame.Instance.OnCardClicked(this);
    }

    public void FlipBack()
    {
        isClick = false;
    }
}
