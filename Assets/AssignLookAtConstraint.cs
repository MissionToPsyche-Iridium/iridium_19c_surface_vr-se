using UnityEngine;
using UnityEngine.Animations;

public class AssignLookAtConstraint : MonoBehaviour
{
    // Start is called before the first frame update

    private LookAtConstraint m_Constraint;

    private void Start()
    {
        m_Constraint = GetComponent<LookAtConstraint>();
        if (m_Constraint == null)
        {
            Debug.Log("AssignLookAtConstraint on " + name + ": Error can not find Look At Constraint component");
        }
        else
        {
            //Remove the default constraint
            m_Constraint.RemoveSource(0);

            //Add the main camera's transform as a constraint source so the LookAtConstrain component will look at the new transform.
            ConstraintSource newSource = new();
            if (Camera.main != null) newSource.sourceTransform = Camera.main.transform;
            newSource.weight = 1;
            m_Constraint.AddSource(newSource);
        }
    }
}