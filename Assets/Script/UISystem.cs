using UnityEngine;
using UnityEngine.UI;
using NTC.Global.Cache;

internal class UISystem : NightCache
{
    [SerializeField] private Text textRecord;
    [SerializeField] private SnakeTail labelRecord;
    [SerializeField] private int numberRecord;
    public int NumberRecord
    {
        get
        {
            return numberRecord;
        }
        set
        {
            numberRecord = value;

            numberRecord = labelRecord._record;
            textRecord.text = numberRecord.ToString();
        }
    }
}
