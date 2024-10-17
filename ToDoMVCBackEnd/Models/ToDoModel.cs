using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMVCBackEnd.Models
{
    public class ToDoModel
    {
        private static int _id_counter = 0;
        private int _id;
        public int Id { get { return _id; } }
        public string Detail { get; set; } = "";
        public bool isCompleted { get; set; }
        public string issuedTo { get; set; } = "";
        public DateTime dateAssigned { get; set; }
        public DateTime dateCompleted { get; set; }

        public ToDoModel()
        {
            _id = _id_counter++;
            dateAssigned = DateTime.Now;
            isCompleted = false;
        }

        public void CompleteItem()
        {
            isCompleted = true;
            dateCompleted = DateTime.Now;
        }
    }
}
