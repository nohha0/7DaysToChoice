using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialog
{
    public Dialog(string _Event, string _Name, string _Face, string _Line, string _IsClose)
    { Event = _Event; Name = _Name; Face = _Face; Line = _Line; IsClose = _IsClose; }

    public string Event, Name, Face, Line, IsClose;
}

[System.Serializable]
public class UnexpectedDialog
{
    public UnexpectedDialog(string _id, string _BG, string _name, string _face, string _time, string _line)
    { id = _id; BG = _BG; name = _name; face = _face; time = _time; line = _line; }

    public string id, BG, name, face, time, line;
}

[System.Serializable]
public class VisualDialog
{
    public VisualDialog(string _Event, string _day, string _BG, string _Time, string _Name, string _Face, string _Choice, string _Line)
    { Event = _Event; day = _day; BG = _BG; time = _Time; Name = _Name; Face = _Face; choice = _Choice; Line = _Line; }

    public string Event, day, BG, time, Name, Face, choice, Line;
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
    public TextAsset ShelterDialogFile;
    public List<Dialog> ShelterDialog;
    public List<int> SDIndex;
    public int[] FellowDialogState = { 0, 0, 0 };

    public TextAsset VisualDialogFile;
    public List<VisualDialog> VisualDialog;
    public List<int> VDIndex;
    public int VDState = 0;

    public TextAsset UnexpectedDialogFile;
    public List<UnexpectedDialog> UnexpectedDialog;
    public List<int> UDIndex;
    public int UDState = 0;

    //ĳ���� ���
    public string[] chars = { "������", "�ż���", "��ȭ��", "������" };
    Character Jung_Yoonwoo;
    Character Shin_Seri;
    Character Yoo_Hwaseul;
    Character Seo_Shinpyeong;

    [SerializeField]
    public List<Character> characters;
    public List<Sprite> Faces;

    void Start()
    {
        Jung_Yoonwoo = new MainCharacter("������");
        Shin_Seri = new Fellow("�ż���");
        Yoo_Hwaseul = new Fellow("��ȭ��");
        Seo_Shinpyeong = new Fellow("������");

        characters.Add(Jung_Yoonwoo);
        characters.Add(Shin_Seri);
        characters.Add(Yoo_Hwaseul);
        characters.Add(Seo_Shinpyeong);

        string[] Shelter_Dialog_Rows = ShelterDialogFile.text.Substring(0, ShelterDialogFile.text.Length - 1).Split('\n');
        for (int i = 0; i < Shelter_Dialog_Rows.Length; i++)
        {
            string[] row = Shelter_Dialog_Rows[i].Split('\t');
            ShelterDialog.Add(new Dialog(row[0], row[1], row[2], row[3], row[4]));

            if (row[0] != "")
            {
                SDIndex.Add(i);
            }
        }

        string[] Visual_Dialog_Rows = VisualDialogFile.text.Substring(0, VisualDialogFile.text.Length - 1).Split('\n');
        for (int i = 0; i < Visual_Dialog_Rows.Length; i++)
        {
            string[] row = Visual_Dialog_Rows[i].Split('\t');
            VisualDialog.Add(new VisualDialog(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7]));

            if (row[0] != "")
            {
                VDIndex.Add(i);
            }
        }

        string[] Unexpected_Dialog_Rows = UnexpectedDialogFile.text.Substring(0, UnexpectedDialogFile.text.Length - 1).Split('\n');
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
