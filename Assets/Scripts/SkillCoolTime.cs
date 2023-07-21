using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCoolTime : MonoBehaviour
{
    public Image skillFilter;
    public PlayerFire playerfire;

    public float coolTime = 15.0f;
    private float currentCoolTime; //���� ��Ÿ���� ���� �� ����
    private bool canUseSkill = true; //��ų�� ����� �� �ִ��� Ȯ���ϴ� ����

    void Start()
    {
        skillFilter.fillAmount = 0; //ó���� ��ų ��ư�� ������ ����
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            UseSkill();
        }
    }

    public void UseSkill()
    {
        if (canUseSkill)
        {
            playerfire.skill();

            skillFilter.fillAmount = 1; //��ų ��ư�� ����
            StartCoroutine("Cooltime");

            currentCoolTime = coolTime;

            StartCoroutine("CoolTimeCounter");

            canUseSkill = false; //��ų�� ����ϸ� ����� �� ���� ���·� �ٲ�
        }
        else
        {
            Debug.Log("���� ��ų�� ����� �� �����ϴ�.");
        }
    }

    IEnumerator Cooltime()
    {
        while (skillFilter.fillAmount > 0)
        {
            skillFilter.fillAmount -= 1 * Time.smoothDeltaTime / coolTime;

            yield return null;
        }

        canUseSkill = true; //��ų ��Ÿ���� ������ ��ų�� ����� �� �ִ� ���·� �ٲ�

        yield break;
    }

    IEnumerator CoolTimeCounter()
    {
        while (currentCoolTime > 0)
        {
            yield return new WaitForSeconds(1.0f);

            currentCoolTime -= 1.0f;
        }

        yield break;
    }
}
