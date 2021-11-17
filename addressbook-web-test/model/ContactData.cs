using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string allPhones;
        public string allEmails;
        public string view;

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
            return $"firstname = {FirstName} and LastName = {LastName}";
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string Bday { get; set; }
        public string Bmonth { get; set; }
        public string Byear { get; set; }
        public string Aday { get; set; }
        public string Amonth { get; set; }
        public string Ayear { get; set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; }
        public string Notes { get; set; }
        public string Id { get; set; }
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


