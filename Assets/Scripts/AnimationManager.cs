using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Burst;
using Unity.Jobs;
using UnityEngine.Jobs;
using Unity.Mathematics;

public class AnimationManager : MonoBehaviour
{
    Animator anim;
    public Transform[] movements, movementsNeedPos;
    TransformAccessArray nativeArray, nativeArrayPos;
    void Start()
    {
        anim = GetComponent<Animator>();
        nativeArray = new TransformAccessArray(movements);
        if (movementsNeedPos.Length > 0)
        {
            nativeArrayPos = new TransformAccessArray(movementsNeedPos);
        }
    }
    public void SetSpeed(float speed)
    {
        anim.SetFloat("speed", speed);
    }
    public void SetGrounded(bool grounded)
    {
        anim.SetBool("grounded", grounded);
    }
    public void SetDiving(bool diving)
    {
        anim.SetBool("diving", diving);
    }
    private void Update()
    {
        eulerAnglesToZero toZero = new eulerAnglesToZero { };
        toZero.Schedule(nativeArray);
        if (nativeArrayPos.length > 0)
        {
            posToZero pos = new posToZero { };
            pos.Schedule(nativeArrayPos);
        }
    }
    private void OnDestroy()
    {
        nativeArray.Dispose();
        nativeArrayPos.Dispose();
    }
}
[BurstCompile]
public struct eulerAnglesToZero : IJobParallelForTransform
{
    public void Execute(int index, TransformAccess transform)
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
[BurstCompile]
public struct posToZero : IJobParallelForTransform
{
    public void Execute(int index, TransformAccess transform)
    {
        transform.localPosition = float3.zero;
    }
}
