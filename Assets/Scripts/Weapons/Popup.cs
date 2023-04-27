using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] private GameObject _popup;

    public void SpawnPopup(string text, Vector2 spawnPosition)
    {
        GameObject popupInstance = Instantiate(_popup, spawnPosition, Quaternion.identity);
        popupInstance.GetComponentInChildren<TextMesh>().text = text;
    }
}
