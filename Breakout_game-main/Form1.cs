namespace Breakout
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random r = new Random();

        int paddleSpeed =50;

        private void Form1_Load(object sender, EventArgs e)
        {
            ball.Location = new Point(r.Next(0, Math.Max(1, panel2.Width - ball.Width)),0);
            MessageBox.Show("Hazır olun! Oyun başlayır...", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            timer1.Start();
        }

        int speedY =15, speedX =10, score =0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ball.Bottom >= panel2.Height)
            {
                timer1.Stop();
                MessageBox.Show($"Oyun bitdi! Yığdığınız xal: {score}", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult dr = MessageBox.Show("Yenidən oynamaq istəyirsiniz?", "Sual", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    ball.Location = new Point(r.Next(0, Math.Max(1, panel2.Width - ball.Width)),0);
                    speedY =10;
                    score =0;
                    timer1.Start();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                ball.Top += speedY;
                ball.Left += speedX;
                if (ball.Bottom >= panel1.Top && ball.Left <= panel1.Right && ball.Right >= panel1.Left)
                {
                    ball.Top = panel1.Top - ball.Height;
                    speedY = -speedY;
                    speedY += (speedY >0) ?1 : -1;
                    score +=1;
                }
                if (ball.Top + speedY <=0)
                {
                    ball.Top =0;
                    speedY = -speedY;
                }
                if (ball.Left <=0 || ball.Right >= panel2.Width)
                {
                    speedX = -speedX;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (panel1.Location.X - paddleSpeed <0)
                {
                    panel1.Location = new Point(0, panel1.Location.Y);
                }
                else
                {
                    panel1.Left -= paddleSpeed;
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                int maxX = panel2.Width - panel1.Width;
                if (panel1.Location.X + paddleSpeed > maxX)
                {
                    panel1.Location = new Point(maxX, panel1.Location.Y);
                }
                else
                {
                    panel1.Left += paddleSpeed;
                }
            }
        }

    }
}
