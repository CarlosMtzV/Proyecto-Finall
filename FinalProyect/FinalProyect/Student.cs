using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProyect
{
    public class Student
    {

        
        // Read-only property: RegistrationNumber (once assigned, should not change)
        public string registrationNumber;
        public string RegistrationNumber
        {
            get { return registrationNumber; }
        }

        // Read-write property: Name (can be read and modified)
        public string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        // Read-write property: LastName (can be read and modified)
        public string lastname;
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        // Read-write property: Phone (can be read and modified)
        public string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        // Read-only property: Major (once assigned, should not change)
        public string major;
        public string Major
        {
            get { return major; }
        }

        //property: Email (can be set but not read, for example)
        public string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        // Constructor to initialize the properties
        public Student(string registrationNumber, string name, string lastname, string phone, string major, string email)
        {
            this.registrationNumber = registrationNumber;
            this.name = name;
            this.lastname = lastname;
            this.phone = phone;
            this.major = major;
            this.email = email;
        }
        // Propiedad de solo lectura que es la contraseña del correo
        public string emailPassword;
        public string EmailPassword
        {
             set { emailPassword = value; }
        }

        // Constructor sin parámetros con inicialización de propiedades
        public Student()
        {
            // Lógica de inicialización de otras propiedades...

            // Generar la contraseña de email (puedes implementar tu lógica de generación)
            EmailPassword = GenerateEmailPassword();
        }

        private string GenerateEmailPassword()
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int passwordLength = 8; // Longitud de la contraseña
            char[] password = new char[passwordLength];
            Random rnd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                password[i] = validChars[rnd.Next(validChars.Length)];
            }

            return new string(password);
        }
    }
}
