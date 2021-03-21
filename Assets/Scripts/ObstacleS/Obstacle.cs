using UnityEngine;

public class Obstacle
{
    float obsSpeed;
    Vector3 spwanPoint;
    GameObject obstaclePrefab;
    GameObject currentObstacle;

    public Obstacle(float obsSpeed,Vector3 spwanPoint,GameObject obstaclePrefab)
    {
        this.obsSpeed = obsSpeed;
        this.spwanPoint = spwanPoint;
        this.obstaclePrefab = obstaclePrefab;

    }

    #region properties 
    public float ObstacleSpeed
    {
        get { return obsSpeed; }
    }
    public Vector3 SpwanPoint
    {
        get { return spwanPoint; }
    }
    public Vector3 CurrentPosition
    {
        get { return currentObstacle.transform.position; }
    }
    public string CurrentObstacle
    {
        get { return currentObstacle.name; }
    }
    #endregion

    #region methods
    public void Initialize()
    {
        currentObstacle = GameObject.Instantiate(obstaclePrefab, spwanPoint, Quaternion.identity);
    }

    public void moveObstacle()
    {
        currentObstacle.transform.Translate(Vector2.down * obsSpeed * Time.deltaTime);
    }
    public void destroy()
    {
        GameObject.Destroy(currentObstacle);
    }
    #endregion

}
