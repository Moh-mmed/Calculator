using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        double opr1, opr2, disp_val;
        string disp_string;
        int operation_flag, floating_point_flag, ongoig_flag, operator_clicked;

        public MainPage()
        {
            InitializeComponent();
            opr1 = 0;
            opr2 = 0;
            disp_val = 0;
            floating_point_flag = 0;
            operation_flag = 0;// 0 = no operation, 1=add, 2=sub, 3=mul, 4=div, 5=%
            operator_clicked = 0;
            ongoig_flag = 0;
            disp_string = disp_val.ToString();
            Display_Label.Text = disp_string;
            //double.TryParse(disp_string, out disp_val);
        }

        // method execute_operation to do the operation
        private void execute_operation(){
            if (operator_clicked == 1)
            {
                operation_flag = 1;
                return;
            }
            // calculates the result in case two operands and an operation are entred
            if (operation_flag > 0)
            {
                double.TryParse(disp_string, out opr2);
                switch (operation_flag)
                {
                    case 1:
                        disp_val = opr1 + opr2;
                        opr1 = disp_val;
                        disp_string = disp_val.ToString();
                        Display_Label.Text = disp_string;
                        Display_Label2.Text = disp_val.ToString();
                        break;
                    case 2:
                        disp_val = opr1 - opr2;
                        opr1 = disp_val;
                        opr2 = 0;
                        disp_string = disp_val.ToString();
                        Display_Label.Text = disp_string;
                        break;
                    case 3:
                        disp_val = opr1 * opr2;
                        opr1 = disp_val;
                        disp_string = disp_val.ToString();
                        Display_Label.Text = disp_string;
                        break;
                    case 4:
                        disp_val = opr1 / opr2;
                        opr1 = disp_val;
                        opr2 = 0;
                        disp_string = disp_val.ToString();
                        Display_Label.Text = disp_string;
                        break;
                    case 5:
                        disp_val = opr1 % opr2;
                        opr1 = disp_val;
                        opr2 = 0;
                        disp_string = disp_val.ToString();
                        Display_Label.Text = disp_string;
                        break;

                }
                disp_string = disp_val.ToString();
                Display_Label.Text = disp_string;
                Display_Label2.Text = disp_string;
            }
            else
            {
                double.TryParse(disp_string, out opr1);
            }
            Display_Label2.Text = opr1.ToString();
            operator_clicked = 1;
            ongoig_flag = 0;

        }

        // Sign, equal, dot and clear
        private void Button_Sign_Clicked(object sender, EventArgs e)
        {

        }
        private void Button_Equal_Clicked(object sender, EventArgs e)
        {
            double.TryParse(disp_string, out opr2);
            if (operation_flag == 10) disp_val = opr1 + opr2;
            else if (operation_flag == 20) disp_val = opr1 - opr2;

            disp_string = disp_val.ToString();
            Display_Label.Text = disp_string;
            operation_flag = 0;
        }

        private void Button_Dot_Clicked(object sender, EventArgs e)
        {

        }
        private void Button_C_Clicked(object sender, EventArgs e)
        {
            opr1 = 0;
            opr2 = 0;
            disp_val = 0;
            floating_point_flag = 0;
            operation_flag = 0;// 0 = no operation, 1=add, 2=sub, 3=mul, 4=div, 5=%
            operator_clicked = 0;
            ongoig_flag = 0;
            disp_string = disp_val.ToString();
            Display_Label.Text = disp_string;
        }

       
        // Operators: 
        private void Button_Add_Clicked(object sender, EventArgs e)
        {
            execute_operation();
            operation_flag = 1;
        }

        private void Button_Sub_Clicked(object sender, EventArgs e)
        {
            execute_operation();
            operation_flag = 2;
        }

        private void Button_Mul_Clicked(object sender, EventArgs e)
        {
            execute_operation();
            operation_flag = 3;
        }

        private void Button_Div_Clicked(object sender, EventArgs e)
        {
            execute_operation();
            operation_flag = 4;
        }

        private void Button_Percent_Clicked(object sender, EventArgs e)
        {
            execute_operation();
            operation_flag = 5;
        }


        // Numbers
        private void Button_Zero_Clicked(object sender, EventArgs e)
        {
            operator_clicked = 0;
            if (disp_string == "0") disp_string = "";
            //if (double.Parse(disp_string) == 0) disp_string = "0";
            if (operation_flag > 0)
            {
                if (ongoig_flag == 0)
                {
                    disp_string = "0";
                }
                else
                {
                    //*check if there is zero
                    if (disp_string != "0") disp_string += "0";
                    else disp_string = "0";
                }

            }
            else
            {
                if (double.Parse(disp_string) != 0) disp_string += "0";
                else disp_string = "0";
            }
            Display_Label.Text = disp_string;
            ongoig_flag = 1;
        }

        private void Button_1_Clicked(object sender, EventArgs e)
        {
            operator_clicked = 0;
            if (disp_string == "0") disp_string = "";
            if (operation_flag > 0)
            {
                if (ongoig_flag == 0)
                {
                    disp_string = "1";
                }
                else
                {
                    disp_string += "1";
                }

            }
            else
            {
                disp_string += "1";
            }
            Display_Label.Text = disp_string;
            ongoig_flag = 1;
        }

        private void Button_2_Clicked(object sender, EventArgs e)
        {
            operator_clicked = 0;
            if (disp_string == "0") disp_string = "";
            if (operation_flag > 0)
            {
                if (ongoig_flag == 0)
                {
                    disp_string = "2";
                }
                else
                {
                    disp_string += "2";
                }

            }
            else
            {
                disp_string += "2";
            }
            Display_Label.Text = disp_string;
            ongoig_flag = 1;
        }
        
        private void Button_3_Clicked(object sender, EventArgs e)
        {
            operator_clicked = 0;
            if (disp_string == "0") disp_string = "";
            if (operation_flag > 0)
            {
                if (ongoig_flag == 0)
                {
                    disp_string = "3";
                }
                else
                {
                    disp_string += "3";
                }

            }
            else
            {
                disp_string += "3";
            }
            Display_Label.Text = disp_string;
            ongoig_flag = 1;
        }

        private void Button_4_Clicked(object sender, EventArgs e)
        {
            operator_clicked = 0;
            if (disp_string == "0") disp_string = "";
            if (operation_flag > 0)
            {
                if (ongoig_flag == 0)
                {
                    disp_string = "4";
                }
                else
                {
                    disp_string += "4";
                }

            }
            else
            {
                disp_string += "4";
            }
            Display_Label.Text = disp_string;
            ongoig_flag = 1;
        }

        private void Button_5_Clicked(object sender, EventArgs e)
        {
            operator_clicked = 0;
            if (disp_string == "0") disp_string = "";
            if (operation_flag > 0)
            {
                if (ongoig_flag == 0)
                {
                    disp_string = "5";
                }
                else
                {
                    disp_string += "5";
                }

            }
            else
            {
                disp_string += "5";
            }
            Display_Label.Text = disp_string;
            ongoig_flag = 1;
        }

        private void Button_6_Clicked(object sender, EventArgs e)
        {
            operator_clicked = 0;
            if (disp_string == "0") disp_string = "";
            if (operation_flag > 0)
            {
                if (ongoig_flag == 0)
                {
                    disp_string = "6";
                }
                else
                {
                    disp_string += "6";
                }

            }
            else
            {
                disp_string += "6";
            }
            Display_Label.Text = disp_string;
            ongoig_flag = 1;
        }

        private void Button_7_Clicked(object sender, EventArgs e)
        {
            operator_clicked = 0;
            if (disp_string == "0") disp_string = "";
            if (operation_flag > 0)
            {
                if (ongoig_flag == 0)
                {
                    disp_string = "7";
                }
                else
                {
                    disp_string += "7";
                }

            }
            else
            {
                disp_string += "7";
            }
            Display_Label.Text = disp_string;
            ongoig_flag = 1;
        }

        private void Button_8_Clicked(object sender, EventArgs e)
        {
            operator_clicked = 0;
            if (disp_string == "0") disp_string = "";
            if (operation_flag > 0)
            {
                if (ongoig_flag == 0)
                {
                    disp_string = "8";
                }
                else
                {
                    disp_string += "8";
                }

            }
            else
            {
                disp_string += "8";
            }
            Display_Label.Text = disp_string;
            ongoig_flag = 1;    
        }

        private void Button_9_Clicked(object sender, EventArgs e)
        {
            operator_clicked = 0;
            if (disp_string == "0") disp_string = "";
            if (operation_flag > 0)
            {
                if (ongoig_flag == 0)
                {
                    disp_string = "9";
                }
                else
                {
                    disp_string += "9";
                }

            }
            else
            {
                disp_string += "9";
            }
            Display_Label.Text = disp_string;
            ongoig_flag = 1;
        }
    }
}
