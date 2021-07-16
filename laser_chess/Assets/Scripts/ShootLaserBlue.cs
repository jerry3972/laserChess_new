using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaserBlue : MonoBehaviour
{
    public Material material;
    LaserBeamBlue beam;
    // Update is called once per frame
    void Update()
    {
        Destroy(GameObject.Find("Laser Beam Blue"));
        beam = new LaserBeamBlue(gameObject.transform.position, gameObject.transform.right, material);
    }
}
