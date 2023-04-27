using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public void StartOver()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
