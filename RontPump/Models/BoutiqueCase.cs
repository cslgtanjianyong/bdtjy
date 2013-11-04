using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    [Serializable]
    public class BoutiqueCase
    {
        public int ID { get; set; }
        private string _Logo;

        public string Logo
        {
            get {
                    if (string.IsNullOrEmpty(_Logo))
                    {
                        _Logo = "-";
                    }
                    return _Logo; 
                }
            set { _Logo = value; }
        }
        public string Client { get; set; }
        public string item { get; set; }
        private string _Background;

        public string Background
        {
            get {
                    if (string.IsNullOrEmpty(_Background))
                    {
                        _Background = "-";
                    }
                    return _Background; 
                }
            set { _Background = value; }
        }
        public string gain { get; set; }
        public int TpId { get; set; }
        private string _Challenge;

        public string Challenge
        {
            get {
                if (string.IsNullOrEmpty(_Challenge))
                {
                    _Challenge = "-";
                }
                return _Challenge; 
            }
            set { _Challenge = value; }
        }
        public string Hanye { get; set; }
        public DateTime AddTime { get; set; }
    }
}
