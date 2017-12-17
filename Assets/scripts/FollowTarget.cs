using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField]
    Transform mTarget;
    [SerializeField]
    float mFollowSpeed;
    [SerializeField]
    float mFollowRange;

    float mArriveThreshold = 0.05f;
    /// <summary>
    ///  if(mGrounded && Input.GetButtonDown ("Jump"))
    ////   {mRigidBody2D.AddForce(Vector2.up* mJumpForce, ForceMode2D.Impulse);}
    /// </summary>
    /// 
    ///  private void FaceDirection(Vector2 direction)
    ////{
    ////    mFacingDirection = direction;
    ////   if(direction == Vector2.right)
    ///   {
    ///     Vector3 newScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    ////  transform.localScale = newScale;
    ////    }
    ///   else
    ///   {
    ////        Vector3 newScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    ////transform.localScale = newScale;
    ///     }
    /// }
    void Update()
    {
        if (mTarget != null)
        {
            // TODO: Make the enemy follow the target "mTarget"
            //       only if the target is close enough (distance smaller than "mFollowRange")
            //      Get distance by simple substraction.
            Vector3 targetPosition = new Vector3(mTarget.transform.position.x, transform.position.y, transform.position.z);
            Vector3 direction = targetPosition - transform.position;
            float distance = Vector2.Distance(targetPosition, transform.position);
            if (distance < mFollowRange)
            {
               transform.Translate(direction.normalized * mFollowSpeed * Time.deltaTime);                
               GetComponent<Animator>().SetBool("isWalking", true);


               if (GetComponent<HealthEnemy>() && GetComponent<HealthEnemy>().healthBar)
                    GetComponent<HealthEnemy>().healthBar.gameObject.SetActive(true);


            } else
               GetComponent<Animator>().SetBool("isWalking", false); 
        }
    }

    public void SetTarget(Transform target)
    {
        mTarget = target;
    }

    public float GetDistance()
    {
        Vector3 targetPosition = new Vector3(mTarget.transform.position.x, transform.position.y, transform.position.z);
        float distance = Vector2.Distance(targetPosition, transform.position);
        return distance;
    }
}
