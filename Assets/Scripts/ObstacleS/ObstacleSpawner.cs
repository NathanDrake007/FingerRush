using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] Vector3 obstaclePosition;
    [SerializeField] float[] obstacleSpeed;
    [SerializeField] GameObject ballObstacle;
    public float counter = 6f;
    float timeBtwObstacle = 6;
    float timeBtwSpwan = 1f;
    float decreaseTime = 0.05f;
    public float minTime = 0.5f;
    public float maxSpeedObstacle = 12f;
    public float startTimeBtwSpwan = 1f;
    bool spwan = true;
    Obstacle ob;
    private void Update()
    {
        if (timeBtwObstacle <= 0)
        {
            spwanObstacle();
            timeBtwObstacle = counter;
            if(obstacleSpeed[0] <= maxSpeedObstacle)
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
            else
            {
                move();
            }
        }
    }

    private void move()
    {
        if (ob.CurrentObstacle.Equals("ZigZagObstacle-v2(Clone)") || ob.CurrentObstacle.Equals("ZigZagObstacle-v4(Clone)"))
        {
            if (ob.CurrentPosition.y < -30)
            {
                ob.destroy();
                spwan = true;
            }
        }
        else if (ob.CurrentObstacle.Equals("SlabObstacle-v3(Clone)") || ob.CurrentObstacle.Equals("SlabObstacle-v4(Clone)"))
        {
            if (ob.CurrentPosition.y < -17)
            {
                ob.destroy();
                spwan = true;
            }
        }
        else if(ob.CurrentPosition.y < -12)
        {
            ob.destroy();
            spwan = true;
        }
        ob.moveObstacle();
        Debug.Log(ob.CurrentObstacle);
    }

    private void spwanObstacle()
    {
        int index = Random.Range(0, obstaclePrefabs.Length);
        ob = new Obstacle(obstacleSpeed[index], obstaclePosition, obstaclePrefabs[index]);
        ob.Initialize();
        spwan = false;
    }

    private void rainBall()
    {
        if (timeBtwSpwan <= 0)
        {
            Vector3 position = new Vector3(Random.Range(-5f, 5f),12f, 0f);
            Instantiate(ballObstacle, position, Quaternion.identity);
            timeBtwSpwan = startTimeBtwSpwan;
            if(startTimeBtwSpwan > minTime)
            {
                startTimeBtwSpwan -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpwan -= Time.deltaTime;
        }
    }
    private void increaseSpeed()
    {
        for(int i = 0;i< obstacleSpeed.Length; i++)
        {
            obstacleSpeed[i] += 1;
        }
    }
}
