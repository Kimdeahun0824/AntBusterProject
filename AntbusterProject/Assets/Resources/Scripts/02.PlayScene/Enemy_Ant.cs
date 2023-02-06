using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ant : MonoBehaviour
{
    public Transform targetCakeTransform = default;
    public Transform targetAntTunnelTransform = default;
    public Vector3 targetPos = default;
    public float speed;
    public bool IsCakePickUp = default;
    public bool randomMove = default;
    public void Start()
    {
        GameObject rootObj = GFunc.GetRootObj("GameObjs");
        targetCakeTransform = GFunc.FindChildObj(rootObj, "CakeObj").transform;
        targetAntTunnelTransform = GFunc.FindChildObj(rootObj, "AntTunnel").transform;

    }

    public void Update()
    {
        Move();
    }

    // 개미의 움직임을 구현할 함수
    public void Move()
    {
        if (randomMove)
        {
            if (transform.localPosition == targetPos)
            {
                randomMove = false;
            }
        }
        else
        {
            int randNum = Random.Range(0, 101);
            if ((0 <= randNum && randNum <= 80))
            {
                TargetToMove();
            }
            else
            {
                RandomMove(randNum);
                randomMove = true;
            }
        }

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, speed * Time.deltaTime);
    }

    public void TargetToMove()
    {
        if (IsCakePickUp)
        {
            targetPos = targetAntTunnelTransform.localPosition;
            if (transform.localPosition == targetAntTunnelTransform.localPosition)
            {
                IsCakePickUp = false;
            }
        }
        else
        {
            targetPos = targetCakeTransform.localPosition;
            if (transform.localPosition == targetCakeTransform.localPosition)
            {
                IsCakePickUp = true;
            }
        }
    }

    public void RandomMove(int randNum_)
    {
        Vector3 currentPos = transform.localPosition;
        if (60 < randNum_ && randNum_ <= 65)
        {
            targetPos = new Vector3(currentPos.x, currentPos.y + 40, 0);
        }
        else if (65 < randNum_ && randNum_ <= 70)
        {
            targetPos = new Vector3(currentPos.x + 40, currentPos.y + 40, 0);
        }
        else if (70 < randNum_ && randNum_ <= 75)
        {
            targetPos = new Vector3(currentPos.x + 40, currentPos.y, 0);
        }
        else if (75 < randNum_ && randNum_ <= 80)
        {
            targetPos = new Vector3(currentPos.x + 40, currentPos.y - 40, 0);
        }
        else if (80 < randNum_ && randNum_ <= 85)
        {
            targetPos = new Vector3(currentPos.x, currentPos.y - 40, 0);
        }
        else if (85 < randNum_ && randNum_ <= 90)
        {
            targetPos = new Vector3(currentPos.x - 40, currentPos.y - 40, 0);
        }
        else if (90 < randNum_ && randNum_ <= 95)
        {
            targetPos = new Vector3(currentPos.x - 40, currentPos.y, 0);
        }
        else if (95 < randNum_ && randNum_ <= 100)
        {
            targetPos = new Vector3(currentPos.x - 40, currentPos.y + 40, 0);
        }
    }
}
