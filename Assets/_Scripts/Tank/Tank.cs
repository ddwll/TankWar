using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tank<T> 
{
    protected T entity;
    protected TankData data;
    protected Rigidbody2D RB;
    protected Vector3 TankDirection;

    public Tank(T entity , TankData data, Rigidbody2D RB)
    {
        this.entity = entity;
        this.data = data;
        this.RB = RB;
    }

    public virtual void Start()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void physicsUpdate()
    {

    }

    public virtual void Check()
    {

    }

    protected void SetVelocity(float velocity, Vector2 workspace)
    {
        RB.MovePosition(RB.position + workspace * velocity * Time.deltaTime);
    }

    protected void Fire(Transform bulletParent)
    {
        GameObject.Instantiate(data.bulletPrefab, RB.transform.position + TankDirection * 0.27f, RB.transform.rotation, bulletParent); //new Vector3(0f ,0.23f,0f)
    }

    protected void Flip(float InputX, float InputY)
    {
        if (InputY > 0)
        {
            RB.transform.SetPositionAndRotation(RB.position, Quaternion.Euler(0f, 0f, 0f));
            TankDirection = new Vector3(0f, 1f, 0f);
        }
        else if (InputY < 0)
        {
            RB.transform.SetPositionAndRotation(RB.transform.position, Quaternion.Euler(0f, 0f, 180f));
            TankDirection = new Vector3(0f, -1f, 0f);
        }

        if (InputX > 0)
        {
            RB.transform.SetPositionAndRotation(RB.transform.position, Quaternion.Euler(0f, 0f, -90f));
            TankDirection = new Vector3(1f, 0f, 0f);
        }
        else if (InputX < 0)
        {
            RB.transform.SetPositionAndRotation(RB.transform.position, Quaternion.Euler(0f, 0f, 90f));
            TankDirection = new Vector3(-1f, 0f, 0f);
        }
    }
}
