using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class EventManager : MonoBehaviour
{
    // Singleton instance
    private static EventManager instance;


    public static EventManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EventManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("EventManager");
                    instance = go.AddComponent<EventManager>();
                }
            }
            return instance;
        }
    }

    // Define dictionaries to store events
    private Dictionary<string, PlayerDamagedEvent> playerDamagedEvents = new Dictionary<string, PlayerDamagedEvent>();
    private Dictionary<string, EnemyDeathEvent> enemyDeathEvents = new Dictionary<string, EnemyDeathEvent>();

    // Method to subscribe to PlayerDamagedEvent
    public static void SubscribeToPlayerDamagedEvent(string eventName, UnityAction<int> listener)
    {
        if (!Instance.playerDamagedEvents.ContainsKey(eventName))
        {
            Instance.playerDamagedEvents[eventName] = new PlayerDamagedEvent();
        }
        Instance.playerDamagedEvents[eventName].AddListener(listener);
    }

    // Method to publish PlayerDamagedEvent
    public static void PublishPlayerDamagedEvent(string eventName, int damageAmount)
    {
        if (Instance.playerDamagedEvents.ContainsKey(eventName))
        {
            Instance.playerDamagedEvents[eventName].Invoke(damageAmount);
        }
    }

    // Method to subscribe to EnemyDeathEvent
    public static void SubscribeToEnemyDeathEvent(string eventName, UnityAction<GameObject> listener)
    {
        if (!Instance.enemyDeathEvents.ContainsKey(eventName))
        {
            Instance.enemyDeathEvents[eventName] = new EnemyDeathEvent();
        }
        Instance.enemyDeathEvents[eventName].AddListener(listener);
    }

    // Method to publish EnemyDeathEvent
    public static void PublishEnemyDeathEvent(string eventName, GameObject enemy)
    {
        if (Instance.enemyDeathEvents.ContainsKey(eventName))
        {
            Instance.enemyDeathEvents[eventName].Invoke(enemy);
        }
    }
}
