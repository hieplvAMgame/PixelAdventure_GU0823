using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static void WaitForSeconds(this MonoBehaviour mono, float seconds, Action action)
    {
        mono.StartCoroutine(IWaitForSeconds(seconds, action));
    }
    static IEnumerator IWaitForSeconds(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }
}
