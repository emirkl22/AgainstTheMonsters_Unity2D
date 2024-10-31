using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieGiveDamage : StateMachineBehaviour
{
    GameManager gameManager;
    AudioManager audioManager;
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
        gameManager.TakeDamage();
        audioManager.PlaySFX(audioManager.middleWall);
        Debug.Log("ZombieGiveDamage");
    }
}
