using System;
using System.Collections.Generic;
using System.Linq;
namespace Temp.DTO
{
    public abstract class BaseModel
    {
        private const string _summaryKey = "_summaryKey";
        private Dictionary<string, List<string>> _errors;

        protected BaseModel()
        {
            _errors = new Dictionary<string, List<string>>();
        }

        public void ClearErrors()
        {
            foreach (var val in _errors)
            {
                val.Value.Clear();
            }
        }

        public void SetSummaryError(string message)
        {
            SetFieldError(_summaryKey, message);
        }

        public void SetFieldError(string fieldName, string message)
        {
            if (!_errors.ContainsKey(fieldName))
                _errors.Add(fieldName, new List<string>());
            _errors[fieldName].Add(message);
        }

        public bool HasErrors
        {
            get
            {
                foreach (var val in _errors)
                {
                    if (val.Value != null && val.Value.Count > 0)
                        return true;
                }
                return false;
            }
        }

        public bool HasSummaryErrors
        {
            get { return HasFieldErrors(_summaryKey); }
        }

        public bool HasFieldErrors(string fieldName)
        {
            return _errors.ContainsKey(fieldName) && _errors[fieldName] != null && _errors[fieldName].Count > 0;
        }

        public List<string> GetSummaryErrors()
        {
            return GetFieldErrors(_summaryKey);
        }

        public List<string> GetAllErrors()
        {
            var list = new List<string>();
            foreach (var k in _errors)
            {
                list.AddRange(k.Value);
            }
            return list.Distinct().ToList();
        }

        public List<string> GetFieldErrors(string fieldName)
        {
            if (_errors.ContainsKey(fieldName))
                return _errors[fieldName];
            else return null;
        }

        public Dictionary<string, List<string>> GetErrors()
        {
            return _errors;
        }

        public void SetErrors(Dictionary<string, List<string>> errors)
        {
            _errors = errors;
        }

        public string GetSummaryError(int index = 0)
        {
            return GetFieldError(_summaryKey, index);
        }

        public string GetFieldError(string fieldName, int index = 0)
        {
            if (_errors.ContainsKey(fieldName) && _errors[fieldName] != null && _errors[fieldName].Count > 0)
            {
                return _errors[fieldName][index];
            }
            else return null;
        }
    }

    public class SimpleModel : BaseModel { }

    public enum SortDirectionType
    {
        Desc,
        Asc
    }

    public class CustomSecurityExeption : Exception
    {
        public CustomSecurityExeption() : base("У Вас недостаточно прав на выполнение данного действия")
        {
        }
    }
}
