using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    public static Action OnFireAnimationEvent;

    public void Fire()
    {
        OnFireAnimationEvent?.Invoke();
    } 
    
}
