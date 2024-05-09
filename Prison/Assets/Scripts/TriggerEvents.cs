using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    // Create Unity events for trigger actions
    public UnityEvent enteredTrigger, exitedTrigger, stayInTrigger;

    //On Trigger enter
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            enteredTrigger.Invoke();
        }
    }

    //On Trigger stay
    void OnTriggerStay(Collider other){
        if(other.gameObject.tag == "Player"){
            stayInTrigger.Invoke();
        }
    }

    //On Trigger exit
    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Player"){
            exitedTrigger.Invoke();
        }
    }
}
