using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankData",menuName = "Data/TankData")]
public class TankData : ScriptableObject
{
    [SerializeField]
    public float TankSpeed = 1.5f;

    [SerializeField]
    public GameObject bulletPrefab;
}
