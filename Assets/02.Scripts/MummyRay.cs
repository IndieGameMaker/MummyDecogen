using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class MummyRay : Agent
{
    private Transform tr;
    private Rigidbody rb;
    private StageManager stageManager;

    public float moveSpeed = 1.5f;
    public float turnSpeed = 200.0f;

    public override void Initialize()
    {
        MaxStep = 5000;

        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        stageManager = tr.parent.GetComponent<StageManager>();
    }

    public override void OnEpisodeBegin()
    {
        // 스테이지를 초기화
        stageManager.InitStage();

        // 물리력 초기화
        rb.velocity = rb.angularVelocity = Vector3.zero;

        // 에이전트의 위치와 회전값을 설정
        tr.localPosition = new Vector3(Random.Range(-20.0f, 20.0f), 0.05f, Random.Range(-20.0f, 20.0f));
        tr.localRotation = Quaternion.Euler(Vector3.up * Random.Range(0, 360));
    }

    public override void CollectObservations(VectorSensor sensor)
    {

    }

    public override void OnActionReceived(ActionBuffers actions)
    {

    }

    /*
        이산(Discrete)
            Branch 0 정지/전진/후진 이동   => 0, 1, 2 (3개)
            Branch 1 정지/왼쪽/오른쪽 회전  => 0, 1, 2 (3개)
    */
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var actions = actionsOut.DiscreteActions;
        actions.Clear(); // 배열을 모두 0으로 초기화
    }
}
