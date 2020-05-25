using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHitBoxControl : MonoBehaviour
{
    [Header("2HSword Attack")]
    [SerializeField] private Collider collider_2HSA1;
    [SerializeField] private float lerpForwardUp_2HSA1 = 0.8f;
    [SerializeField] private Collider collider_2HSA2;
    [SerializeField] private float lerpForwardUp_2HSA2 = 0.2f;
    [SerializeField] private Collider collider_2HSA3;
    [SerializeField] private float lerpForwardUp_2HSA3 = 0.7f;
    [SerializeField] private Collider collider_2HSA4;
    [SerializeField] private float lerpForwardUp_2HSA4 = 0.6f;

    [Header("Fist Attack")]
    [SerializeField] private Collider collider_FA1;
    [SerializeField] private Collider collider_FA2;
    [SerializeField] private Collider collider_FA3;
    [SerializeField] private float lerpForwardUp_FA3 = 0.6f;
    [SerializeField] private Collider collider_FA4;
    [SerializeField] private float lerpForwardUp_FA4 = 0.3f;
    [SerializeField] private Collider collider_FA5;
    [SerializeField] private float lerpForwardUp_FA5 = 0.8f;
    private void Awake()
    {
        Turn_All_Off();
    }
    public void Turn_All_Off()
    {
        Fist_All_Off();
        TwoHandMelee_All_Off();

    }
    #region Sword
    public void TwoHandMelee_A1()
    {
        collider_2HSA1.enabled = true;
        collider_2HSA1.GetComponent<ForceApplyHitBox>().forceDir = Vector3.Lerp(transform.forward, Vector3.up, lerpForwardUp_FA3);

    }
    public void TwoHandMelee_A2()
    {
        collider_2HSA1.enabled = false;
        collider_2HSA2.enabled = true;
        collider_2HSA2.GetComponent<ForceApplyHitBox>().forceDir = Vector3.Lerp(transform.forward, Vector3.up, lerpForwardUp_FA3);

    }
    public void TwoHandMelee_A3()
    {
        collider_2HSA2.enabled = false;
        collider_2HSA3.enabled = true;
        collider_2HSA3.GetComponent<ForceApplyHitBox>().forceDir = Vector3.Lerp(transform.forward, Vector3.up, lerpForwardUp_FA3);

    }
    public void TwoHandMelee_A4()
    {
        collider_2HSA3.enabled = false;
        collider_2HSA4.enabled = true;
        collider_2HSA4.GetComponent<ForceApplyHitBox>().forceDir = Vector3.Lerp(transform.forward, Vector3.up, lerpForwardUp_FA3);

    }
    public void TwoHandMelee_All_Off()
    {
        collider_2HSA1.enabled = false;
        collider_2HSA2.enabled = false;
        collider_2HSA3.enabled = false;
        collider_2HSA4.enabled = false;

    }
    #endregion


    public void Fist_A1()
    {
        collider_FA1.enabled = true;
    }
    public void Fist_A2()
    {
        collider_FA1.enabled = false;
        collider_FA2.enabled = true;
    }
    public void Fist_A3()
    {
        collider_FA2.enabled = false;
        collider_FA3.enabled = true;
        collider_FA3.GetComponent<ForceApplyHitBox>().forceDir = Vector3.Lerp(transform.forward , Vector3.up, lerpForwardUp_FA3);
    }
    public void Fist_A4()
    {
        collider_FA3.enabled = false;
        collider_FA4.enabled = true;
        collider_FA4.GetComponent<ForceApplyHitBox>().forceDir = Vector3.Lerp(transform.forward, Vector3.up, lerpForwardUp_FA4);
    }
        public void Fist_A5()
    {
        collider_FA4.enabled = false;
        collider_FA5.enabled = true;
        collider_FA5.GetComponent<ForceApplyHitBox>().forceDir = Vector3.Lerp(transform.forward, Vector3.up, lerpForwardUp_FA5);
    }
    public void Fist_All_Off()
    {
        collider_FA1.enabled = false;
        collider_FA2.enabled = false;
        collider_FA3.enabled = false;
        collider_FA4.enabled = false;
        collider_FA5.enabled = false;
    }
}
