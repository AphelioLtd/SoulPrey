using UnityEngine;
using System.Collections;
using RAIN.Core;
using RAIN.Path;


[RequireComponent(typeof(PathManager))]
[RequireComponent(typeof(Agent))]
public class MoveTowardsTarget : MonoBehaviour
{
    private PathManager pathManager;
    private Agent agent;
    public float moveSpeed = 1.0f;
    public float turnSpeed = 1.0f;

    // Use this for initialization
    void Start()
    {
        pathManager = GetComponent<PathManager>();
        agent = GetComponent<RAINAgent>().Agent;
    }

    void FixedUpdate()
    {
        if (agent.Move(Time.deltaTime * moveSpeed)) pathManager.moveTarget.VectorTarget = transform.position;
    }
}
