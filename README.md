# Mouse-Mover

Here are the steps to create a C# program to move the mouse cursor automatically in Visual Studio:

1. Open Visual Studio and create a new Windows Forms project.
2. In the Solution Explorer, right-click the project name and select "Add > Windows Form".
3. Rename the default form to "Form1" (or any other name of your choice).
4. In the Toolbox, find the "Timer" control and add it to the form.
5. Double-click the form to open the code-behind file and add the following using statements at the top:


6. Add the following code to the Form1 class:

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        Cursor.Position = new Point(Cursor.Position.X + 10, Cursor.Position.Y + 10);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        Timer timer = new Timer();
        timer.Interval = 60000; // 60 seconds
        timer.Tick += new EventHandler(timer1_Tick);
        timer.Start();
    }
}

7. Save and run the program. The mouse cursor should move automatically after each minute.

Note: The code moves the mouse cursor by 10 pixels to the right and down. You can adjust the x and y values to move the cursor in different directions.

To change the direction of the mouse cursor when it reaches the screen boundaries, you can add some conditional statements to check its current position and change the direction of movement accordingly. Here's an example:

private void timer1_Tick(object sender, EventArgs e)
{
    int x = Cursor.Position.X;
    int y = Cursor.Position.Y;
    int moveX = 10;
    int moveY = 10;
    Rectangle screen = Screen.PrimaryScreen.Bounds;

    if (x + moveX >= screen.Right || x + moveX <= screen.Left)
    {
        moveX = -moveX;
    }

    if (y + moveY >= screen.Bottom || y + moveY <= screen.Top)
    {
        moveY = -moveY;
    }

    Cursor.Position = new Point(x + moveX, y + moveY);
}

In this example, screen is a Rectangle object that represents the bounds of the primary screen. The if statements check whether the new position of the mouse cursor would be outside the screen bounds, and if so, change the direction of movement by negating the value of moveX and/or moveY. The mouse cursor will then move in the opposite direction until it reaches the opposite edge of the screen.
