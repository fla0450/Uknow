using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float movePower=1f;
    int movementFlag=0;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine("ChangeMovement");
    }
    void FixedUpdate(){
        Move();
    }
    IEnumerator ChangeMovement(){

        movementFlag=Random.Range(1,3);
        yield return new WaitForSeconds(3f);
        StartCoroutine("ChangeMovement");
    }
    
    void Move(){
        Vector3 moveVelocity=Vector3.zero;
        if(movementFlag==1){
            moveVelocity=Vector3.left;
            transform.localScale =new Vector3(1,1,1);
        }else if(movementFlag==2){
            moveVelocity=Vector3.right;
            transform.localScale=new Vector3(-1,1,1);
        }
        transform.position+=moveVelocity*movePower*Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D other){
        if(creatureType == 0)return;
        if(other.gameObject.tag=="Player"){
            traceTarget=other.gameObject;
            StopCoroutine("ChangeMovent");
        }
    }
    void OnTriggerStay2D(Collider2D other){
        if(creaturerType==0)
    }
}
