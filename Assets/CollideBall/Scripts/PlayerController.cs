using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float Speed, JumpPower;
    [SerializeField]
    UnityEngine.Object AttackObj;
    float hor, ver, up, attack, attackPower;
    Rigidbody rb;
    bool OnGround;
    bool Attackable;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        up = Input.GetAxis("Jump");
        attack = Input.GetAxis("Fire1");
    }
    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(Speed * hor, 0, Speed * ver));
        if (!OnGround && attack > 0 && Attackable)
        {
            rb.velocity = new Vector3(rb.velocity.x, -20, rb.velocity.z);
            GameObject obj = (GameObject)Instantiate(AttackObj, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
            obj.GetComponent<Attack>().Power = attackPower;
            Attackable = false;
        }
        if (up > 0 && OnGround)
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpPower, rb.velocity.z);
            OnGround = false;
            Attackable = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            OnGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            OnGround = false;
        }
    }
    public void ValueSet(int NowNum, PlayerParam pp)
    {
        switch (pp)
        {
            case PlayerParam.Weight: WeightSet(NowNum); break;
            case PlayerParam.Speed: SpeedSet(NowNum); break;
            case PlayerParam.Attack: AttackSet(NowNum); break;
        }
    }
    void WeightSet(int NowNum)
    {
        float SpeedCash = Speed / rb.mass;
        switch (NowNum)
        {
            case 0: rb.mass = 1; break;
            case 1: rb.mass = 2; break;
            case 2: rb.mass = 4; break;
            case 3: rb.mass = 8; break;
            case 4: rb.mass = 10; break;
        }
        Speed = SpeedCash * rb.mass;
    }
    void SpeedSet(int NowNum)
    {
        switch (NowNum)
        {
            case 0: Speed = 1 * rb.mass; break;
            case 1: Speed = 2 * rb.mass; break;
            case 2: Speed = 3 * rb.mass; break;
            case 3: Speed = 4 * rb.mass; break;
            case 4: Speed = 5 * rb.mass; break;
        }
    }
    void AttackSet(int NowNum)
    {
        switch (NowNum)
        {
            case 0: attackPower = 50; break;
            case 1: attackPower = 100; break;
            case 2: attackPower = 300; break;
            case 3: attackPower = 400; break;
            case 4: attackPower = 600; break;
        }
    }
}
public enum PlayerParam
{
    Weight, Speed, Attack
}