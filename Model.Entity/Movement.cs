using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Movement
    {
        private int _MMCode;
        private string _MMType;
        private string _MMModel;
        private int _MMQtt;
        private string _MMUseInf;
        private string _MMIdOperator;
        private DateTime _MMDate1;
        private DateTime _MMDate2;
        private int _MCode;
        private int _InfMessage;

        [Display(Name = "Code")]
        public int MMCode { get => _MMCode; set => _MMCode = value; }
        [Display(Name = "Type")]
        [Required(ErrorMessage = "This field is required!")]
        public string MMType { get => _MMType; set => _MMType = value; }
        [Display(Name = "Model")]
        [Required(ErrorMessage = "This field is required!")]
        public string MMModel { get => _MMModel; set => _MMModel = value; }
        [Display(Name = "Quantity")]
        public int MMQtt { get => _MMQtt; set => _MMQtt = value; }
        [Display(Name = "Input / Output")]
        public string MMUseInf { get => _MMUseInf; set => _MMUseInf = value; }
        [Display(Name = "User ID")]
        public string MMIdOperator { get => _MMIdOperator; set => _MMIdOperator = value; }
        [Display(Name = "Date")]
        [Required(ErrorMessage = "This field is required!")]
        public DateTime MMDate1 { get => _MMDate1; set => _MMDate1 = value; }
        [Display(Name = "Materials Code")]
        public int MCode { get => _MCode; set => _MCode = value; }
        [Required(ErrorMessage = "This field is required!")]
        public DateTime MMDate2 { get => _MMDate2; set => _MMDate2 = value; }
        public int InfMessage { get => _InfMessage; set => _InfMessage = value; }

        public Movement()
        {

        }

        public Movement(int mCode)
        {
            this.MCode = mCode;
        }

        public Movement(int mMCode, string mType, string mModel, int mQtt, string MUseInf, string mIdOperator, DateTime mDate1, DateTime mDate2,
            int mCode, int infMessage)
        {
            this.MMCode = mMCode;
            this.MMType = mType;
            this.MMModel = mModel;
            this.MMQtt = mQtt;
            this.MMUseInf = MUseInf;
            this.MMIdOperator = mIdOperator;
            this.MMDate1 = mDate1;
            this.MMDate2 = mDate2;
            this.MCode = MCode;
            this.InfMessage = infMessage;
        }
    }
}
