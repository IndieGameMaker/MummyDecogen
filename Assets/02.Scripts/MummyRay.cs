using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class MummyRay : Agent
{
    private Transform tr;
    private Rigidbody rb;
    private StageManager stageManager;

    public override void Initialize()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        stageManager = tr.parent.GetComponent<StageManager>();
    }
}
