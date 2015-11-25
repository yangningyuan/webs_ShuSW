using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace webs_YueyxShop.Model
{
    public class ResultInfo
    {
        public ResultInfo()
        { }

        public ResultInfo(bool successed, string message)
        {
            _successed = successed;
            _message = message;
        }

        public ResultInfo(bool successed, string message, object data)
        {
            _successed = successed;
            _message = message;
            //_affected = affected;
            _data = data;
        }

        public ResultInfo(bool successed, string message, object data, int affected)
        {
            _successed = successed;
            _message = message;
            _affected = affected;
            _data = data;
        }

        public ResultInfo(bool successed, string message,int returnid)
        {
            _successed = successed;
            _message = message;
            _returnid=returnid;
        }

        bool _successed = false;

        public bool Successed
        {
            get { return _successed; }
            set { _successed = value; }
        }

        string _message = string.Empty;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }


        int _affected = 0;

        public int Affected
        {
            get { return _affected; }
            set { _affected = value; }
        }


        object _data = null;

        public object Data
        {
            get { return _data; }
            set { _data = value; }
        }

        int _returnid = 0;
        public int Returnid
        {
            get { return _returnid; }
            set { _returnid = value; }
        }


    }

    public class SelectInfo
    {
        public SelectInfo(int dataValue, string dataText)
        {
            _dataText = dataText;
            _dataValue = dataValue;
        }

        int _dataValue = 0;

        public int DataValue
        {
            get { return _dataValue; }
            set { _dataValue = value; }
        }

        string _dataText = string.Empty;

        public string DataText
        {
            get { return _dataText; }
            set { _dataText = value; }
        }
    }


    //public class SelectInfo2
    //{
    //    public SelectInfo2(string value, string text)
    //    {
    //        _text = text;
    //        _value = value;
    //    }

    //    string _value = string.Empty;

    //    public string Value
    //    {
    //        get { return _value; }
    //        set { _value = value.Trim(); }
    //    }

    //    string _text = string.Empty;

    //    public string Text
    //    {
    //        get { return _text; }
    //        set { _text = value.Trim(); }
    //    }
    //}

    public class SelectInfo2
    {
        public SelectInfo2(string dataValue, string dataText)
        {
            _dataText = dataText;
            _dataValue = dataValue;
        }

        string _dataValue = string.Empty;

        public string DataValue
        {
            get { return _dataValue; }
            set { _dataValue = value; }
        }

        string _dataText = string.Empty;

        public string DataText
        {
            get { return _dataText; }
            set { _dataText = value; }
        }
    }
}
