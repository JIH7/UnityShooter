public abstract class BaseState {
    public Enemy enemy;
    public StateMachine stateMachine;
    //Instance of state machine class

    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();
}