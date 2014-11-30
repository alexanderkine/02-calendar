using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using MyCalendar.Properties;

namespace MyCalendar
{
    public partial class Visualisation : Form
    {

        private Label field, zodiacImage, zodiacName, animalImage;
        private Button comeBack;

        public Visualisation()
        {
            InitializeComponent();
        }

        private void genCalendar_Click(object sender, EventArgs e)
        {
            DrawCalendarPage();
        }

        private void DrawCalendarPage()
        {
            DateTime currentDate;
            if (!DateTime.TryParse(date.Text, out currentDate))
            {
                date.Text = "Incorrect date";
                return;
            }
            ClientSize = new Size(600, 600);          
            AddComeBackButton();
            StartMenuVisible(false);           
            var generator = new CalendarPageGenerator(date.Text);
            DrawSeasonImage(generator.GetDate());
            DrawDaysOfWeekFields();
            DrawMonthAndYearFields(generator.GetDate());
            DrawCalendarGrid(generator);
            DrawHoroscopeField(GetZodiacSign(generator.GetDate()));
            DrawPictureAnimalOfYear(generator.GetDate());     
            DrawPictureOfCalendarPage();
            zodiacImage.BringToFront();
            zodiacName.BringToFront();
            animalImage.BringToFront();
        }       

        private void AddComeBackButton()
        {           
            comeBack = new Button
            {
                Text = "Back",
                Location = new Point(ClientSize.Width/2-25, 0),
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 204),
                Size = new Size(50, 25),
                BackColor = Color.White
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
            StartMenuVisible(true);
        }

        private void StartMenuVisible(bool isVisible)
        {
            label.Visible = isVisible;
            genCalendar.Visible = isVisible;
            date.Visible = isVisible;
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
            var bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
            foreach (Control con in Controls)
                con.DrawToBitmap(bmp, new Rectangle(con.Location.X, con.Location.Y, con.Width, con.Height));
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
                    if (!generator.GetDate().Day.ToString().Equals(grid[i][j]) || j == 0)
                        DrawNewFieldOfCalendarGrid(i, j, grid[i][j], Color.Transparent);
                    else
                        DrawNewFieldOfCalendarGrid(i, j, grid[i][j], Color.Purple);
                }
            }
        }

        private void DrawNewFieldOfCalendarGrid(int i, int j, string text, Color backColor)
        {
            field = new Label
            {
                BackColor = backColor,
                Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 204),
                ForeColor = GetDayTextColor(j),
                Size = new Size(ClientSize.Width / 8, ClientSize.Height / 8),
                Location = new Point(j * ClientSize.Width / 8, ClientSize.Height / 4 + i * ClientSize.Height / 8),
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle,
                Text = text
            };
            Controls.Add(field);
        }

        private void DrawMonthAndYearFields(DateTime date)
        {
            var monthes = new[] {"January", "February", "March", "April", "May", "June", "July", "August","September","October","November","December" }; 
            field = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Bold, GraphicsUnit.Point, 204),
                ForeColor = Color.Black,
                Size = new Size(ClientSize.Width, ClientSize.Height / 8 + ClientSize.Height / 16),
                Location = new Point(0, 0),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = string.Format("{0} {1}",monthes[date.Month-1],date.Year),
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
                    Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 204),
                    ForeColor = Color.Black,
                    Size = new Size(ClientSize.Width/8, ClientSize.Height/16),
                    Location = new Point(i*ClientSize.Width/8, ClientSize.Height/8 + ClientSize.Height/16),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle,
                    Text = daysOfWeek[i]
                };
                Controls.Add(field);
            }
        }       

        private void DrawPictureAnimalOfYear(DateTime date)
        {
            switch (date.Year % 12)
            {
                case 0: DrawAnimalImage(Resources.Monkey); break;
                case 1: DrawAnimalImage(Resources.Rooster); break;
                case 2: DrawAnimalImage(Resources.Dog); break;
                case 3: DrawAnimalImage(Resources.Boar); break;
                case 4: DrawAnimalImage(Resources.Rat); break;
                case 5: DrawAnimalImage(Resources.Ox); break;
                case 6: DrawAnimalImage(Resources.Tiger); break;
                case 7: DrawAnimalImage(Resources.Rabbit); break;
                case 8: DrawAnimalImage(Resources.Dragon); break;
                case 9: DrawAnimalImage(Resources.Snake); break;
                case 10: DrawAnimalImage(Resources.Horse); break;
                case 11: DrawAnimalImage(Resources.Ram); break;
            }
        }

        private void DrawAnimalImage(Bitmap animal)
        {
            animalImage = new Label
            {
                BackColor = Color.Transparent,
                Location = new Point(Size.Width - 115, 5),
                Size = new Size(90, 90),
                BackgroundImage = animal,
                BackgroundImageLayout = ImageLayout.Stretch
            };
            Controls.Add(animalImage);
            animalImage.SendToBack();
        }

        private static ZodiacSignInfo GetZodiacSign(DateTime date)
        {
            var zodiacZign = ZodiacSignInfo.ZodiacSigns.First(x => (date.Day >= DateTime.Parse(x[1]).Day &&
                                                          date.Month == DateTime.Parse(x[1]).Month) ||
                                                         (date.Day <= DateTime.Parse(x[2]).Day &&
                                                          date.Month == DateTime.Parse(x[2]).Month));
            return new ZodiacSignInfo((Image)Resources.ResourceManager.GetObject(zodiacZign[0]), zodiacZign[0], zodiacZign[1], zodiacZign[2]);
        }

        private void DrawHoroscopeField(ZodiacSignInfo zodiacSign)
        {
            zodiacImage = new Label
            {
                BackColor = Color.Transparent,
                Location = new Point(15, 5),
                Size = new Size(70, 60),
                BackgroundImage = zodiacSign.Image,
                BackgroundImageLayout = ImageLayout.Stretch
            };
            zodiacName = new Label
            {
                Text = string.Format("{0}\n{1} - {2}", zodiacSign.Name, zodiacSign.BeginDate, zodiacSign.EndDate),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 204),
                BackColor = Color.Transparent,
                Location = new Point(0, zodiacImage.Size.Height + Size.Height / 120 + zodiacImage.Location.Y),
                Size = new Size(Size.Width / 6, 30),
            };
            Controls.AddRange(new Control[] { zodiacImage, zodiacName });
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
