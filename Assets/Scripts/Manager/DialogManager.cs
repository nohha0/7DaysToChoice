using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialog //����
{
    public Dialog(string _Event, string _Name, string _Face, string _Line, string _IsClose)
    { Event = _Event; Name = _Name; Face = _Face; Line = _Line; IsClose = _IsClose; }

    public string Event, Name, Face, Line, IsClose;
}

[System.Serializable]
public class UnexpectedDialog //����
{
    public UnexpectedDialog(string _id, string _BG, string _name, string _face, string _time, string _line)
    { id = _id; BG = _BG; name = _name; face = _face; time = _time; line = _line; }

    public string id, BG, name, face, time, line;
}

[System.Serializable]
public class VisualDialog //���ν��丮 : ���� �ð� ��� �̸� ǥ�� ��� (���� ������)
{
    public VisualDialog(string _day, string _time, string _background, string _name, string _face, string _line)
    {
        day = _day; time = _time; background = _background; name = _name;face = _face;line = _line;
    }

    public string day, time, background, name, face, line;
}


public class DialogManager : MonoBehaviour
{
    //��� ���� �Ŵ���
    private static DialogManager _instance;
    public static DialogManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(DialogManager)) as DialogManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    //��� ������
    public TextAsset ShelterDialogTextFile;
    public List<Dialog> ShelterDialog;
    public List<int> SDIndex;
    public int[] FellowDialogState = { 0, 0, 0 };

    public TextAsset VisualDialogTextFile;
    public List<VisualDialog> VisualDialog;
    public List<int> VisualDialog_StartPoints;

    public int VDState = 0; //?

    public TextAsset UnexpectedDialogTextFile;
    public List<UnexpectedDialog> UnexpectedDialog;
    public List<int> UDIndex;
    public int UDState = 0;

    [SerializeField]
    public string[] chars = { "������", "�ż���", "��ȭ��", "������" };
    public List<Sprite> Faces;

    void Start()
    {
        string[] Shelter_Dialog_Rows = ShelterDialogTextFile.text.Substring(0, ShelterDialogTextFile.text.Length - 1).Split('\n');
        for (int i = 0; i < Shelter_Dialog_Rows.Length; i++)
        {
            string[] row = Shelter_Dialog_Rows[i].Split('\t');
            ShelterDialog.Add(new Dialog(row[0], row[1], row[2], row[3], row[4]));

            if (row[0] != "")
            {
                SDIndex.Add(i);
            }
        }




        //�ؽ�Ʈ ������ ��� ���ڸ� \n�� �������� �߶� ���� ������ŭ string[]�� add��
        string[] Visual_Dialog_Rows = VisualDialogTextFile.text.Substring(0, VisualDialogTextFile.text.Length - 1).Split('\n');

        //���� for�� �����鼭, �ð� ���� �����Ͱ� �ִٸ� �迭 �и��ϱ�. ���ν��丮�� ��� �� 7���� �Ǿ����.
        //�������� string[] ���鼭 �� �������� ���� �и��ؼ� ��ü�� ���� ����Ʈ�� add�ϴ� �ſ���

        for (int i = 0; i < Visual_Dialog_Rows.Length; i++)
        {
            string[] row = Visual_Dialog_Rows[i].Split('\t');
            VisualDialog.Add(new VisualDialog(row[0], row[1], row[2], row[3], row[4], row[5]));

            //���ν����ϴ°Ÿ�
            if (row[0] != "")
            {
                VisualDialog_StartPoints.Add(i);
            }
        }




        string[] Unexpected_Dialog_Rows = UnexpectedDialogTextFile.text.Substring(0, UnexpectedDialogTextFile.text.Length - 1).Split('\n');
        for (int i = 0; i < Unexpected_Dialog_Rows.Length; i++)
        {
            string[] row = Unexpected_Dialog_Rows[i].Split('\t');
            UnexpectedDialog.Add(new UnexpectedDialog(row[0], row[1], row[2], row[3], row[4], row[5]));

            if (row[0] != "")
            {
                UDIndex.Add(i);
            }
        }
    }
}
