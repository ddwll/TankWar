using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.Progress;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10;
    private Rigidbody2D RB;

    public LayerMask Damageable;

    private Collider2D[] Collider2Ds;

    private Vector3Int bulletPos;

    private Vector2 Direction;

    private String Wall = "Wall (UnityEngine.CompositeCollider2D)";
    private String IronWall = "IronWall (UnityEngine.CompositeCollider2D)";

    private GameObject WallSeeker;

    public Tilemap Tilemap;


    void Start()
    {
        RB = this.GetComponent<Rigidbody2D>();
        WallSeeker = gameObject.transform.Find("BrickSeeker").gameObject;       

        SetBulletMovent();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Tilemap = collision.GetComponent<Tilemap>();
        Debug.Log(collision.ToString());
        Debug.Log(collision.gameObject.layer);
        //Debug.Log(collision.ToString().Equals(Wall));

        if (collision.ToString().Equals(Wall))
        {
            Debug.Log(this.transform.position);
            Debug.Log("1" + WallSeeker.transform.position);
            //test.WallBreaker(test.Tilemaps.WorldToCell(WallSeeker.transform.position));
            //HitWall(WallSeeker.transform.position);
            TileDeletor(Tilemap);
            Destroy(this.gameObject);
        }
        else if (collision.ToString().Equals(IronWall))
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.layer == 6)
        {
            Destroy(this.gameObject);
        }
    }

    public void TileDeletor(Tilemap tilemap)
    {       
        WallBreaker(tilemap.WorldToCell(WallSeeker.transform.position));        
    }

    /// <summary>
    /// ×©¿éÆÆ»µ
    /// </summary>
    public void WallBreaker(Vector3Int pos)
    {
        Tilemap.SetTile(pos, null);
    }

    //private void HitWall(Vector2 pos)
    //{
    //    Vector3 position = MConversion2T(pos);
    //    Debug.Log("2" + position);
    //    Vector3Int positionint = new Vector3Int((int)position.x, (int)position.y, (int)position.z);
    //    GameObject.FindObjectOfType<Test>().SendMessage("BWallBreaker", positionint);
    //}

    //private Vector2 MConversion2T(Vector2 targetPos)
    //{
    //    int x = 0;
    //    int y = 0;

    //    if (bulletPos.x >= 0)
    //        x = Mathf.FloorToInt(targetPos.x / 0.5f);
    //    else
    //        x = Mathf.CeilToInt(targetPos.x / 0.5f);

    //    if (bulletPos.y >= 0)
    //        y = Mathf.FloorToInt(targetPos.y / 0.5f);
    //    else
    //        y = Mathf.CeilToInt(targetPos.y / 0.5f);


    //    Vector2 position = new Vector2((float)x, (float)y);
    //    Debug.Log("Vector2 position" + position);
    //    return position;
    //}

    private void SetBulletMovent()
    {
        if (this.transform.rotation.eulerAngles == new Vector3(0f, 0f, 0f))
        {
            RB.velocity = new Vector2(0f, bulletSpeed);
            Direction = new Vector2(0f, 1f);
        }
        else if (this.transform.rotation.eulerAngles == new Vector3(0f, 0f, 90f))
        {
            RB.velocity = new Vector2(-bulletSpeed, 0f);
            Direction = new Vector2(-1f, 0f);
        }
        else if (this.transform.rotation.eulerAngles == new Vector3(0f, 0f, 180f))
        {
            RB.velocity = new Vector2(0f, -bulletSpeed);
            Direction = new Vector2(0f, -1f);
        }
        else if (this.transform.rotation.eulerAngles == new Vector3(0f, 0f, 270f))
        {
            RB.velocity = new Vector2(bulletSpeed, 0f);
            Direction = new Vector2(1f, 0f);
        }
    }

    //private void FindGrid()
    //{
    //    tilemaps.Add(Tilemap.GetComponent<Tilemap>());
    //}
}
