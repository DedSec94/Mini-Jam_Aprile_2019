using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SlowPendulum : MonoBehaviour
{
    Animation anim;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDrag()
    {
        anim["Anim_GreatAxeTrap_Play"].speed = Speed;
    }
    private void OnMouseUp()
    {
        anim["Anim_GreatAxeTrap_Play"].speed = 1f;
    }

}
