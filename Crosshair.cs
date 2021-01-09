using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] public GameObject player;

    private Vector3 crosshair_position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CrosshairUpdate();
    }

    private void CrosshairUpdate()
    {
        crosshair_position = Input.mousePosition;
        crosshair_position.z = player.transform.position.z - Camera.main.transform.position.z;
        crosshair_position = Camera.main.ScreenToWorldPoint(crosshair_position);
        this.transform.position = crosshair_position;
    }
}
