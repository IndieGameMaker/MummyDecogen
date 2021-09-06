using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;   // MLAgents의 기본 네임스페이스
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

/*
    에이전트의 역할
    1. 관측(Observations)
    2. 행동(Actions)
    3. 보상(Reward)
*/

public class MummyAgent : Agent
{
    private Rigidbody rb;
    private Transform tr;
    private Transform targetTr;

    // 에이전트의 초기화
    public override void Initialize()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        targetTr = tr.parent.Find("Target").transform;
    }

    // 에피소드(학습, 트레이닝)가 시작할 때마다 호출
    public override void OnEpisodeBegin()
    {
        // 물리력을 초기화
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // 에이전트의 위치를 불규칙하게 변경
        tr.localPosition = new Vector3(Random.Range(-4.0f, 4.0f), 0.05f, Random.Range(-4.0f, 4.0f));
        // 타겟의 위치를 변경
        targetTr.localPosition = new Vector3(Random.Range(-4.0f, 4.0f), 0.55f, Random.Range(-4.0f, 4.0f));
    }

    // 환경을 관측해서 브레인에 전달 (수치 데이터를 관측)
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(tr.localPosition);        // 3
        sensor.AddObservation(targetTr.localPosition);  // 3
        sensor.AddObservation(rb.velocity.x);           // 1
        sensor.AddObservation(rb.velocity.z);           // 1
    }

    // 브레인으로 부터 전달 받은 명령(Policy)에 따라 행동하는 메소드 (FixedUpdate)
    public override void OnActionReceived(ActionBuffers actions)
    {
        var action = actions.ContinuousActions;

        float v = Mathf.Clamp(action[0], -1.0f, 1.0f); //전/후진
        float h = Mathf.Clamp(action[1], -1.0f, 1.0f); //좌/우

        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);
        rb.AddForce(dir.normalized * 50.0f);

        // 지속적인 움직임(행동)을 유도하기 위한 마이너스 패널티
        SetReward(-0.001f);

        //Debug.Log($"action[0]={action[0]}, action[1]={action[1]}");
    }

    // 개발자 테스트용, 모방학습을 위한 메소드
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var actions = actionsOut.ContinuousActions;
        // Input.GetAxis("Horizontal")  => -1.0f ~ 0.0f ~ +1.0f  Continuous (연속)
        // Input.GetAxisRaw("Horizontal") => -1.0f, 0.0f, +1.0f  Discrete (이산)

        // 전/후진 W/S/Up/Down
        actions[0] = Input.GetAxis("Vertical"); // -1.0f ~ 0.0f ~ +1.0f
        // 좌/우 A/D/Left/Right
        actions[1] = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("TARGET"))
        {
            SetReward(+1.0f);
            EndEpisode();
        }

        if (coll.collider.CompareTag("DEAD_ZONE"))
        {
            SetReward(-1.0f);
            EndEpisode();
        }
    }



}
