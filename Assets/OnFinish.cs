using UnityEngine;

public class OnFinish : StateMachineBehaviour
{
    private string animation;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.GetComponent<PlayerController_2>().ChangeAnimation(animation, 0.2f, stateInfo.length);
    }
}
