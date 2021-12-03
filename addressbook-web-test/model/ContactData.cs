using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string allPhones;
        public string allEmails;
        public string view;
        public ContactData()
        {
        }

        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }
        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }
        public override string ToString()
        {
            return "Firstname = " + FirstName + ", Lastname = " + LastName;
        }
        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (this.LastName != other.LastName)
            {
                return LastName.CompareTo(other.LastName);
            }
            return FirstName.CompareTo(other.FirstName);
        }
        [Column(Name = "firstname")]
        public string FirstName { get; set; }
        [Column(Name = "lastname")]
        public string LastName { get; set; }
        [Column(Name = "middlename")]
        public string MiddleName { get; set; }
        [Column(Name = "nickname")]
        public string Nickname { get; set; }
        [Column(Name = "title")]
        public string Title { get; set; }
        [Column(Name = "company")]
        public string Company { get; set; }
        [Column(Name = "address")]
        public string Address { get; set; }
        [Column(Name = "home")]
        public string Home { get; set; }
        [Column(Name = "mobile")]
        public string Mobile { get; set; }
        [Column(Name = "work")]
        public string Work { get; set; }
        [Column(Name = "fax")]
        public string Fax { get; set; }
        [Column(Name = "email")]
        public string Email { get; set; }
        [Column(Name = "email2")]
        public string Email2 { get; set; }
        [Column(Name = "email3")]
        public string Email3 { get; set; }
        [Column(Name = "homepage")]
        public string Homepage { get; set; }
        [Column(Name = "bday")]
        public string Bday { get; set; }
        [Column(Name = "bmonth")]
        public string Bmonth { get; set; }
        [Column(Name = "byear")]
        public string Byear { get; set; }
        [Column(Name = "aday")]
        public string Aday { get; set; }
        [Column(Name = "amonth")]
        public string Amonth { get; set; }
        [Column(Name = "ayear")]
        public string Ayear { get; set; }
        [Column(Name = "address2")]
        public string Address2 { get; set; }
        [Column(Name = "phone2")]
        public string Phone2 { get; set; }
        [Column(Name = "notes")]
        public string Notes { get; set; }
        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }
        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }
        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") 
                        select c).ToList();
            }
        }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work) + CleanUp(Phone2)).Trim();
                }

            }
            set
            {
                allPhones = value;
            }
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (NewEmail(Email) + NewEmail(Email2) + NewEmail(Email3)).Trim();
                }

            }
            set
            {
                allEmails = value;
            }
        }
        private string NewEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }
        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }
        public string View
        {
            get
            {
                if (view != null)
                {
                    return view;
                }
                else
                {
                    return (NameBlock() + PhoneBlock() + EmailBlock() + DateBlock() + SecondaryBlock()).Trim();
                }
            }
            set
            {
                view = value;
            }
        }
        private string NameBlock()
        {
            string namestr = "";
            if (!String.IsNullOrEmpty(FirstName) || !String.IsNullOrEmpty(MiddleName) || !String.IsNullOrEmpty(LastName))
            {
                string name = "";
                if (!String.IsNullOrEmpty(FirstName))
                    name += FirstName + " ";
                if (!String.IsNullOrEmpty(MiddleName))
                    name += MiddleName + " ";
                if (!String.IsNullOrEmpty(LastName))
                    name += LastName;
                namestr = name.Trim() + "\r\n";
            }
            if (!String.IsNullOrEmpty(Nickname))
                namestr += Nickname + "\r\n";
            if (!String.IsNullOrEmpty(Title))
                namestr += Title + "\r\n";
            if (!String.IsNullOrEmpty(Company))
                namestr += Company + "\r\n";
            if (!String.IsNullOrEmpty(Address))
                namestr += Address + "\r\n";
            if (namestr != "")
                return namestr + "\r\n";
            return namestr;
        }
        private string PhoneBlock()
        {
            string phonestr = "";
            if (!String.IsNullOrEmpty(Home))
                phonestr += "H: " + Home + "\r\n";
            if (!String.IsNullOrEmpty(Mobile))
                phonestr += "M: " + Mobile + "\r\n";
            if (!String.IsNullOrEmpty(Work))
                phonestr += "W: " + Work + "\r\n";
            if (!String.IsNullOrEmpty(Fax))
                phonestr += "F: " + Fax + "\r\n";
            if (phonestr != "")
                return phonestr + "\r\n";
            return phonestr;
        }
        private string EmailBlock()
        {
            string emailstr = "";
            if (!String.IsNullOrEmpty(Email))
                emailstr += Email + "\r\n";
            if (!String.IsNullOrEmpty(Email2))
                emailstr += Email2 + "\r\n";
            if (!String.IsNullOrEmpty(Email3))
                emailstr += Email3 + "\r\n";
            if (!String.IsNullOrEmpty(Homepage))
                emailstr += "Homepage:\r\n" + Homepage + "\r\n";
            if (emailstr != "")
                return emailstr + "\r\n";
            return emailstr;
        }
        private string DateBlock()
        {
            string datestr = "";
            if ((!String.IsNullOrEmpty(Bday) && Bday != "-") || (!String.IsNullOrEmpty(Bmonth) && Bmonth != "-") || !String.IsNullOrEmpty(Byear))
            {
                string dateData = "";
                dateData += "Birthday ";
                if (!String.IsNullOrEmpty(Bday) && Bday != "-")
                    dateData += Bday + ". ";
                if (!String.IsNullOrEmpty(Bmonth) && Bmonth != "-")
                    dateData += Bmonth + " ";
                if (!String.IsNullOrEmpty(Byear))
                {
                    dateData += Byear + " (" + CalculateYears(Bday, Bmonth, Byear) + ")";
                }
                datestr += dateData.Trim() + "\r\n";
            }
            if ((!String.IsNullOrEmpty(Aday) && Aday != "-") || (!String.IsNullOrEmpty(Amonth) && Amonth != "-") || !String.IsNullOrEmpty(Ayear))
            {
                string dateData = "";
                dateData += "Anniversary ";
                if (!String.IsNullOrEmpty(Aday) && Aday != "-")
                    dateData += Aday + ". ";
                if (!String.IsNullOrEmpty(Amonth) && Amonth != "-")
                    dateData += Amonth + " ";
                if (!String.IsNullOrEmpty(Ayear))
                {
                    dateData += Ayear + " (" + CalculateYears(Aday, Amonth, Ayear) + ")";
                }
                datestr += dateData.Trim() + "\r\n";
            }
            if (datestr != "")
                return datestr + "\r\n";
            return datestr;
        }
        private string SecondaryBlock()
        {
            string secondarystr = "";
            if (!String.IsNullOrEmpty(Address2))
                secondarystr += Address2 + "\r\n\r\n";
            if (!String.IsNullOrEmpty(Phone2))
                secondarystr += "P: " + Phone2 + "\r\n\r\n";
            if (!String.IsNullOrEmpty(Notes))
                secondarystr += Notes;
            return secondarystr.Trim();
        }
        private int CalculateYears(string day, string month, string year)
        {
            if (String.IsNullOrEmpty(day) || day == "-")
                day = "1";
            if (String.IsNullOrEmpty(month) || month == "-")
                month = "January";
            DateTime dt = DateTime.ParseExact(day + " " + month + " " + year, "d MMMM yyyy", CultureInfo.InvariantCulture);
            int YearsPassed = DateTime.Now.Year - dt.Year;
            if (DateTime.Now.Month < dt.Month || (DateTime.Now.Month == dt.Month && DateTime.Now.Day < dt.Day))
            {
                YearsPassed--;
            }
            return YearsPassed;
        }
    }
}


