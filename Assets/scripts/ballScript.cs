using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballScript : MonoBehaviour
{
    public Text runs;
    public int runsScored = 0;
    public Text wickets;
    public int wicketsLost = 0;
    public GameObject ball;

    // static instance of GameManager which allows it to be accessed by any other script
    public static ballScript instance;
    public GameObject currBall;
    public Vector3 ballPos;

    // Update is called once per frame
    private void Awake()
    {
        instance = this;
        updateRuns(0);
        updateWickets(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ballThrow();
        }
    }

    public void ballThrow()
    {
        // the object will be instantiated with its default rotation.
        Instantiate(ball, ballPos, Quaternion.identity);
    }

    public void updateRuns(int scores)
    {
        runsScored += scores;
        runs.text = "Total scores: " + runsScored.ToString(); // Updated this line
    }

    public void updateWickets(int wicket)
    {
        wicketsLost += wicket;
        wickets.text = "Total wickets: " + wicketsLost.ToString(); // Updated this line
    }

}
