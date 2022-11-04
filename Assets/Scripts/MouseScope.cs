using UnityEngine;

public class MouseScope : MonoBehaviour
{
    [SerializeField] private float sensitivity = 100f;
    [SerializeField] private Transform player;

    private float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        // bloqueo de cursor al centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        //proceso de clamping (definir inicio y final)
        xRotation = Mathf.Clamp(xRotation, - 90f, 70f);
        
        //rotacion (360 grades) de la camara sobre su propio eje
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
