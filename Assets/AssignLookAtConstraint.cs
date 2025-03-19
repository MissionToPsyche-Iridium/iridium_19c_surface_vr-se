using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AssignLookAtConstraint : MonoBehaviour
{
    // Start is called before the first frame update

    private LookAtConstraint _constraint;
    
    void Start()
    {
        _constraint = this.GetComponent<LookAtConstraint>();
        if (_constraint == null)
        {
            Debug.Log("AssignLookAtConstraint on " + this.name + ": Error can not find Look At Constraint component");
        }
        else
        {
            //Remove the default constraint
            _constraint.RemoveSource(0);
            
            //Add the main camera's tranform as a constraint source so the LookAtConstrain component will look at the new transform.
            ConstraintSource newSource = new ConstraintSource();
            newSource.sourceTransform = Camera.main.transform;
            newSource.weight = 1;
            _constraint.AddSource(newSource);
        }
    }
}
