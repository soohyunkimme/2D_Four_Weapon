using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapons
{
    Sword,
    Bow,
    Gun,
    Boom
};

public class PlayerWeapon : MonoBehaviour
{
    public LayerMask enemiesLayer;

    public void Update()
    {
        SetRotation();
    }

    private void SetRotation()
    {
        Vector2 v = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float degree = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        //float rot = Mathf.LerpAngle(gameObject.transform.eulerAngles.z, degree, Time.deltaTime * 6f);
        transform.eulerAngles = new Vector3(0, 0, degree);
    }

    public void Attack()
    {
        Collider2D enemies = Physics2D.OverlapCircle(transform.position, 90f, 1 << enemiesLayer);
        
        if(enemies != null)
        {
            IDamageAble enemy = enemies.gameObject.GetComponent<IDamageAble>();
            enemy.OnDamage(14f, enemies.transform);
        }
    }
}
