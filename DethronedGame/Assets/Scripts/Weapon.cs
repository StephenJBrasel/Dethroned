using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType
{
    physical,
    instant
}

public enum ContactBehavior
{
    none,
    spread,
    explode,
    burn,
    corrode,
    paralyze,
    slow
}

public class Weapon : MonoBehaviour
{
    [SerializeField] private ProjectileType pType = ProjectileType.physical;
    [SerializeField] private ContactBehavior[] behaviors;
    [SerializeField] private int numProjectiles = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (behaviors == null)
            behaviors = new ContactBehavior[] { ContactBehavior.none };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {

    }
}
