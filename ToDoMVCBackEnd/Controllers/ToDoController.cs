using System.Collections.ObjectModel;

namespace ToDoMVCBackEnd.Controllers
{
    public class ToDoItemConverter : BindableObject
    {
        public Models.ToDoModel ToDoModel { get; set; }
        private bool _editing = false;

        public bool Editing
        {
            get { return _editing; }
            set
            {
                _editing = value;
                NotifyView();
            }
        }

        public ToDoItemConverter(Models.ToDoModel data)
        {
            ToDoModel = data;
        }

        public int ItemID { get { return ToDoModel.Id; } }

        public string ColorRadio
        {
            get
            {
                if (ToDoModel.isCompleted) return "#238932";
                else return "#892332";
            }
        }
        public string ColorBackDrop
        {
            get
            {
                if (ToDoModel.isCompleted) return "#45AB54";
                else return "#AB4554";
            }
        }

        public string AssignedTo
        {
            get { return $"{ToDoModel.issuedTo}"; }
        }

        public string DateAssigned
        {
            get { return $"{ToDoModel.dateAssigned.ToString()}"; }
        }

        public string DateCompleted
        {
            get
            {
                if (ToDoModel.isCompleted)
                    return $"Completed On {ToDoModel.dateCompleted.ToString()}";
                else
                    return "Not Completed";
            }
        }

        public bool IsCompleted
        {
            get
            {
                return ToDoModel.isCompleted;
            }
            set
            {
                ToDoModel.CompleteItem();
                NotifyView();
            }
        }


        public string Detail { get { return ToDoModel.Detail; } }

        //If a setter function is called for any property,
        //this notifies the bound view (in this case, the Collection View,
        //to refresh.
        private void NotifyView()
        {
            OnPropertyChanged(nameof(ColorRadio));
            OnPropertyChanged(nameof(ColorBackDrop));
            OnPropertyChanged(nameof(AssignedTo));
            OnPropertyChanged(nameof(DateAssigned));
            OnPropertyChanged(nameof(DateCompleted));
            OnPropertyChanged(nameof(DateAssigned));
            OnPropertyChanged(nameof(IsCompleted));
            OnPropertyChanged(nameof(Editing));
            OnPropertyChanged(nameof(ItemID));
        }
    }

    public class ToDoController
    {
        public ObservableCollection<ToDoItemConverter> Items { get; set; }

        public bool TriggerEditItem(int ID)
        {
            foreach(var item in Items)
            {
                if(item.ItemID == ID)
                {
                    //Toggle Edit Mode on/off
                    item.Editing = !item.Editing;
                    return true;
                }
            }
            return false;
        }

        public bool RemoveItem(int ID)
        {
            for(int i = 0; i < Items.Count; i++)
            {
                if (Items[i].ItemID == ID)
                {
                    //Delete the item.
                    Items.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void AddNewItem(string detail, string assignedTo)
        {
            var item = new Models.ToDoModel
            {
                Detail = detail,
                issuedTo = assignedTo
            };
            Items.Add(new ToDoItemConverter(item));
        }

        public void ClearAllTasks()
        {
            Items.Clear();
        }

        public ToDoController(CollectionView view)
        {
            Items = new ObservableCollection<ToDoItemConverter>();

            //Create a set of test items
            var item = new Models.ToDoModel
            {
                Detail = "Do the Dishes",
                issuedTo = "Corey"
            };
            Items.Add(new ToDoItemConverter(item));

            item = new Models.ToDoModel
            {
                Detail = "Clean the curtains",
                issuedTo = "Sarah"
            };
            Items.Add(new ToDoItemConverter(item));

            item = new Models.ToDoModel
            {
                Detail = "Take out the Trash",
                issuedTo = "Jake"
            };
            Items.Add(new ToDoItemConverter(item));

            item = new Models.ToDoModel
            {
                Detail = "Mop the Floor",
                issuedTo = "Katey"
            };
            item.CompleteItem();
            Items.Add(new ToDoItemConverter(item));


            item = new Models.ToDoModel
            {
                Detail = "Clean the Bathroom",
                issuedTo = "Seth"
            };
            Items.Add(new ToDoItemConverter(item));

            view.ItemsSource = Items;
        }
    }
}
