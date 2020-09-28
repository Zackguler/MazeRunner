using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{

    private Vector3 currentJumpVelocity;
    private bool isJumping;



    // Use this for initialization


    // Update is called once per frame
    void Update()
    {

        CharacterController controller = GetComponent<CharacterController>();

        float speed = 10;

        Vector3 moveVelocity = transform.forward * Input.GetAxis("Vertical") * speed;

        float turnDegreesInSecond = 90;

        float horizontalInput = Input.GetAxis("Horizontal");

        if (!Mathf.Approximately(horizontalInput, 0))
        {
            transform.Rotate(0, horizontalInput * turnDegreesInSecond * Time.deltaTime, 0);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                isJumping = true;
                currentJumpVelocity = Vector3.up * 5;
            }
        }

        if (isJumping)
        {
            controller.Move((moveVelocity + currentJumpVelocity) * Time.deltaTime);

            currentJumpVelocity += Physics.gravity * Time.deltaTime;

            if (controller.isGrounded)
            {
                isJumping = false;
            }
        }
        else
        {
            controller.SimpleMove(moveVelocity);
        }



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FinishArea")
        {
            LevelManager.instance.levelComplete = true;
            LevelManager.instance.onComplete();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "FinishArea" && LevelManager.instance.coinScore < LevelManager.instance.levelScore)
        {
            UI_Manager.instance.finalText.text = "You have to gather requested coin amount";
            UI_Manager.instance.finalTextUpdate();
        }
        
    } 
}
