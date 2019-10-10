using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingManager : MonoBehaviour
{
    void Start()
    {
        GameObject debugUpdater = GameObject.Find("[Debug Updater]");
        debugUpdater.SetActive(false);
    }
}
