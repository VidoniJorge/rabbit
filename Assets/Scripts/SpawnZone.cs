using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    private PlayerController thePlayer;
    private CameraFollow theCamera;

    public Vector2 faicingDirection = Vector2.zero;
    public string placeName;

    void Start()
    {
        
        this.thePlayer = FindObjectOfType<PlayerController>();
        this.theCamera = FindObjectOfType<CameraFollow>();

        if(!this.thePlayer.nextPlaceName.Equals(placeName))
        {
            return;
        }

        this.thePlayer.transform.position = this.transform.position;
        this.theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.theCamera.transform.position.z);


        this.thePlayer.lastMovement = this.faicingDirection;
    }
}
