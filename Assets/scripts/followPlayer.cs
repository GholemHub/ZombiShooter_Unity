using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
   public Vector2 minPosition;
   public Vector2 maxPosition;
    
    public float smooth;
    public Transform player;
    void Update()
    {
        Vector3 targetPos = new Vector3(player.position.x, player.position.y, transform.position.z);
        
        targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
        targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);

        transform.position = Vector3.Lerp(transform.position, targetPos, smooth);
    }
}
