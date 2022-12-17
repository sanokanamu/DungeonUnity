using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MassageWindowManager : MonoBehaviour
{

    public enum MessageType
    {
        UpMessage = 0,
        DownMessage = 1,
        HoleMessage = 2,
        TresureMessage = 3,
        DoorMessage = 4,
        NoKeyMessage = 5,
    }

    //�\���̂��߂̑���
    [SerializeField]
    private CanvasGroup _canvasGroup = null;

    [SerializeField]
    private Text _messageText = null;

    [SerializeField]
    private float _messageSpeed = 0.02f;
    //�E�B���h�E�̕\�����
    private bool _isDisp = false;
    private bool IsDisp => _isDisp;

    private string _dispMessage = "";
    public Dictionary<MessageType, string> _mapMessages = new Dictionary<MessageType, string>()
    {
        {MessageType.UpMessage, "{0}�K�ɏオ����" },
        {MessageType.DownMessage, "{0}�K�ɍ~�肽" },
        {MessageType.HoleMessage, "���Ƃ����I\n���̊K�ɗ������I" },
        {MessageType.TresureMessage, "{0}�̃J�M����ɓ��ꂽ" },
        {MessageType.DoorMessage, "�����J����" },
        {MessageType.NoKeyMessage, "{0}�̃J�M�������ĂȂ��I" },
    };

    /// <summary>
    /// ���̖��O
    /// </summary>
    private List<string> _keyNames = new List<string>()
    {
        "���ʂ�","���","����","�Ō��"
    };

    /// <summary>
    /// ���b�Z�[�W�̕\��
    /// </summary>
    /// <param name="message">�\�����郁�b�Z�[�W</param>
    public void DispMessage(string message)
    {
        _dispMessage = message;
        _messageText.text = "";
        StartCoroutine(FadeIn());
    }
    
    private IEnumerator FadeIn()
    {
        _canvasGroup.alpha = 0f;
        while(_canvasGroup.alpha < 1f)
        {
            _canvasGroup.alpha += Time.deltaTime;
            if(1f < _canvasGroup.alpha) _canvasGroup.alpha = 1f;
            yield return null;
        }
        yield return DispCo();
    }

    private IEnumerator DispCo()
    {
        int position = 0;
        //�����̍Ō�܂ŕ\��
        while(position < _dispMessage.Length)
        {
            _messageText.text = _dispMessage.Substring(0, position);
            position++;
            // ��ŃX�s�[�h�����p�̕ϐ���p��
            yield return new WaitForSeconds(_messageSpeed); 
        }
        _messageText.text = _dispMessage;
    }

    /// <summary>
    /// ���b�Z�[�W�̕\��
    /// </summary>
    /// <param name="messageType">���b�Z�̎��</param>
    /// <param name="number">���l</param>
    public void DispMessage(MessageType messageType, int number)
    {
        //���b�Z�[�W�����邩�ǂ����̊m�F
        if(_mapMessages.ContainsKey(messageType))
        {
            if (MessageType.NoKeyMessage == messageType || MessageType.TresureMessage == messageType)
            {
                var msg = string.Format(_mapMessages[messageType], _keyNames[number]);
                DispMessage(msg);
            }
            else
            {
                var msg = string.Format(_mapMessages[messageType], number);
                DispMessage(msg);
            }
        }
    }
    public void CloseMessege()
    {
        _canvasGroup.alpha = 0;
    }
}
