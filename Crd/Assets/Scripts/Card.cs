using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    public TextMeshProUGUI cardText;
    private string cardNum;
    public float rotateSpeed = 10f;
    public bool isClick = false;

    public Quaternion frontRotation = Quaternion.Euler(0, 0, 0);
    public Quaternion backRotation = Quaternion.Euler(0, 180f, 0);

    void Start()
    {
        // 시작할 때 카드는 뒷면을 보고 있게 함
        transform.rotation = backRotation;
    }

    // [중요] 매니저가 숫자를 넣어줄 함수
    public void SetCardNum(int num)
    {
        cardNum = num.ToString();
        cardText.text = cardNum;
    }

    void Update()
    {
        // 클릭 여부에 따라 부드럽게 회전
        Quaternion target = isClick ? frontRotation : backRotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, target, rotateSpeed * Time.deltaTime);
    }

    public void ClickCard()
    {
        isClick = !isClick;
    }
}
