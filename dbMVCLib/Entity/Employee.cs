using System;
using System.ComponentModel.DataAnnotations;

namespace dbMVC.Lib
{
    public partial class Employee 
    {
        
        private int idField;
        
        private string fullNameField;
        
        private string phoneField;
        
        private string emailField;
        
        private string typeField;

        private DateTime createdDateField;  

        public Employee()
        {
            this.phoneField = "xxx-xxx-xxxx";
            this.typeField = "Persion";
        }
        [Key]
        [Required]
        public virtual int ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        
        [Required]
        public virtual string FullName
        {
            get
            {
                return this.fullNameField;
            }
            set
            {
                this.fullNameField = value;
            }
        }
        
        public virtual string Phone
        {
            get
            {
                return this.phoneField;
            }
            set
            {
                this.phoneField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public virtual string Email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public virtual string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
        
        public virtual System.DateTime CreatedDate
        {
            get
            {
                return this.createdDateField;
            }
            set
            {
                this.createdDateField = value;
            }
        }
    }
}
