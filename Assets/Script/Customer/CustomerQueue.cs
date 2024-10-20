using UnityEngine;

public class CustomerQueue : MonoBehaviour
{
    [SerializeField] private GameObject customerObj;
    [SerializeField] private GameObject[] queuePos;
    [SerializeField] private GameObject exitPos;
    [SerializeField] private DayLogic dayLogic;
    [SerializeField] private EventBroadcast eventBroadcast;
    private Customer[] customerPool;
    private int poolPointer = 0;
    private float lastSpawnTime = 0;
    private bool firstCustomer = true;
    private bool isClose = false;

    private void OnEnable()
    {
        isClose = false;
        eventBroadcast.leaveQueue += CheckEmptyPos;
        eventBroadcast.storeClose += CloseStore;
    }
    private void OnDisable()
    {
        eventBroadcast.leaveQueue -= CheckEmptyPos;
        eventBroadcast.storeClose -= CloseStore;
    }

    private void Awake()
    {
        lastSpawnTime = Time.time + 5f;
        firstCustomer = true;
        poolPointer = 0;
        customerPool = new Customer[queuePos.Length];
        for (int i = 0; i < customerPool.Length; i++)
        {
            customerPool[i] = Instantiate(customerObj, transform).GetComponent<Customer>();
            customerPool[i].gameObject.SetActive(false);
            customerPool[i].transform.position = exitPos.transform.position;
            customerPool[i].SetDayLogic(dayLogic);
            customerPool[i].SetFirstPos(queuePos, exitPos.transform);
            queuePos[i].SetActive(true);
        }
    }
    private void Update()
    {
        if (!isClose)
        {
            if (Time.time - lastSpawnTime > 0 && !customerPool[poolPointer].gameObject.activeSelf)
            {
                if (firstCustomer)
                {
                    firstCustomer = false;
                    eventBroadcast.StoreOpenNoti();
                }
                lastSpawnTime = Time.time + 2.5f + 7.5f * (1 - dayLogic.hypeMeter);
                SpawnCustomer(customerPool[poolPointer]);
                poolPointer++;
                if (poolPointer >= customerPool.Length)
                    poolPointer = 0;
            }
        }
        else
        {
            foreach (Customer c in customerPool)
            {
                if (c.gameObject.activeSelf)
                {
                    return;
                }
            }
            eventBroadcast.NoMoreCustomerNoti();
            gameObject.SetActive(false);
        }
    }

    private void SpawnCustomer(Customer customer)
    {
        customer.gameObject.SetActive(true);
        for (int i = 0; i < queuePos.Length; i++)
        {
            if (queuePos[i].gameObject.activeSelf)
            {
                queuePos[i].gameObject.SetActive(false);
                customer.ChangeTarget(i);
                break;
            }

        }
    }
    private void CheckEmptyPos(int posIndex)
    {
        queuePos[posIndex].gameObject.SetActive(true);
        for (int i = 0; i < customerPool.Length; i++)
        {
            Customer customer = customerPool[(poolPointer + i) % (customerPool.Length)];
            if (customer.gameObject.activeSelf && customer.currentPos > 0 && customer.currentPos < queuePos.Length && queuePos[customer.currentPos - 1].activeSelf)
            {
                queuePos[customer.currentPos].gameObject.SetActive(true);
                queuePos[customer.currentPos - 1].gameObject.SetActive(false);
                customer.ChangeTarget(customer.currentPos - 1);
            }
        }
    }
    private void CloseStore()
    {
        isClose = true;
    }
}
