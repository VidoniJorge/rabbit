using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHoriztal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string walkingState = "Walking";
    private const string attackingState = "Attacking";

    public float speed = 4.0f;
    
    public const float force_key = 0.5f;

    private bool walking = false;
    public Vector2 lastMovement = Vector2.zero;

    private Animator animator;
    private Rigidbody2D playerRigibody;

    public static bool playCreated;
    public string nextPlaceName;

    public bool attacking = false;
    public float attackTime;
    private float attackTimeCount;
    
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.playerRigibody = GetComponent<Rigidbody2D>();
        if (!playCreated)
        {
            playCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.attacking = true;
            this.attackTimeCount = this.attackTime;
            this.playerRigibody.velocity = Vector2.zero;
        }

        if (this.attacking)
        {
            this.attackTimeCount -= Time.deltaTime;
            if (this.attackTimeCount <= 0)
            {
                this.attacking = false;
            }
        } else 
        { 
            if(this.isKeyPressed(horizontal) || this.isKeyPressed(vertical) )
            {
                this.walking = true;
                this.lastMovement = new Vector2(Input.GetAxisRaw(horizontal), Input.GetAxisRaw(vertical));
                this.playerRigibody.velocity = this.lastMovement
                    .normalized // Normalizo el vector, esto calcula la raiz cuadrada cuando estoy caminando en diagonal
                    * this.speed * Time.deltaTime;
            } else
            {
                this.walking = false;
                this.playerRigibody.velocity = Vector2.zero;
            }
        }
        this.animator.SetBool(attackingState, this.attacking);
        this.animator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        this.animator.SetFloat(vertical, Input.GetAxisRaw(vertical));
        this.animator.SetBool(walkingState, this.walking);
        this.animator.SetFloat(lastHoriztal, this.lastMovement.x);
        this.animator.SetFloat(lastVertical, this.lastMovement.y);
    }

    private Boolean isKeyPressed(String key)
    {
        return Mathf.Abs(Input.GetAxisRaw(key)) > force_key;
    }
}
