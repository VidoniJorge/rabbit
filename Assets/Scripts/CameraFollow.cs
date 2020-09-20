using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] // para poder acceder desde unity a pesar de que sean atributos privados
    private GameObject followTarget;
    [SerializeField]
    private Vector3 targetPosition;
    [SerializeField]
    private float cameraSpeed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        this.targetPosition = new Vector3(this.followTarget.transform.position.x,
            this.followTarget.transform.position.y,
            this.transform.position.z);


        //trasposicion lineal
        this.transform.position = Vector3.Lerp(this.transform.position, this.targetPosition,
            (this.cameraSpeed * Time.deltaTime));
    }
}
