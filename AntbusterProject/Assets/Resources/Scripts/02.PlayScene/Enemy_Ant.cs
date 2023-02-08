using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ant : MonoBehaviour
{
    public int maxHp;
    public int currentHp;
    public float moveSpeed;
    public float rotationSpeed;

    //private Rigidbody2D myRigidBody = default;
    public Transform targetCakeTransform = default;
    public Transform targetAntTunnelTransform = default;
    public Vector3 targetPos = default;
    private GameObject pickUpCakeObj = default;
    private GameObject HpBar = default;
    public bool IsCakePickUp = default;
    public bool randomMove = default;
    private bool Is_Die = default;
    public void Start()
    {
        //myRigidBody = GetComponent<Rigidbody2D>();
        pickUpCakeObj = transform.GetChild(0).gameObject;
        pickUpCakeObj.SetActive(false);
        GameObject rootObj = GFunc.GetRootObj("GameObjs");
        rootObj.FindChildObj("PlayGround");
        targetCakeTransform = GFunc.FindChildObj(rootObj, "CakeObj").transform;
        targetAntTunnelTransform = GFunc.FindChildObj(rootObj, "AntTunnel").transform;
        HpBar = transform.GetChild(2).gameObject;
    }
    public void OnEnable()
    {
        StartCoroutine(RandMoveTargetMove_Chance());
        currentHp = maxHp;
        HpBarFilled();
    }

    public void Update()
    {
        Move();
    }

    // 개미의 움직임을 구현할 함수
    public void Move()
    {
        //myRigidBody.MovePosition(Vector2.MoveTowards(myRigidBody.position, targetPos, moveSpeed * Time.deltaTime));
        //= Vector3.MoveTowards(myRigidBody.position, targetPos, moveSpeed * Time.deltaTime);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, moveSpeed * Time.deltaTime);
        transform.LookAt2D(targetPos, rotationSpeed);
    }
    public void HpBarFilled()
    {
        HpBar.SetFilledAmount((float)currentHp / maxHp);
    }

    IEnumerator RandMoveTargetMove_Chance()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            RandomMoveTargetMove_Change();
        }
    }
    public void RandomMoveTargetMove_Change()
    {
        int randNum = Random.Range(0, 101);
        if ((0 <= randNum && randNum <= 60))
        {
            TargetToMove();
        }
        else
        {
            RandomMove(randNum);
        }
    }

    public void TargetToMove()
    {
        if (IsCakePickUp)
        {
            targetPos = targetAntTunnelTransform.localPosition;
            if (transform.localPosition == targetAntTunnelTransform.localPosition)
            {
                pickUpCakeObj.SetActive(false);
                IsCakePickUp = false;
            }
        }
        else
        {
            targetPos = targetCakeTransform.localPosition;
            if (transform.localPosition == targetCakeTransform.localPosition)
            {
                IsCakePickUp = true;
                if (GameManager.Instance.cakeLife <= 0) return;
                GameManager.Instance.PickUpCake();
                pickUpCakeObj.SetActive(true);
            }
        }
    }

    public void RandomMove(int randNum_)
    {
        Vector3 currentPos = transform.localPosition;
        if (60 < randNum_ && randNum_ <= 65)
        {
            // if (0 < currentPos.y + 40)
            // {
            //     targetPos = new Vector3(currentPos.x, 0f, 0f);
            // }
            // else
            // {
            //     targetPos = new Vector3(currentPos.x, currentPos.y + 40, 0);
            // }
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

    public void Hit(int damage)
    {
        if (currentHp - damage <= 0)
        {
            currentHp = 0;
            Die();
        }
        else
        {
            currentHp -= damage;
        }
        HpBarFilled();
    }

    public void Die()
    {
        if (pickUpCakeObj.activeSelf == true)
        {
            GameManager.Instance.CakeAdd();
        }
        pickUpCakeObj.SetActive(false);
        IsCakePickUp = false;
        ObjectPoolManager.Instance.ObjPush("Ant_Enemy", gameObject);
    }
}
