using System;
using System.Drawing;
using System.Windows.Forms;

namespace LogisticRegression
{
    public partial class Form1 : Form
    {
        Label no_values = new Label();
        Label title = new Label();
        Label x = new Label();
        Label y = new Label();
        TextBox number = new TextBox();
        Button btn1 = new Button();
        Button btn2 = new Button();
        TextBox[] x_val = new TextBox[0];
        TextBox[] y_val = new TextBox[0];
        Label intercept = new Label();
        Label slope = new Label();
        Button btn3 = new Button();
        //Button btn4 = new Button();
        double[] x_values = new double[0];
        double[] y_values = new double[0];
        int no;
        public void Button_Action(object sender,EventArgs e)
        {
            no = int.Parse(number.Text);
            Array.Resize(ref x_val, no);
            Array.Resize(ref y_val, no);
            x.Text = "X Values";
            y.Text = "Y Values";
            x.SetBounds(500, 125, 200, 50);
            y.SetBounds(700, 125, 200, 50);

            int k = 0;
            for(int i = 0; i <no; i++)
            {
                x_val[i] = new TextBox();
                y_val[i] = new TextBox();
                x_val[i].SetBounds(500, 200 + k, 50, 50);
                y_val[i].SetBounds(700, 200 + k, 50, 50);
                Controls.Add(x_val[i]);
                Controls.Add(y_val[i]);
                k += 50;
            }
            btn2.Visible = true;
           
            
        }

        public void Calculate(object sender,EventArgs e)
        {
            Array.Resize(ref x_values, no);
            Array.Resize(ref y_values, no);
            for(int i = 0; i <no; i++)
            {
                x_values[i] = double.Parse(x_val[i].Text);
                y_values[i] = double.Parse(y_val[i].Text);
            }

            double a = 0; //Intercept=0
            double b = 0; //Slope=0;

            double[] error = new double[no];
            double[] y = new double[no];
            double[] a_list = new double[no];
            double[] b_list = new double[no];

            double lr = 1; //Learning Rate=1

            for(int i = 0; i < 1000000; i++)
            {
                double sum1 = 0;
                double sum2 = 0;
                for(int j = 0; j < no; j++)
                {
                    y[j] = 1 / (1 + Math.Exp(-b * x_values[j]-a));
                    error[j] = y[j] - y_values[j];
                    a_list[j] = error[j] * Math.Pow(y[j], 2) * Math.Exp(-b * x_values[j] - a);
                    sum1 += a_list[j];
                    b_list[j] = a_list[j] * x_values[j];
                    sum2 += b_list[j];
                }
                a -= lr * 2 * sum1 / no;
                b -= lr * 2 * sum2 / no;
            }
            intercept.Text = "Intercept= " + Convert.ToString(a);
            slope.Text = "Slope= " + Convert.ToString(b);
            
           

            intercept.Visible = true;
            slope.Visible = true;
        }

        public void Delete_Box(object sender,EventArgs e)
        {
            Controls.Remove(x_val[no-1]);
            Controls.Remove(y_val[no - 1]);
            intercept.Visible = false;
            slope.Visible = false;
            no -= 1;

        }

       
       

        public Form1()
        {
            InitializeComponent();
            btn1.Text = "Add TextBoxes";
            btn1.SetBounds(1000, 500, 100, 50);
            btn2.Text = "Calculate";
            btn2.SetBounds(1000, 600, 100, 50);
            btn3.Text = "Delete Text Box";
            btn3.SetBounds(50, 500, 100, 50);
            //btn4.SetBounds(50, 600, 100, 50);
            title.Text = "Logistic Regression Calculator";
            title.SetBounds(550, 10, 300, 100);
            no_values.Text = "Number of Values:";
            no_values.SetBounds(50, 100, 200, 50);
            number.SetBounds(250, 100, 100, 50);
            intercept.SetBounds(850, 250, 200, 100);
            slope.SetBounds(850, 350, 200, 100);
            this.Font = new Font("Times New Roman", 10F);
            this.WindowState = FormWindowState.Maximized;
            this.Controls.Add(no_values);
            this.Controls.Add(title);
            this.Controls.Add(number);
            this.Controls.Add(btn1);
            this.Controls.Add(btn2);
            this.Controls.Add(btn3);
            //this.Controls.Add(btn4);
            this.Controls.Add(x);
            this.Controls.Add(y);
            this.Controls.Add(intercept);
            this.Controls.Add(slope);
            btn1.Click += Button_Action;
            btn2.Click += Calculate;
            btn3.Click += Delete_Box;
            //btn4.Click += Add_Box;
            btn2.Visible = false;
            intercept.Visible = false;
            slope.Visible = false;
           
        }

        
    }
}
