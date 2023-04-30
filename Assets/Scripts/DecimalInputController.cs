using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_InputField))]
public class DecimalInputController : MonoBehaviour
{
    public delegate void OnValueChange(float newValue);
    public event OnValueChange ValueChange;
    TMP_InputField InputField;
    public float Value {get; private set; } = 0f;
    [SerializeField] private float DefaultValue = 0f;
    [SerializeField] private bool UseMinValue = false;
    [SerializeField] private float MinValue = 0f;
    [SerializeField] private bool UseMaxValue = false;
    [SerializeField] private float MaxValue = 0f;

    private void Start()
    {
        InputField = GetComponent<TMP_InputField>();
        InputField.onEndEdit.AddListener(delegate { OnEndEdit(); });

        Value = DefaultValue;
        InputField.text = Value.ToString();
        if(ValueChange != null)
        {
            ValueChange(Value);
        }
    }

    private void OnEndEdit()
    {
        float newValue = Value;
        if(InputField.text.Length == 0)
        {
            newValue = DefaultValue;
        }
        else
        {
            float inputValue = float.Parse(InputField.text);
            newValue = Mathf.Clamp(inputValue, (UseMinValue ? MinValue : inputValue), (UseMaxValue ? MaxValue : inputValue));
        }
        
        if(!newValue.Equals(Value))
        {
            Value = newValue;
            InputField.text = Value.ToString();

            if(ValueChange != null)
            {
                ValueChange(Value);
            }
        }   
    }
}
