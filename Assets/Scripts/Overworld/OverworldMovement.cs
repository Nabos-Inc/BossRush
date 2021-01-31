using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Waypoint
{
    public GameObject spot;
    public List<GameObject> nextWaypoints;

    public List<GameObject> beforeWaypoints;

    public bool bossWaypoint;

    public string sceneName;

    public bool isCompleted;
}

public class OverworldMovement : MonoBehaviour
{

    public GameManager gameManager;
    public GameObject character;
    public List<Waypoint> waypoints;

    public Sprite completedSprite;

    private Waypoint currentWaypoint;

    private int waypointIndex = 0;

    void Start()
    {
        if(waypoints != null)
            currentWaypoint = waypoints[waypointIndex];
        
        if(gameManager.data.bossDatas[0].isDone)
        {
            waypoints[3].isCompleted = true;
            waypoints[3].spot.gameObject.GetComponent<Image>().sprite = completedSprite;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D) && !currentWaypoint.bossWaypoint)
        {
            if (currentWaypoint.nextWaypoints.Count == 0) return;
            MoveCharacter(currentWaypoint.nextWaypoints[0].transform.position - character.transform.position);
            waypointIndex += 1;
            currentWaypoint = waypoints[waypointIndex];
        }
        else if(Input.GetKeyDown(KeyCode.D) && currentWaypoint.bossWaypoint && currentWaypoint.isCompleted)
        {
            if (currentWaypoint.nextWaypoints.Count == 0) return;
            MoveCharacter(currentWaypoint.nextWaypoints[0].transform.position - character.transform.position);
            waypointIndex += 1;
            currentWaypoint = waypoints[waypointIndex];
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            if (currentWaypoint.beforeWaypoints.Count == 0) return;
            MoveCharacter(currentWaypoint.beforeWaypoints[0].transform.position - character.transform.position);
            waypointIndex -= 1;
            currentWaypoint = waypoints[waypointIndex];
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(currentWaypoint.bossWaypoint)
            {
                gameManager.LoadScene(currentWaypoint.sceneName);
            }
        }
    }

    void MoveCharacter(Vector3 direction)
    {
        character.transform.Translate(direction);
    }
}
