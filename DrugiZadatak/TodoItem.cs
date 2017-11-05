using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugiZadatak
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        
        public bool IsCompleted
        {
            get
            {
                return DateCompleted.HasValue;
            }
        }
        public DateTime? DateCompleted { get; set; }
        public DateTime DateCreated { get; set; }

        public TodoItem(string text)
        {
           
            Id = Guid.NewGuid();
            
                DateCreated = DateTime.UtcNow;
            Text = text;
        }

        public bool MarkAsCompleted()
        {
            if (!IsCompleted)
            {
                DateCompleted = DateTime.Now;
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return Id.Equals(((TodoItem) obj).Id);
        }


    }

}
