using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheakAnimation : MonoBehaviour
{
    private bool canPressQ = true;
    private float cooldownTime = 1f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canPressQ)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                canPressQ = false;
                animator.SetTrigger("Cheak");
                Invoke(nameof(ResetCooldown), cooldownTime);
            }
            
        }
    }
    private void ResetCooldown()
    {
        canPressQ = true;
        Debug.Log("0ÃÊ ¼Â");
    }
}
