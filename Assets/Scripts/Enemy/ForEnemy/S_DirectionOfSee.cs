using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DirectionOfSee : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteObject;
    private Transform targetSee;

    private void Update()
    {
        if (targetSee != null)
            spriteObject.flipX = DerictionOfSee_OnLeft(targetSee);
        else
        {
            if (TryGetComponent(out S_moveEnemy s_Enemy))
            {
                if (s_Enemy.hero != null)
                    targetSee = s_Enemy.hero.transform;
            }
        }
    }

    public bool DerictionOfSee_OnLeft(Transform target)
    {
        if (gameObject.transform.position.x > target.position.x)
            return true;
        else
            return false;
    }
}
