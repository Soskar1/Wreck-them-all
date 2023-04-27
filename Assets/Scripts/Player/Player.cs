using UnityEngine;

public class Player : MonoBehaviour
{
    public Controls controls;

    [HideInInspector] public Vector2 touchPos;

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();
    private void Awake() => controls = new Controls();

    private void Update()
    {
        touchPos = controls.Player.TouchPosition.ReadValue<Vector2>();
        touchPos = Camera.main.ScreenToWorldPoint(touchPos);

        transform.position = touchPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collectible>() != null)
            Destroy(collision.gameObject);
    }
}
