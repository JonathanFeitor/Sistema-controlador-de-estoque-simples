using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Materials
    {
        private int _MCode;
        private string _MType;
        private string _MModel;
        private int _MQuantity;
        private string _MObservation;
        private string _MIdOperator;
        private DateTime _MDate;
        private int _InfMessage;
        private int _MQAlter;
        private string _MCheck;
        private string _MIdOperator2;

        [Display(Name = "Code")]
        public int MCode { get => _MCode; set => _MCode = value; }
        [Display(Name = "Materials Type")]
        [Required(ErrorMessage = "This field is required!")]
        public string MType { get => _MType; set => _MType = value; }
        [Display(Name = "Model")]
        [Required(ErrorMessage = "This field is required!")]
        public string MModel { get => _MModel; set => _MModel = value; }
        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "This field is required!")]
        public int MQuantity { get => _MQuantity; set => _MQuantity = value; }
        [Display(Name = "Note")]
        public string MObservation { get => _MObservation; set => _MObservation = value; }
        [Display(Name = "User ID")]
        public string MIdOperator { get => _MIdOperator; set => _MIdOperator = value; }
        [Display(Name = "Date")]
        public DateTime MDate { get => _MDate; set => _MDate = value; }
        public int InfMessage { get => _InfMessage; set => _InfMessage = value; }
        [Display(Name = "Number")]
        public int MQAlter { get => _MQAlter; set => _MQAlter = value; }
        [Display(Name = "Input / Exit")]
        public string MCheck { get => _MCheck; set => _MCheck = value; }
        [Display(Name = "User ID")]
        public string MIdOperator2 { get => _MIdOperator2; set => _MIdOperator2 = value; }

        public Materials()
        {

        }

        public Materials(int mCode)
        {
            this.MCode = mCode;
        }

        public Materials(int mCode, string mType, string mModel, int mQuantity, string mObservation, string mIdOperator, DateTime mDate, 
            int infMessage, int number, string check, string mIdOperator2)
        {
            this.MCode = mCode;
            this.MType = mType;
            this.MModel = mModel;
            this.MQuantity = mQuantity;
            this.MObservation = mObservation;
            this.MIdOperator = mIdOperator;
            this.MDate = mDate;
            this.InfMessage = infMessage;
            this.MQAlter = number;
            this.MCheck = check;
            this.MIdOperator2 = MIdOperator2;
        }
    }
}

