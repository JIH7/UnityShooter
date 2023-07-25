using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    public PatrolState patrolState;

    public void Initialize() {
        patrolState = new PatrolState();
        ChangeState(patrolState);
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (activeState != null) {
            activeState.Perform();
        }
    }

    public void ChangeState(BaseState newState) {
        //check activeState != null
        if (activeState != null) {
            //Run cleanup on activeState
            activeState.Exit();
        }

        activeState = newState;

        if (activeState != null) {
            //Set up new state
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }
}
