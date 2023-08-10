using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportScript : MonoBehaviour
{
    public UnityEvent action;
    private void OnTriggerEnter(Collider other)
    {
        action.Invoke();
    }
}
