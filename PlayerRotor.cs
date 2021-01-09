using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotor : MonoBehaviour
{
    // Public Fields
    [SerializeField] public GameObject player;

    // Private Fields
    [SerializeField] private float adjusting_distance = -.32f;

    private Vector3 mouse_position;
    private float angle;
    float xPosition, yPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        // Acquire and adjust the position vector
        mouse_position = Input.mousePosition;
        mouse_position.z = (player.transform.position.z - Camera.main.transform.position.z);

        // Cast position vector onto world coordinates
        // Can use a new variable if needed
        mouse_position = Camera.main.ScreenToWorldPoint(mouse_position);
        mouse_position = mouse_position - player.transform.position;
        angle = Mathf.Atan2(mouse_position.y, mouse_position.x) * Mathf.Rad2Deg;
        angle -= 90;
        if (angle <= 0.0f)
        {
            angle += 360.0f;
        }
        transform.localEulerAngles = new Vector3(0, 0, angle);

        // Maintain hypotenuse
        xPosition = Mathf.Cos(Mathf.Deg2Rad * angle) * adjusting_distance;
        yPosition = Mathf.Sin(Mathf.Deg2Rad * angle) * adjusting_distance;
    }
}
