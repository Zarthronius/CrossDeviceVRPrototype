using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Ubiq.Rooms;
using UnityEngine;
using UnityEngine.UI;
using Ubiq.Rooms;

public class JoinCodeUpdater : MonoBehaviour
{
    public Text joinCodeMenu;
    public Text joinCodeVR;
    
    public void UpdateJoinCodeMenu()
    {
        StartCoroutine(UpdateJoinCodeMenuDelayed());
    }

    private IEnumerator UpdateJoinCodeMenuDelayed()
    {
        yield return new WaitForSeconds(0.1f); // wait for half a second
        joinCodeMenu.text = joinCodeVR.text;
    }
}