using UnityEngine;

public class minigame : MonoBehaviour
{
    public RectTransform arrow;
    public float speed = 200f;
    public float barWidth = 400f;

   
    public RectTransform greenZone;

    bool IsArrowInGreenZone()
    {
        float arrowX = arrow.anchoredPosition.x;
        float greenLeft = greenZone.anchoredPosition.x - (greenZone.rect.width / 2f);
        float greenRight = greenZone.anchoredPosition.x + (greenZone.rect.width / 2f);

        return arrowX >= greenLeft && arrowX <= greenRight;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float pingPong = Mathf.PingPong(Time.time * speed, barWidth);
        arrow.anchoredPosition = new Vector2(pingPong - (barWidth / 2f) - 8f, arrow.anchoredPosition.y);

        if (Input.GetMouseButtonDown(0))
        {
            if (IsArrowInGreenZone())
            {
                Debug.Log("Caught the fish!");
            }
            else
            {
                Debug.Log("Missed it!");
            }
        }

    }
}
