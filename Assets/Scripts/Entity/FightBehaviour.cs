using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightBehaviour : MonoBehaviour
{
    private Characteristics characteristics;
    public LayerMask toSearchLayer;
    public float y = 0.6f;
    public float x = 0.4f;

    private bool hasFighten = false;
    // Start is called before the first frame update
    void Start()
    {
        characteristics = gameObject.GetComponent<Characteristics>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasFighten)
            return;
        AngerBar angerBar = FindObjectOfType<AngerBar>();
        var foe = Physics2D.OverlapCircle(this.transform.position, characteristics.FightRange, toSearchLayer);
        if (foe != null)
        {
            if (angerBar.IsRaging)
                ResolveFight(foe.gameObject, 0);
            if (foe.GetComponent<EnemyBehaviour>().IsPlayerSeen() == true)
                ResolveFight(foe.gameObject, 0);
            else if (Input.GetKeyDown(KeyCode.F))
                ResolveFight(foe.gameObject, 1);
        }
    }

    void ResolveFight(GameObject foe, int hasEngaged = 0)
    {
        var foeCharacteristics = foe.GetComponent<Characteristics>();
        var distance = Vector3.Distance(this.transform.position, foe.transform.position);
        float characterChances;
        float foeChances;
        AngerBar angerBar = FindObjectOfType<AngerBar>();
        //if (gameObject.tag == "Player")
        //{
            characterChances = Mathf.Abs((characteristics.Attack * ((angerBar.IsRaging == true ? 1 : 0) * y + x) + characteristics.Attack * hasEngaged) * (Mathf.Cos(((distance / characteristics.FightRange) > 2 ? 2 : (distance / characteristics.FightRange)) * Mathf.PI)));
            foeChances = Mathf.Abs((foeCharacteristics.Defense + foeCharacteristics.Attack * (foe.GetComponent<EnemyBehaviour>().IsPlayerSeen() == true ? (angerBar.IsRaging == true ? 0.5f : 1f) : 0f)) * Mathf.Cos(((distance / foeCharacteristics.FightRange) > 2 ? 2 : (distance / foeCharacteristics.FightRange)) * Mathf.PI));
        /*} else
        {
            characterChances = Mathf.Abs((characteristics.Attack * (angerBar.IsRaging ? 1 : 2)) * Mathf.Cos(((distance / characteristics.FightRange) > 2 ? 2 : (distance / characteristics.FightRange)) * Mathf.PI));
            foeChances = Mathf.Abs((foeCharacteristics.Defense + (foeCharacteristics.Attack * ((angerBar.IsRaging == true ? 1 : 0) * y + x))) * Mathf.Cos(((distance / foeCharacteristics.FightRange) > 2 ? 2 : (distance / foeCharacteristics.FightRange)) * Mathf.PI));
        }*/

        var result = Random.Range(0, 100);
        Debug.Log("Victory chances : " + (characterChances / (characterChances + foeChances)) * 100);
        if ((result / 100f) < (characterChances / (characterChances + foeChances)))
        {
            Debug.Log("Player won");
            Destroy(foe.transform.parent.gameObject);
        } else
        {
            Debug.Log("Enemy won");
        }
        hasFighten = true;
    }
}
