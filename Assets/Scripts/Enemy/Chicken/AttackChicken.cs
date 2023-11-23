using UnityEngine;

public class AttackChicken : IState
{
    public AttackChicken(Rigidbody2D rb, Enemy enemy) : base(rb, enemy)
    {
    }

    public override void OnEnter()
    {
        //enemy.counter = 0;
        GameObject egg = ObjectPooling.Instance.GetObjectFromPool();
        egg.transform.position = enemy.transform.position;
        egg.SetActive(true);
        enemy.GetComponent<StateMachine>().ChangeStateDelay(2, ENEMY_STATE.MOVE);
    }
    public override void OnExit()
    {
        base.OnExit();
    }
}
