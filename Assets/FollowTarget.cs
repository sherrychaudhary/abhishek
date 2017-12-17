using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour
{
    [SerializeField]
    Transform mTarget;
    [SerializeField]
    float mFollowSpeed;
    [SerializeField]
    float mFollowRange;

    float mArriveThreshold = 0.05f;

    void Update ()
    {
        if(mTarget != null)
        {
            Vector3 targetPosition = new Vector3(mTarget.transform.position.x, transform.position.y, transform.position.z);
            Vector3 direction = targetPosition - transform.position;
            float distance = Vector2.Distance(targetPosition, transform.position);
            if (distance < mFollowRange)
            {

                transform.Translate(direction.normalized * mFollowSpeed * Time.deltaTime);
            }
        }
    }

    public void SetTarget(Transform target)
    {
        mTarget = target;
    }
}