using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Test
{
    public List<Tilemap> tilemaps = new List<Tilemap>();

    public Tilemap Tilemaps;

    public TileBase TileBase;
    public Vector3Int mousePos;

    public void TileDeletor(List<Tilemap> tilemaps)
    {
        //Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//获取鼠标的坐标
        Vector2 mouseWorldPos = AimByMouse();
        //Vector3 position = MConversion2T(mouseWorldPos);
        //Vector3Int positionint = new Vector3Int((int)position.x, (int)position.y, (int)position.z);
        if (Input.GetMouseButtonDown(0))
        {
            //if (TileBase != null)
            //{
            //    Debug.Log(TileBase);
            //    BWallBreaker(Tilemaps.WorldToCell(AimByMouse())); //positionint

            //}
            foreach (var item in tilemaps)
            {
                Tilemaps = item;
                Debug.Log(item);
                Debug.Log("鼠标" + mouseWorldPos);
                Debug.Log("Grid" + item.WorldToCell(AimByMouse()));
                WallBreaker(item.WorldToCell(AimByMouse()));
                //Tilemaps = item;
                //TileBase = Tilemaps.GetTile(Tilemaps.WorldToCell(AimByMouse())); //positionint           
            }

        }
    }

    /// <summary>
    /// 砖块破坏
    /// </summary>
    public void WallBreaker(Vector3Int pos) 
    {
        Tilemaps.SetTile(pos, null);
        //Tilemaps.SetTile(MouseAim(), null);
    }

    /// <summary>
    /// 屏幕鼠标坐标
    /// </summary>
    /// <returns></returns>
    public Vector2 AimByMouse()
    {
        Vector2 mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }

    /// <summary>
    /// 屏幕鼠标坐标转换Tile坐标
    /// </summary>
    /// <param name="mouseWorldPos"></param>
    /// <returns></returns>
    private Vector2 MConversion2T(Vector2 mouseWorldPos)
    {
        int x = 0;
        int y = 0;
        
        if (mousePos.x >= 0)
            x = Mathf.FloorToInt(mouseWorldPos.x / 0.5f);   
        else
            x = Mathf.CeilToInt(mouseWorldPos.x / 0.5f);

        if (mousePos.y >= 0)
            y = Mathf.FloorToInt(mouseWorldPos.y / 0.5f);
        else
            y = Mathf.CeilToInt(mouseWorldPos.y / 0.5f);


        Vector2 position = new Vector2((float)x, (float)y);
        //Debug.Log("Vector2 position" + position);
        return position;
    }

    public Vector2 Conversion2T(Vector2 Pos)
    {
        int x = 0;
        int y = 0;

        if (mousePos.x >= 0)
            x = Mathf.FloorToInt(Pos.x / 0.5f);
        else
            x = Mathf.CeilToInt(Pos.x / 0.5f);

        if (mousePos.y >= 0)
            y = Mathf.FloorToInt(Pos.y / 0.5f);
        else
            y = Mathf.CeilToInt(Pos.y / 0.5f);


        Vector2 position = new Vector2((float)x, (float)y);
        //Debug.Log("Vector2 position" + position);
        return position;
    }
}
