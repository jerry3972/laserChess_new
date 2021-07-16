using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public Material material;
    LaserBeam beam1;
    // Update is called once per frame
    void Update()
    {
        Destroy(GameObject.Find("Laser Beam Red"));
        beam1 = new LaserBeam(gameObject.transform.position, gameObject.transform.right, material);
    }
}
