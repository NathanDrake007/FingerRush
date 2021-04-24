using UnityEngine;

public class RainBall : MonoBehaviour
{
    float speed = 5f;

    public Transform sprite;

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    private void Update()
    {
        sprite.Rotate(Vector3.forward, 10 * Time.deltaTime);
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
