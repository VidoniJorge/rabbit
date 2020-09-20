using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string walking = "Walking";
    private const string direction = "Direction";

    private Rigidbody2D enemyRigibody;
    private Animator enemyAnimator;

    public float enemySpeed = 1;
    public bool isMoving;

    //tiempo en que tarda en volve a hacer un paso
    public float timeBetweenStep;
    private float timeBetweenStepCounter;
    //Tiempo que tarda en hacer un paso
    public float timeToMakeStep;
    private float timeToMakeStepCounter;

    public Vector2 directionToMakeStep;

    

    // Start is called before the first frame update
    void Start()
    {
        this.enemyRigibody = GetComponent<Rigidbody2D>();
        this.enemyAnimator = GetComponent<Animator>();
        this.initTimeBetweenStepCounter();
        this.initTimeToMakeStepCounter();
    }

    private void initTimeBetweenStepCounter()
    {
        this.timeBetweenStepCounter = this.timeBetweenStep * Random.Range(0.5f,1.5f);
    }

    private void initTimeToMakeStepCounter()
    {
        this.timeToMakeStepCounter = this.timeToMakeStep * Random.Range(0.5f, 1.5f); ;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isMoving)
        {
            this.timeToMakeStepCounter -= Time.deltaTime;
            this.enemyRigibody.velocity = this.directionToMakeStep;

            if (this.timeToMakeStepCounter <= 0)
            {
                this.isMoving = false;
                this.initTimeBetweenStepCounter();
                this.enemyRigibody.velocity = Vector2.zero;
            }
        }
        else
        {
            this.timeBetweenStepCounter -= Time.deltaTime;

            if (this.timeBetweenStepCounter <= 0)
            {
                this.isMoving = true;
                this.initTimeToMakeStepCounter();

                this.directionToMakeStep = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2)) * this.enemySpeed;
            }
        }
        this.animatorController();

    }

    private void animatorController()
    {
        
        this.enemyAnimator.SetFloat(vertical, directionToMakeStep.y);
        if(directionToMakeStep.y.Equals(1.0f) || directionToMakeStep.y.Equals(-1.0f))
        {
            this.enemyAnimator.SetFloat(horizontal, directionToMakeStep.x-0.5f);
        }
        else 
        {
            this.enemyAnimator.SetFloat(horizontal, directionToMakeStep.x);
        }
        
        this.enemyAnimator.SetBool(walking, this.isMoving);
    }
}
