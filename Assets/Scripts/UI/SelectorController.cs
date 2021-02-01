using UnityEngine;
using UnityEngine.UI;

public class SelectorController : MonoBehaviour
{
    public int numberOfPositions;

    public Transform[] positions;

    public GameObject[] actions;

    private int currentPosition;

    void Start()
    {
        currentPosition = 0;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            MovePosition(1);
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            MovePosition(-1);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            DoAction();
        }
    }

    void DoAction()
    {
        if(actions[currentPosition] != null)
            actions[currentPosition].GetComponent<Button>().onClick.Invoke();
    }

    void MovePosition(int direction)
    {
        if(direction == 1 && currentPosition == numberOfPositions - 1)
        {
            currentPosition = 0;
        }
        else if(direction == -1 && currentPosition == 0)
        {
            currentPosition = numberOfPositions - 1;
        }
        else
        {
            currentPosition += direction;
        }

        transform.position = positions[currentPosition].position;
    }
}
