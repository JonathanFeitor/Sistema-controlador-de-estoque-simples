using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class User
    {
        private string _ID;
        private string _Password;
        private string _Name;
        private string _Position;
        private string _Phone;
        private DateTime _Date;
        private int _InfMessage;

        [Display(Name = "ID")]
        [Required(ErrorMessage = "This field is required!")]
        public string ID { get => _ID; set => _ID = value; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "This field is required!")]
        public string Password { get => _Password; set => _Password = value; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "This field is required!")]
        public string Name { get => _Name; set => _Name = value; }
        [Display(Name = "Position")]
        public string Position { get => _Position; set => _Position = value; }
        [Display(Name = "Phone")]
        public string Phone { get => _Phone; set => _Phone = value; }
        [Display(Name = "Date")]
        public DateTime Date { get => _Date; set => _Date = value; }
        public int InfMessage { get => _InfMessage; set => _InfMessage = value; }

        public User()
        {

        }

        public User(string id)
        {
            this.ID = id;
        }

        public User(string id, string password, string name, string position, string phone, DateTime date, int infMessage)
        {
            this.ID = id;
            this.Password = password;
            this.Name = name;
            this.Position = position;
            this.Phone = phone;
            this.Date = date;
            this.InfMessage = infMessage;
        }
    }
}
