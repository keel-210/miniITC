using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float Speed, JumpPower, up, FindTime;
    [SerializeField]
    Transform Floor;
    float hor, ver, attack;
    Transform Target;
    Rigidbody rb;
    bool OnGround;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(TargetFind(FindTime));
        Target = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        Vector3 dif = Target.position - transform.position;
        if (transform.position.magnitude > Floor.localScale.x/3)
        {
            dif = new Vector3(-transform.position.x, 0, -transform.position.z);
        }
        dif = dif.normalized;
        hor = dif.x + (Random.value - 0.5f);
        ver = dif.z + (Random.value - 0.5f);
    }
    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(Speed * hor, 0, Speed * ver));
        if (up > 0 && OnGround)
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpPower, rb.velocity.z);
            OnGround = false;
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
    IEnumerator TargetFind(float time)
    {
        while (true)
        {
            int BallsCount;
            if ((BallsCount = GameObject.FindGameObjectsWithTag("Ball").Count()) > 1)
            {
                var Targets = GameObject.FindGameObjectsWithTag("Ball").OrderBy(x => (x.transform.position - transform.position).magnitude);
                if (BallsCount <= 2)
                {
                    Target = Targets.First().transform;
                }
                else
                {
                    Target = Targets.ElementAt(1 + (int)(Random.value * 2)).transform;
                }
            }
            yield return new WaitForSeconds(time);
        }
    }
}
