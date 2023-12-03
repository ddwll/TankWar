using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public List<Tilemap> tilemaps = new List<Tilemap>();

    public Rigidbody2D RB { get; private set; }

    public float InputX;
    public float InputY;

    public Vector2 workspace;

    public GameObject bullet; 

    private Test test;

    public Transform bulletParent;

    private PlayerTank PlayerTank;

    [SerializeField]
    private TankData PlayerData;

    private void Awake()
    {
        
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        test = new Test();
        bulletParent = GameObject.Find("BulletParent").transform;

        PlayerTank = new PlayerTank(this, PlayerData, RB);
    }

    private void Update()
    {
        PlayerTank.LogicUpdate();

        MovementInput();

        test.TileDeletor(tilemaps);
        //Debug.Log(RB.transform.position);
        //Debug.Log(test.Conversion2T(RB.transform.position));
        //Debug.Log(workspace);

        //if (Input.GetMouseButtonDown(1))
        //{
        //    Fire();
        //}
    }

    private void FixedUpdate()
    {
        PlayerTank.physicsUpdate();

        //Flip();
        //SetVelocity(moveSpeed);
    }

    /// <summary>
    /// 设置移动速度
    /// </summary>
    /// <param name="velocity"></param>
    private void SetVelocity(float velocity)
    {
        RB.MovePosition(RB.position + workspace * velocity * Time.deltaTime);
    }

    /// <summary>
    /// 移动输入
    /// </summary>
    private void MovementInput()
    {
        if (InputY == 0)
            InputX = Input.GetAxisRaw("Horizontal");  
        if (InputX == 0)
            InputY = Input.GetAxisRaw("Vertical");
               
        workspace = new Vector2(InputX, InputY);
        //workspqce.x = Input.GetAxis("Horizontal");
        //workspqce.y = Input.GetAxis("Vertical");
    }

    /// <summary>
    /// 坦克旋转
    /// </summary>
    //private void Flip()
    //{
    //    if (InputY > 0)
    //    {
    //        this.transform.SetPositionAndRotation(RB.transform.position, Quaternion.Euler(0f, 0f, 0f));
    //    }
    //    else if(InputY < 0)
    //    {
    //        this.transform.SetPositionAndRotation(RB.transform.position, Quaternion.Euler(0f, 0f, 180f));
    //    }

    //    if (InputX > 0)
    //    {
    //        this.transform.SetPositionAndRotation(RB.transform.position, Quaternion.Euler(0f, 0f, -90f));
    //    }
    //    else if (InputX < 0)
    //    {
    //        this.transform.SetPositionAndRotation(RB.transform.position, Quaternion.Euler(0f, 0f, 90f));
    //    }
    //}

    //public void Fire()
    //{
    //    Instantiate(bullet, Gun.transform.position, RB.transform.rotation, bulletParent);
    //}
}


