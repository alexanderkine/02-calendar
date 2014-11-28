using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCalendar
{
    public partial class Visualisation : Form
    {

        private Label field;
        private Button comeBack;
        public Visualisation()
        {
            Size = new Size(400,400);
            InitializeComponent();
        }

        private void comeBack_Click(object sender, EventArgs e)
        {
            comeBack.Visible = false;
            Controls.Clear();
            Controls.AddRange(new Control[] {genCalendar,label,date});
            Size = new Size(400, 400);
            StartMenuColorAndVisible(true, Color.RoyalBlue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comeBack = new Button()
            {
                Text = "Back",
                Location = new Point(0, 0),
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204))),
                Size = new Size(50, 25)
            };
            Controls.Add(comeBack);
            comeBack.Click += comeBack_Click;
            StartMenuColorAndVisible(false,Color.White);
            Console.WriteLine(Size.ToString());
            Console.WriteLine(ClientSize.ToString());
            var dateTime = date.Text;
            var generator = new CalendarPageGenerator(dateTime);
            var grid = generator.GenerateDaysGrid();
            AddMonthAndYearField(generator.GetDate());
            for (var i = 0; i < grid.GetLength(0); i++)
            {
                for (var j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, 0] == null)
                    {
                        ClientSize = new Size(ClientSize.Width, ClientSize.Height-ClientSize.Height/8);
                        break;
                    } 
                    if (generator.GetDate().Day.ToString().Equals(grid[i, j]) && j != 0)
                    {
                        AddNewFieldOfGrid(i, j, grid[i, j], Color.Purple);
                        continue;
                    }
                    AddNewFieldOfGrid(i, j, grid[i, j], Color.White);
                }
            }
            var bmp = new Bitmap(Size.Width, Size.Height);
            DrawToBitmap(bmp, new Rectangle(8,8, bmp.Width, bmp.Height));
            bmp.Save("haha.bmp");          
        }

        private void StartMenuColorAndVisible(bool isVisible,Color backColor)
        {
            label.Visible = isVisible;
            genCalendar.Visible = isVisible;
            date.Visible = isVisible;
            BackColor = backColor;
        }

        private void AddMonthAndYearField(DateTime date)
        {
            var monthes = new[] { "January", "February", "March", "April", "May", "June", "July", "August","September","October","November","December" };    
            field = new Label
            {
                BackColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204))),
                ForeColor = Color.Black,
                Size = new Size(ClientSize.Width, ClientSize.Height / 8 + ClientSize.Height / 16),
                Location = new Point(0, 0),
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle,
                Text = string.Format("{0},{1}",monthes[date.Month-1],date.Year)
            };
            Controls.Add(field);
            var daysOfWeek = new[] {"#", "MON", "TUE", "WED", "THU", "FRI", "SAT", "SUN"};           
            for (int i = 0; i < 8; i++)
            {
                field = new Label
                {
                    BackColor = Color.White,
                    Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte) (204))),
                    ForeColor = Color.Black,
                    Size = new Size(ClientSize.Width / 8, ClientSize.Height / 16),
                    Location = new Point(i * ClientSize.Width / 8, ClientSize.Height / 8 + ClientSize.Height / 16),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle,
                    Text = daysOfWeek[i]
                };
                Controls.Add(field);
            }
        }

        private void AddNewFieldOfGrid(int i, int j,string text,Color backColor)
        {
            Color foreColor;
            if (j == 0)
                foreColor = Color.Navy;
            else if (j == 7)
                foreColor = Color.Red;
            else
                foreColor = Color.Black; 
            AddField(i, j, text, backColor, foreColor);
        }

        private void AddField(int i, int j, string text, Color backColor, Color foreColor)
        {
            field = new Label
            {
                BackColor = backColor,
                Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte) (204))),
                ForeColor = foreColor,
                Size = new Size(ClientSize.Width/8, ClientSize.Height/8),
                Location = new Point(j*ClientSize.Width/8, ClientSize.Height/4 + i*ClientSize.Height/8),
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle,
                Text = text
            };
            Controls.Add(field);
        }
    }
}
