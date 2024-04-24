using UnityEngine;

public class JointFlipper : MonoBehaviour
{
    public float restPos = 0f;
    public float pressPos = 45f;
    public float hit = 10000f;
    public float flipperDamper = 150f;
    public string inputName;
    private HingeJoint hingeJoint;

    void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        hingeJoint.useSpring = true;
    }

    void Update()
    {
        JointSpring jointSpring = new JointSpring();
        jointSpring.spring = hit;
        jointSpring.damper = flipperDamper;

        // inputName "LeftJoint" ise "a" tuşuna basıldığında hareket etsin
        if (inputName == "LeftJoint" && Input.GetKey(KeyCode.A))
        {
            jointSpring.targetPosition = pressPos;
        }
        // inputName "RightJoint" ise "d" tuşuna basıldığında hareket etsin
        else if (inputName == "RightJoint" && Input.GetKey(KeyCode.D))
        {
            jointSpring.targetPosition = pressPos;
        }
        else
        {
            jointSpring.targetPosition = restPos;
        }

        hingeJoint.spring = jointSpring;
        hingeJoint.useLimits = true;
    }
}