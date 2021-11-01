using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharExplain
{
    public List<string> charName = new List<string>();
    public List<string> charScript = new List<string>();

    public CharExplain() { }

    public CharExplain(int charLength)
    {
        charName.Add("����");
        charName.Add("�ü�");
        charName.Add("������");

        charScript.Add("����� ���� ���ݷ°� ü���� ���ϰ� �ִ� �������� ���� ��Ȳ������ ���������� �� ������ �����ϰ� �˴ϴ�. ����� �Բ� ������ �����ðڽ��ϱ�?");
        charScript.Add("��ø���� ���� ���� �ü��� ���� �����Կ� �־� ��߹����� ���� ���߷��� �ڶ��ϴ� �����Դϴ�. �ü��� �Բ� ������ �����ðڽ��ϱ�?");
        charScript.Add("����� ������ Ž���ϴ� ���� �ϻ��ϴ��� �������� ����� ������� ���� ������ �䱸�ϴ� �����Դϴ�. ������� �Բ� ������ �����ðڽ��ϱ�?");
    }
}
