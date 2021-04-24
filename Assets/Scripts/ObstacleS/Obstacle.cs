using UnityEngine;

public class Obstacle
{
    float obsSpeed;
    Vector3 spwanPoint;
    GameObject currentObstacle;

    public Obstacle(float obsSpeed,Vector3 spwanPoint,GameObject obstaclePrefab)
    {
        this.obsSpeed = obsSpeed;
        this.spwanPoint = spwanPoint;
        currentObstacle = GameObject.Instantiate(obstaclePrefab, spwanPoint, Quaternion.identity);
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
        get { return currentObstacle != null ? currentObstacle.transform.position : Vector3.zero; }
    }
    public string CurrentObstacle
    {
        get { return currentObstacle != null ? currentObstacle.name : ""; }
    }
    #endregion

    #region methods

    public void moveObstacle()
    {
        if(currentObstacle != null)
        currentObstacle.transform.Translate(Vector2.down * obsSpeed * Time.deltaTime);
    }
    public void destroy()
    {
        Debug.Log("slab destroy");
        if (currentObstacle != null)
        {
            Debug.Log("slab destroy-1");
            GameObject.Destroy(currentObstacle);
        }
    }
    #endregion

}
