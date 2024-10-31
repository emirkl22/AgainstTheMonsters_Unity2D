using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplatter : StateMachineBehaviour
{
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("animator.gameobject will be destroyed");
        Destroy(animator.gameObject);
    }

    
}
