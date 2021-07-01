using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Inventory
    {
        private string _EInventory;
        private string _EType;
        private string _EModel;
        private string _ESNumber;
        private string _ESEquipament;
        private string _EIP;
        private string _ELocation;
        private string _EDescription;
        private string _EIdOperator;
        private int _InfMessage;

        [Display(Name = "I. Number")]
        [Required(ErrorMessage = "This field is required!")]
        public string EInventory { get => _EInventory; set => _EInventory = value; }
        [Display(Name = "Type")]
        [Required(ErrorMessage = "This field is required!")]
        public string EType { get => _EType; set => _EType = value; }
        [Display(Name = "Model")]
        [Required(ErrorMessage = "This field is required!")]
        public string EModel { get => _EModel; set => _EModel = value; }
        [Display(Name = "Serial Number")]
        [Required(ErrorMessage = "This field is required!")]
        public string ESNumber { get => _ESNumber; set => _ESNumber = value; }
        [Display(Name = "In user YES/NO")]
        [Required(ErrorMessage = "This field is required!")]
        public string ESEquipament { get => _ESEquipament; set => _ESEquipament = value; }
        [Display(Name = "IP")]
        public string EIP { get => _EIP; set => _EIP = value; }
        [Display(Name = "Location")]
        public string ELocation { get => _ELocation; set => _ELocation = value; }
        [Display(Name = "Description")]
        public string EDescription { get => _EDescription; set => _EDescription = value; }
        [Display(Name = "User ID")]
        public string EIdOperator { get => _EIdOperator; set => _EIdOperator = value; }
        public int InfMessage { get => _InfMessage; set => _InfMessage = value; }

        public Inventory()
        {

        }

        public Inventory(string inventory)
        {
            this.EInventory = inventory;
        }

        public Inventory(string eInventory, string eType, string eModel, string eSNumber, string eSEquipament, string eIP, string eLocation,
            string eDescription, string eIdOperator, int infMessage)
        {
            this.EInventory = eInventory;
            this.EType = eType;
            this.EModel = eModel;
            this.ESNumber = eSNumber;
            this.ESEquipament = eSEquipament;
            this.EIP = eIP;
            this.ELocation = eLocation;
            this.EDescription = eDescription;
            this.EIdOperator = eIdOperator;
            this.InfMessage = infMessage;
        }
    }
}
