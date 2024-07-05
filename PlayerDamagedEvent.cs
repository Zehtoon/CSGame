using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Define custom event classes
[System.Serializable]
public class PlayerDamagedEvent : UnityEvent<int> { }
