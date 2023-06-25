using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    public float recoil;
    float recoilSpeed;
    Vector3 OriginalPosition;

    private void Start()
    {
        OriginalPosition = transform.localPosition;
    }

    private void Update()
    {
        Vector3 RecoilPos = OriginalPosition - new Vector3(0f, 0f, recoil);
        transform.localPosition = Vector3.Lerp(transform.localPosition, RecoilPos, recoilSpeed);
    }

    public void GunRecoil(float Recoil, float RecoilSpeed)
    {
        recoil = Recoil;
        recoilSpeed = RecoilSpeed;
    }
}
