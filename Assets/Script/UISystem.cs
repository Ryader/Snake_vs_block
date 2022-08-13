using UnityEngine;
using UnityEngine.UI;
using NTC.Global.Cache;

internal class UISystem : NightCache , INightRun
{
    [SerializeField] private Text textRecord;
    [SerializeField] private SnakeTail labelRecord;
    [SerializeField] internal int _numberRecord;


    public void Run()
    {
        _numberRecord = labelRecord._record;
        textRecord.text = _numberRecord.ToString();
    }
}
