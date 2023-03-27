using System;
using TMPro;
using UnityEngine;

namespace Presentation.View.AlarmSetting
{
    public class InputFieldValidator : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private int _maxValue;

        public event Action InputValidated;

        public string Text => _inputField.text;

        private void Awake() =>
            _inputField.characterLimit = _maxValue.ToString().Length;

        private void OnEnable() =>
            SubscribeOnInputField();

        private void OnDisable() =>
            UnsubscribeFromValidation();
        
        public void SetText(string text) =>
            _inputField.text = text;

        private void SubscribeOnInputField()
        {
            _inputField.onValidateInput += Validate;
            _inputField.onEndEdit.AddListener(Invoke);
        }

        private void UnsubscribeFromValidation()
        {
            _inputField.onValidateInput -= Validate;
            _inputField.onEndEdit.RemoveListener(Invoke);
        }
            
        private void Invoke(string _) =>
            InputValidated?.Invoke();
        
        private int GetDigitValue(int value, int index) => int.Parse(value.ToString()[index].ToString());

        private char Validate(string text, int charindex, char addedchar)
        {
            int.TryParse(text, out int number);
            
            if (int.TryParse(addedchar.ToString(), out int addedNumber) == false)
                addedNumber = 0;

            if (charindex == 0)
            {
                addedNumber = Mathf.Clamp(addedNumber, 0, GetDigitValue(_maxValue, 0));
            }

            if (charindex == 1)
            {
                int max = 9;
                if (GetDigitValue(number, 0) == GetDigitValue(_maxValue, 0))
                    max = GetDigitValue(_maxValue, 1);

                addedNumber = Mathf.Clamp(addedNumber, 0, max);
            }

            return addedNumber.ToString()[0];
        }
    }
}