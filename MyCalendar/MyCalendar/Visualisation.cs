using System;
using System.Drawing;
using System.Windows.Forms;
using MyCalendar.Properties;

namespace MyCalendar
{
    public partial class Visualisation : Form
    {

        private Label field;
        private Button comeBack;

        public Visualisation()
        {
            InitializeComponent();
        }      

        private void genCalendar_Click(object sender, EventArgs e)
        {
            ClientSize = new Size(600,600);
            DrawCalendarPage();
        }

        private void DrawCalendarPage()
        {           
            AddComeBackButton();
            StartMenuColorAndVisible(false, Color.White);
            var generator = new CalendarPageGenerator(date.Text);
            DrawSeasonImage(generator.GetDate());
            DrawDaysOfWeekFields();
            DrawMonthAndYearFields(generator.GetDate());
            DrawCalendarGrid(generator);
            DrawPictureOfCalendarPage();
        }

        private void AddComeBackButton()
        {
            comeBack = new Button
            {
                Text = "Back",
                Location = new Point(0, 0),
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 204),
                Size = new Size(50, 25)
            };
            Controls.Add(comeBack);
            comeBack.Click += comeBack_Click;
        }

        private void comeBack_Click(object sender, EventArgs e)
        {
            BackgroundImage = null;
            comeBack.Visible = false;
            Controls.Clear();
            Controls.AddRange(new Control[] { genCalendar, label, date });
            Size = new Size(400, 400);
            StartMenuColorAndVisible(true, Color.RoyalBlue);
        }

        private void StartMenuColorAndVisible(bool isVisible, Color backColor)
        {
            label.Visible = isVisible;
            genCalendar.Visible = isVisible;
            date.Visible = isVisible;
            BackColor = backColor;
        }        

        private void DrawSeasonImage(DateTime date)
        {
            if (date.Month < 3 || date.Month == 12)
                BackgroundImage = Resources.hg_winter;
            else if (date.Month >= 3 && date.Month < 6)
                BackgroundImage = Resources.Spring;
            else if (date.Month >= 6 && date.Month < 9)
                BackgroundImage = Resources.Summer;
            else
                BackgroundImage = Resources.Autumn;
            BackgroundImageLayout = ImageLayout.Stretch;
        }       

        private void DrawPictureOfCalendarPage()
        {
            var bmp = new Bitmap(Size.Width, Size.Height);
            DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            bmp.Save("CalendarPage.bmp");
        }       

        private void DrawCalendarGrid(CalendarPageGenerator generator)
        {
            var grid = generator.GenerateDaysGrid();
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][0] == null)
                    {
                        ClientSize = new Size(ClientSize.Width, ClientSize.Height - ClientSize.Height/8);
                        break;
                    }
                    if (generator.GetDate().Day.ToString().Equals(grid[i][j]) && j != 0)
                    {
                        DrawNewFieldOfCalendarGrid(i, j, grid[i][j], Color.Purple);
                        continue;
                    }
                    DrawNewFieldOfCalendarGrid(i, j, grid[i][j], Color.Transparent);
                }
            }
        }

        private void DrawMonthAndYearFields(DateTime date)
        {
            var monthes = new[] {"January", "February", "March", "April", "May", "June", "July", "August","September","October","November","December" }; 
            field = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204))),
                ForeColor = Color.Black,
                Size = new Size(ClientSize.Width, ClientSize.Height / 8 + ClientSize.Height / 16),
                Location = new Point(0, 0),
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.Fixed3D,
                Text = string.Format("{0} {1}",monthes[date.Month-1],date.Year)
            };
            Controls.Add(field);           
        }

        private void DrawDaysOfWeekFields()
        {
            var daysOfWeek = new[] {"#", "MON", "TUE", "WED", "THU", "FRI", "SAT", "SUN"};
            for (var i = 0; i < 8; i++)
            {
                field = new Label
                {
                    BackColor = Color.Transparent,
                    Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, ((byte) (204))),
                    ForeColor = Color.Black,
                    Size = new Size(ClientSize.Width/8, ClientSize.Height/16),
                    Location = new Point(i*ClientSize.Width/8, ClientSize.Height/8 + ClientSize.Height/16),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.Fixed3D,
                    Text = daysOfWeek[i]
                };
                Controls.Add(field);
            }
        }

        private void DrawNewFieldOfCalendarGrid(int i, int j,string text,Color backColor)
        {
            field = new Label
            {
                BackColor = backColor,
                Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204))),
                ForeColor = GetDayTextColor(j),
                Size = new Size(ClientSize.Width / 8, ClientSize.Height / 8),
                Location = new Point(j * ClientSize.Width / 8, ClientSize.Height / 4 + i * ClientSize.Height / 8),
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.Fixed3D,
                Text = text
            };
            Controls.Add(field);
        }

        private static Color GetDayTextColor(int j)
        {
            Color foreColor;
            if (j == 0)
                foreColor = Color.Navy;
            else if (j == 7)
                foreColor = Color.Red;
            else
                foreColor = Color.Black;
            return foreColor;
        }
    }
}
