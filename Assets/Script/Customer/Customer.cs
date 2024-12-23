using System;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer sprite;
    [Header("HP Bar")]
    [SerializeField] private GameObject hpBar;
    [SerializeField] private SpriteRenderer hpBarSR;
    [SerializeField] private Sprite[] hpBarColor;
    [SerializeField] private Transform hpBarFillTransform;

    [Header("Other effects")]
    [SerializeField] private GameObject[] reviews;
    [SerializeField] private ItemDisplay thoughtItem;

    [Header("Scriptable Obj")]
    private DayLogic dayLogic;
    [SerializeField] private ItemLibrary itemLibrary;
    [SerializeField] private EventBroadcast eventBroadcast;
    private Transform target;
    private Transform[] queuePos;
    public int currentPos { get; private set; }
    private float startWaitTime = 0;
    private float maxWaitTime = 18f;
    public float satisfaction { get; private set; }
    public Item order { get; private set; }

    private void OnEnable()
    {
        startWaitTime = Time.time;
        hpBarSR.sprite = hpBarColor[0];
        hpBar.gameObject.SetActive(true);
        sprite.flipX = true;

        if(dayLogic != null)
        {
            string s = dayLogic.orderList[UnityEngine.Random.Range(0, dayLogic.orderList.Length)];
            order = Array.Find(itemLibrary.itemLibrary, x => x.itemName == s);
            Debug.Assert(order != null);
        }

        thoughtItem.gameObject.SetActive(false);

        eventBroadcast.orderComplete += LeaveTheShop;
    }
    private void OnDisable()
    {
        eventBroadcast.orderComplete -= LeaveTheShop;
    }

    private void Update()
    {
        if (Time.time - startWaitTime >= (maxWaitTime + order.price))
        {
            Debug.LogWarning("Out of patience!");
            dayLogic.AdjustHP(-1);
            dayLogic.AdjustHypeMeter(-0.4f);
            thoughtItem.gameObject.SetActive(true);
            LeaveTheShop();
        }
        else if (currentPos != queuePos.Length - 1)
        {
            // Update Patience Bar UI
            satisfaction = 1 - Mathf.Max(0f, (Time.time - startWaitTime) / (maxWaitTime + 0.5f * order.price));
            if(satisfaction > 0.8f)
            {
                hpBarSR.sprite = hpBarColor[0];
            }
            else if (satisfaction > 0.4f)
            {
                hpBarSR.sprite = hpBarColor[1];
            }
            else
            {
                hpBarSR.sprite = hpBarColor[2];
            }
            hpBarFillTransform.localScale = new Vector3(satisfaction, 1f, 1f);
        }
        if (Vector3.Distance(transform.position, target.position) > 0.1)
        {
            startWaitTime += Time.deltaTime;
            transform.position += (target.position - transform.position).normalized * speed * Time.deltaTime;
        }
        else if (transform.position != target.position)
        {
            transform.position = target.position;
            startWaitTime = Mathf.Min(Time.time, startWaitTime + 2f);
            if (transform.position == queuePos[0].position)
            {
                // Create the bubble thought
                thoughtItem.ChangeSprite(order.itemName);
                thoughtItem.gameObject.SetActive(true);
                eventBroadcast.CreateOrderNoti(this);
            }
            else if (transform.position == queuePos[queuePos.Length - 1].position)
            {
                gameObject.SetActive(false);
            }
        }
    }
    public void ChangeTarget(int t)
    {
        currentPos = t;
        target = queuePos[currentPos];
    }
    public void SetFirstPos(GameObject[] pos, Transform exitPos)
    {
        queuePos = new Transform[pos.Length + 1];
        for (int i = 0; i < pos.Length; i++)
        {
            queuePos[i] = pos[i].transform;
        }
        queuePos[queuePos.Length - 1] = exitPos;
    }
    public void SetDayLogic(DayLogic logic)
    {
        dayLogic = logic;
    }
    public void SpawnReview(string type)
    {
        switch (type)
        {
            case "Extreme":
                Instantiate(reviews[0]).transform.position = transform.position + Vector3.left * 0.5f;
                break;
            case "Good":
                Instantiate(reviews[1]).transform.position = transform.position + Vector3.left * 0.5f;
                break;
            case "Bad":
                Instantiate(reviews[2]).transform.position = transform.position + Vector3.left * 0.5f;
                break;
        }
    }
    private void LeaveTheShop()
    {
        if (thoughtItem.gameObject.activeSelf)
        {
            // To make sure to run this part only once
            startWaitTime = Time.time + 1000;
            // Create the bubble thought
            sprite.flipX = false;
            hpBar.gameObject.SetActive(false);
            thoughtItem.gameObject.SetActive(false);
            eventBroadcast.LeavevQueueNoti(currentPos);
            ChangeTarget(queuePos.Length - 1);
        }
    }
}