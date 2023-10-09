using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform hpLine = null;
    [SerializeField] private TMP_Text eName = null;

    private int hp;
    private int currentHP;
    private Vector3 startLineScale;

    [HideInInspector] public UnityEvent IsDead = new UnityEvent();

    public void Initialize(int hp, string name)
    {
        eName.text = name;
        this.hp = hp;
        currentHP = hp;

        startLineScale = hpLine.transform.localScale;
    }

    public void SetDamage()
    {
        int damage = Random.Range(5, 10);
        currentHP -= damage;

        if(currentHP <= 0)
        {
            currentHP = 0;
            IsDead?.Invoke();
        }

        float coefficient = (float)currentHP / (float)hp;

        hpLine.transform.localScale = new Vector3(coefficient * startLineScale.x, startLineScale.y, startLineScale.z);
    }
}
