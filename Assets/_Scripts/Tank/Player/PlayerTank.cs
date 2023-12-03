using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerTank : Tank<Player>
{
    private Vector2 workspace;

    public PlayerTank(Player entity, TankData data, Rigidbody2D RB) : base(entity, data, RB)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        workspace = new Vector2(entity.InputX, entity.InputY);

        if (UnityEngine.Input.GetMouseButtonDown(1))
        {
            Fire(entity.bulletParent);
        }
    }

    public override void physicsUpdate()
    {
        base.physicsUpdate();

        SetVelocity(data.TankSpeed, workspace);
        Flip(entity.InputX, entity.InputY);
    }

    public override void Start()
    {
        base.Start();
    }

}
