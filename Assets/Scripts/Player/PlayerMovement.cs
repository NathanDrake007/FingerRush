using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 50f;
    public float force = 20f;
    HighScoreSystem hs;
    private bool isControlled = false,isReleased = false;
    public bool mouseControl;
    public GameObject effect;
    GameManager gm;
    Rigidbody2D rb;
    Vector2 position;
  
    private void Start()
    {
        hs = GameObject.Find("HighScore System").GetComponent<HighScoreSystem>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        processInput();
        movePlayer();
    }
    private void processInput()
    {
        if (mouseControl && Input.GetMouseButton(0))
        {
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (findObject())
            {
                isControlled = true;
                isReleased = false;
                gm.initializeScene();
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                position = Camera.main.ScreenToWorldPoint(touch.position);
                if (touch.phase == TouchPhase.Began)
                {
                    if (findObject())
                    {
                        isControlled = true;
                        isReleased = false;
                        gm.initializeScene();
                    }
                }
                if (touch.phase == TouchPhase.Ended && isControlled)
                {
                    isControlled = false;
                    isReleased = true;
                }
            }
        }
    }

    private void movePlayer()
    {
        if (isControlled)
        {
            position.x = Mathf.Clamp(position.x, -5.2f, 5.2f);
            position.y = Mathf.Clamp(position.y, -10, 10f);
            transform.position = Vector2.MoveTowards(transform.position, position, speed * Time.deltaTime);
        }
        else if (isReleased)
        {
            if (transform.position.y > 10)
            {
                destroyPlayer();
            }
            transform.Translate(Vector2.up * force * Time.deltaTime);
        }
    }
    private bool findObject()
    {
        //We now raycast with this information. If we have hit something we can process it.
        RaycastHit2D hitInformation = Physics2D.Raycast(position, Camera.main.transform.forward);

        if (hitInformation.collider != null)
        {
            //We should have hit something with a 2D Physics collider!
            GameObject touchedObject = hitInformation.transform.gameObject;
            if (touchedObject.tag == "Player")
            {
                return true;
            }
            return false;
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
            destroyPlayer();
    }
    private void OnMouseUp()
    {
        isControlled = false;
        isReleased = true;
    }
    private void destroyPlayer()
    {
        Destroy(gameObject);
        Instantiate(effect, transform.position, Quaternion.identity);
        hs.setHighScore();
        gm.isAlive = false;
    }
}
