using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class name is changed to HandScript from Hand to avoid naming conflicts.
public class HandScript : MonoBehaviour
{
    Animator animator;
    private float targetOfGrip;
    private float currentOfGrip;
    public float animationSpeed;
    private string gripParameterForAnimator = "Grip";


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimationOfHand();
    }


    internal void setGrip(float gripValue)
    {
        Debug.Log("Grip Value: " + gripValue);
        targetOfGrip = gripValue;
    }

    void AnimationOfHand()
    {
        if (currentOfGrip != targetOfGrip)
        {
            currentOfGrip = Mathf.MoveTowards(currentOfGrip, targetOfGrip, Time.deltaTime * animationSpeed);
            animator.SetFloat(gripParameterForAnimator, currentOfGrip);
        }
    }
}
