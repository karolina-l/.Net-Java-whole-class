import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.util.Random;

public class Gameplay extends JPanel implements KeyListener, ActionListener {

    //snake
    private final int[] snakexlength = new int[750];
    private final int[] snakeylength = new int[750];

    private int totallength = 3;
    private int moves = 0;

    private boolean left = false;
    private boolean right = false;
    private boolean up = false;
    private boolean down = false;

    private ImageIcon rightmouth;
    private ImageIcon leftmouth;
    private ImageIcon upmouth;
    private ImageIcon downmouth;
    private ImageIcon snakeimage;

    //enemy
    private final int [] enemyxpos = {25,50,75,100,125,150,175,200,225,250,275,300,325,350,375,
            400,425,450,475,500,525,550,575,600,625,650,675,700,725,750,775,800,825,850};
    private final int [] enemyypos = {75,100,125,150,175,200,225,250,275,300,325,350,375,400,425
            ,450,475,500,525,550,575,600,625};
    private ImageIcon enemyimage;

    private final Random random = new Random();
    private int xpos = random.nextInt(34);
    private int ypos = random.nextInt(23);

    //timer
    private final Timer timer;

    private int score = 0;

    private ImageIcon titleImage;
    public Gameplay()
    {
        addKeyListener(this);
        setFocusable(true);
        setFocusTraversalKeysEnabled(false);
        int delay = 100;
        timer = new Timer(delay, this);
        timer.start();
    }
    public void paint(Graphics g)
    {
        //check if its the start of game
        if(moves == 0)
        {
            snakexlength[2] = 50;
            snakexlength[1] = 75;
            snakexlength[0] = 100;

            snakeylength[2] = 100;
            snakeylength[1] = 100;
            snakeylength[0] = 100;
        }

        // draw title image border
        g.setColor(Color.white);
        g.drawRect(24, 10,851, 55);

        //draw title image
        titleImage = new ImageIcon("src/snaketitle.png");
        titleImage.paintIcon(this, g, 25, 11);

        //draw border for gameplay
        g.setColor(Color.WHITE);
        g.drawRect(24,74,851,577);

        //draw background for gameplay
        g.setColor(Color.BLACK);
        g.fillRect(25,75,850,575);

        //draw score
        g.setColor(Color.BLACK);
        g.setFont(new Font("arial", Font.PLAIN, 14));
        g.drawString("Scores: "+score, 780, 30);

        //draw lenght of snake
        g.setColor(Color.BLACK);
        g.setFont(new Font("arial", Font.PLAIN, 14));
        g.drawString("Length: "+totallength, 780, 50);

        rightmouth = new ImageIcon("src/rightmouth.png");
        rightmouth.paintIcon(this, g, snakexlength[0], snakeylength[0]);

        for (int a = 0; a < totallength; a++)
        {
            if(a == 0 && right)
            {
                rightmouth = new ImageIcon("src/rightmouth.png");
                rightmouth.paintIcon(this, g, snakexlength[a], snakeylength[a]);
            }
            if(a == 0 && left)
            {
                leftmouth = new ImageIcon("src/leftmouth.png");
                leftmouth.paintIcon(this, g, snakexlength[a], snakeylength[a]);
            }
            if(a == 0 && up)
            {
                upmouth = new ImageIcon("src/upmouth.png");
                upmouth.paintIcon(this, g, snakexlength[a], snakeylength[a]);
            }
            if(a == 0 && down)
            {
                downmouth = new ImageIcon("src/downmouth.png");
                downmouth.paintIcon(this, g, snakexlength[a], snakeylength[a]);
            }
            if(a != 0)
            {
                snakeimage = new ImageIcon("src/snakeimage.png");
                snakeimage.paintIcon(this, g, snakexlength[a], snakeylength[a]);
            }
        }

        //enemy
        enemyimage = new ImageIcon("src/enemy.png");

        if((enemyxpos[xpos] == snakexlength[0]) && (enemyypos[ypos] == snakeylength[0]))
        {
           score++;
           totallength++;
           xpos = random.nextInt(34);
           ypos = random.nextInt(23);
        }

        enemyimage.paintIcon(this, g, enemyxpos[xpos], enemyypos[ypos]);

        for(int i = 1; i < totallength; i++)
        {
            if(snakexlength[i] == snakexlength[0] && snakeylength[i] == snakeylength[0])
            {
                right = false;
                left = false;
                up = false;
                down = false;

                g.setColor(Color.WHITE);
                g.setFont(new Font("arial", Font.BOLD, 50));
                g.drawString("Game Over", 300, 300);

                g.setFont(new Font("arial", Font.BOLD, 20));
                g.drawString("Space to RESTART", 350, 340);
            }
        }

        g.dispose();
    }

    @Override
    public void actionPerformed(ActionEvent e)
    {
        timer.start();
        if(right)
        {
            for(int i = totallength; i >= 0; i--)
            {
                snakeylength[i+1] = snakeylength[i];
                if(i == 0)
                {
                    snakexlength[i] = snakexlength[i] + 25;
                }
                else
                {
                    snakexlength[i] = snakexlength[i-1];
                }
                if(snakexlength[i] > 850)
                {
                    snakexlength[i] = 25;
                }
            }
            repaint();
        }
        if(left)
        {
            for(int i = totallength; i >= 0; i--)
            {
                snakeylength[i+1] = snakeylength[i];
                if(i == 0)
                {
                    snakexlength[i] = snakexlength[i] - 25;
                }
                else
                {
                    snakexlength[i] = snakexlength[i-1];
                }
                if(snakexlength[i] < 25)
                {
                    snakexlength[i] = 850;
                }
            }
            repaint();
        }
        if(up)
        {
            for(int i = totallength; i >= 0; i--)
            {
                snakexlength[i+1] = snakexlength[i];
                if(i == 0)
                {
                    snakeylength[i] = snakeylength[i] - 25;
                }
                else
                {
                    snakeylength[i] = snakeylength[i-1];
                }
                if(snakeylength[i] < 75)
                {
                    snakeylength[i] = 625;
                }
            }
            repaint();
        }
        if(down)
        {
            for(int i = totallength; i >= 0; i--)
            {
                snakexlength[i+1] = snakexlength[i];
                if(i == 0)
                {
                    snakeylength[i] = snakeylength[i] + 25;
                }
                else
                {
                    snakeylength[i] = snakeylength[i-1];
                }
                if(snakeylength[i] > 625)
                {
                    snakeylength[i] = 75;
                }
            }
            repaint();
        }
    }

    @Override
    public void keyTyped(KeyEvent e){}

    @Override
    public void keyPressed(KeyEvent e)
    {
        if(e.getKeyCode() == KeyEvent.VK_SPACE)
        {
            moves = 0;
            score = 0;
            totallength = 3;
            repaint(); 
        }
        if(e.getKeyCode() == KeyEvent.VK_RIGHT)
        {
            moves++;
            right = !left;
            up = false;
            down = false;
        }
        if(e.getKeyCode() == KeyEvent.VK_LEFT)
        {
            moves++;
            left = !right;
            up = false;
            down = false;
        }
        if(e.getKeyCode() == KeyEvent.VK_UP)
        {
            moves++;
            up = !down;
            right = false;
            left = false;
        }
        if(e.getKeyCode() == KeyEvent.VK_DOWN)
        {
            moves++;
            down = !up;
            right = false;
            left = false;
        }
    }

    @Override
    public void keyReleased(KeyEvent e){}
}
