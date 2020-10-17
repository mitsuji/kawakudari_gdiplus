using System;
using System.Drawing;
using System.Windows.Forms;
using IchigoJam;
 
public class Kawakudari: Form
{
    private Std15 std15;
    private uint frame;
    private Random rnd;
    private int x;
    private bool running;

    private void OnSetup ()
    {
        std15 = new Std15(512,384,32,24,this);
        frame = 0;
        rnd = new Random();
        x = 15;
        running = true;
    }

    private void OnUpdate ()
    {
        if (!running) return;
        if (frame % 5 == 0) {
            std15.Locate(x,5);
            std15.Putc('0');
            std15.Locate(rnd.Next(0,32),23);
            std15.Putc('*');
            std15.Scroll(Std15.Direction.Up);
            if (std15.Scr(x,5) != '\0') {
                std15.Locate(0,23);
                std15.Putstr("Game Over...");
                std15.Putnum((int)frame);
                running = false;
            }
        }
        frame++;
    }

    private void OnKeyDown (object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Left)  x--;
        if (e.KeyCode == Keys.Right) x++;
    }

    private void OnPaint ()
    {
        std15.DrawScreen();
    }

    static public void Main ()
    {
        Application.Run(new Kawakudari());
    }

    private Timer timer;

    public Kawakudari ()
    {
        Size = new Size(512+20,384+40);

        KeyDown += OnKeyDown;
        timer = new Timer();
        timer.Tick += OnTick;
        timer.Interval = 16;
        OnSetup();
        timer.Start();
    }

    private void OnTick (object sender, EventArgs e)
    {
        OnUpdate();
        OnPaint();
    }

}
