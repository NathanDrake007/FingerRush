using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] Vector3 obstaclePosition;
    [SerializeField] GameObject[] randomObstacle;
    public float counter = 6f;
    float timeBtwObstacle = 6;
    float timeBtwSpwan = 1f;
    public float minTime = 0.5f;
    public float startObstacleSpeed = 8f;
    public float maxSpeedObstacle = 12f;
    public float rainBallSpeed = 12f;
    public float startTimeBtwSpwan = 1f;
    public GameObject player;
    bool spwan = true;
    Obstacle ob;
    private void Update()
    {
        if (timeBtwObstacle <= 0)
        {
            spwanObstacle();
            timeBtwObstacle = counter;
            if(startObstacleSpeed <= maxSpeedObstacle)
            {
                increaseSpeed();
            }
        }
        else
        {

            if (spwan)
            {
                rainBall();
                timeBtwObstacle -= Time.deltaTime;
            }
            move();
        }
    }

    private void move()
    {
        if (ob != null)
        {
            ob.moveObstacle();
            if (ob.CurrentObstacle.Equals("SlabObstacle-v1(Clone)") || ob.CurrentObstacle.Equals("SlabObstacle-v2(Clone)"))
            {
                if (ob.CurrentPosition.y + 4f < player.transform.position.y)
                {
                    spwan = true;
                }
                if (ob.CurrentPosition.y < -14)
                {

                    ob.destroy();
                }
            }
            if (ob.CurrentObstacle.Equals("SlabObstacle-v3(Clone)") || ob.CurrentObstacle.Equals("SlabObstacle-v4(Clone)"))
            {
                if (ob.CurrentPosition.y + 6f < player.transform.position.y)
                {
                    spwan = true;
                }
                if (ob.CurrentPosition.y < -16)
                {
                    ob.destroy();
                }
            }
        }
    }

    private void spwanObstacle()
    {
        int index = Random.Range(0, obstaclePrefabs.Length);
        ob = new Obstacle(startObstacleSpeed, obstaclePosition, obstaclePrefabs[index]);
        spwan = false;
    }

    private void rainBall()
    {
        if (timeBtwSpwan <= 0)
        {
            Vector3 position = new Vector3(Random.Range(-5f, 5f),12f, 0f);
            int index = Random.Range(0, randomObstacle.Length);
            GameObject ball= Instantiate(randomObstacle[index], position, Quaternion.identity);
            ball.GetComponent<RainBall>().setSpeed(rainBallSpeed);
            timeBtwSpwan = startTimeBtwSpwan;
        }
        else
        {
            timeBtwSpwan -= Time.deltaTime;
        }
    }
    private void increaseSpeed()
    {
        startObstacleSpeed++;
    }
}
