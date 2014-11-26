using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCalendar
{
    public partial class Visualisation : Form
    {

        private Label field;

        public Visualisation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label.Visible = false;
            button1.Visible = false;
            date.Visible = false; 
            BackColor = Color.White;
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
                        ClientSize = new Size(ClientSize.Width, ClientSize.Height-50);
                        break;
                    } 
                    if (generator.GetDate().Day.ToString().Equals(grid[i, j]) && i!=0)
                    {
                        AddNewFieldOfGrid(i, j, grid[i, j], Color.Violet);
                        continue;
                    }
                    AddNewFieldOfGrid(i, j, grid[i, j], Color.White);
                }
            }
            var bmp = new Bitmap(Size.Width, Size.Height);
            DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            bmp.Save("haha.bmp");
        }

        private void AddMonthAndYearField(DateTime date)
        {
            var monthes = new String[] { "January", "February", "March", "April", "May", "June", "July", "August","September","October","November","December" };    
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
            Controls.AddRange(new Control[] { field });
            var haha = new String[] {"#", "MON", "TUE", "WED", "THU", "FRI", "SAT", "SUN"};           
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
                    Text = haha[i]
                };
                Controls.AddRange(new Control[] {field});
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
            field = new Label
            {
                BackColor = backColor,
                Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204))),
                ForeColor = foreColor,
                Size = new Size(ClientSize.Width / 8, ClientSize.Height / 8),
                Location = new Point(j * ClientSize.Width / 8, ClientSize.Height / 4 + i * ClientSize.Height / 8),
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle,
                Text = text
            };
            Controls.AddRange(new Control[] {field});
        }
    }
}
