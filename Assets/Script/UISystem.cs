using UnityEngine;
using UnityEngine.UI;

internal class UISystem : MonoBehaviour
{
    [SerializeField] private Text textRecord;
    [SerializeField] private SnakeTail labelRecord;
    [SerializeField] internal int _numberRecord;



    private void Update()
    {
        _numberRecord = labelRecord._record;
        textRecord.text = _numberRecord.ToString();
    }
}
