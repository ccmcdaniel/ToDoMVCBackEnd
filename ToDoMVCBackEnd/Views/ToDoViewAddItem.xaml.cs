namespace ToDoMVCBackEnd.Views;

public partial class ToDoViewAddItem : ContentPage
{
    public Controllers.ToDoController controller;
	public ToDoViewAddItem(Controllers.ToDoController controller)
	{
		InitializeComponent();
        this.controller = controller;
        lblErrorMessage.IsVisible = false;
	}

    private void ButtonCreateTask(object sender, EventArgs e)
    {
        if(txtNewAssignedto.Text == null || txtNewAssignedto.Text == "" ||
            txtNewDetail.Text == null || txtNewDetail.Text == "")
        {
            lblErrorMessage.Text = "Error: All fields must contain information";
            lblErrorMessage.IsVisible = true;
            return;
        }

        controller.AddNewItem(txtNewDetail.Text, txtNewAssignedto.Text);
        Navigation.PopModalAsync();
    }

    private void ButtonCancelCreateTask(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}