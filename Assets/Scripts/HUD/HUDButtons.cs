using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDButtons : MonoBehaviour
{
    public void OpenOrCloseWindow(GameObject window) => window.SetActive(!window.activeSelf);
}
