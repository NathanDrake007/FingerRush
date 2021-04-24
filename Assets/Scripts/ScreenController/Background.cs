using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed = 5;
    public float endY, startY;
    bool isScroll = false;
    private void Update()
    {
        if (isScroll)
            Scroll();
    }
    public void setScroll(bool isScroll)
    {
        this.isScroll = isScroll;
    }
    private void Scroll()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y <= endY)
        {
            transform.position = new Vector2(transform.position.x, startY);
        }
    }
}
