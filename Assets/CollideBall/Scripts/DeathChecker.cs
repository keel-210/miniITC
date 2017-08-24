using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChecker : MonoBehaviour
{
    [SerializeField]
    Object Effect;
    GameController gc;
    private void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }
    void Update ()
    {
		if(transform.position.y < -6)
        {
            gameObject.SetActive(false);
            gc.Check();
            if (Effect)
            {
                Instantiate(Effect, transform.position, transform.rotation);
            }
        }
	}
}
