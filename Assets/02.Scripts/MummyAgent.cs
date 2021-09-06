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
    // 에이전트의 초기화
    public override void Initialize()
    {
    }

    // 에피소드(학습, 트레이닝)가 시작할 때마다 호출
    public override void OnEpisodeBegin()
    {
    }

    // 환경을 관측해서 브레인에 전달 (수치 데이터를 관측)
    public override void CollectObservations(VectorSensor sensor)
    {
    }

    // 브레인으로 부터 전달 받은 명령(Policy)에 따라 행동하는 메소드 (FixedUpdate)
    public override void OnActionReceived(ActionBuffers actions)
    {
    }

    // 개발자 테스트용, 모방학습을 위한 메소드
    public override void Heuristic(in ActionBuffers actionsOut)
    {
    }




}
