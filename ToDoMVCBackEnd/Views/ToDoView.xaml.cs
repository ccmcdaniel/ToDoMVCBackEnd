namespace ToDoMVCBackEnd.Views;

public partial class ToDoView : ContentPage
{
	private Controllers.ToDoController controller;
	public ToDoView()
	{
		InitializeComponent();

		controller = new(collToDoItems);
	}

    private void ButtonEditItem(object sender, EventArgs e)
    {
        Button btn = sender as Button;

        int ID = Convert.ToInt32(btn.CommandParameter);
        controller.TriggerEditItem(ID);

        if (btn.Text == "Edit") btn.Text = "Save";
        else btn.Text = "Edit";
    }

    private void ButtonDeleteItem(object sender, EventArgs e)
    {
        Button btn = sender as Button;

        int ID = Convert.ToInt32(btn.CommandParameter);
        var result = controller.RemoveItem(ID);
        DisplayAlert("Removed", "Item Successfully Removed!", "Ok");
    }

    private void ButtonAddNewItem(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new Views.ToDoViewAddItem(controller));
    }

    private async void ButtonDeleteAllItems(object sender, EventArgs e)
    {
        var result = await DisplayAlert("Clear Tasks?", "Are you sure you want to delete all tasks?",
            "Yes", "No");

        if (result == true)
        {
            controller.ClearAllTasks();
        }
    }
}