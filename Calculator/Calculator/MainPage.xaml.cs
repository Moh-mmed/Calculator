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
        bool ongoing_flag, sign_flag;
        int operation_flag, floating_point_flag, operator_clicked;

        public MainPage()
        {
            InitializeComponent();
            opr1 = 0;
            opr2 = 0;
            disp_val = 0;
            floating_point_flag = 0;
            operation_flag = 0;// 0 = no operation, 1=add, 2=sub, 3=mul, 4=div, 5=%
            operator_clicked = 0;
            ongoing_flag = false;
            sign_flag = false;
            disp_string = disp_val.ToString();
            Display_Label.Text = disp_string;
        }

        // method execute_operation to do the operation
        private void execute_operation(){
            if (operator_clicked == 1) return; 
            // calculates the result in case two operands and an operation are entred
            if (operation_flag > 0)
            {
                double.TryParse(disp_string, out opr2);
                switch (operation_flag)
                {
                    case 1:
                        disp_val = opr1 + opr2;
                        opr1 = disp_val;
                        opr2 = 0;
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
            else double.TryParse(disp_string, out opr1);

            Display_Label2.Text = opr1.ToString();
            operator_clicked = 1;
            ongoing_flag = false;
            sign_flag = false;
        }
        private void press_number(String button_number)
        {
            double prev_value = double.Parse(disp_string);
            operator_clicked = 0;
 
            if (prev_value == 0 || operation_flag == 0) disp_string = "";
            if (operation_flag > 0 && !ongoing_flag) disp_string = button_number;
            else if (prev_value == 0 && (button_number == "0")) disp_string = "0";
            else disp_string += button_number;
            if (prev_value == 0 && sign_flag) disp_string = "-"+button_number; 
            Display_Label.Text = disp_string;
            if(button_number != "0") ongoing_flag = true;
        }

        // Sign, equal, dot and clear
        private void Button_Sign_Clicked(object sender, EventArgs e)
        {
            sign_flag = !sign_flag;
          
            if (operation_flag > 0 && !ongoing_flag)
            {
                if (sign_flag) disp_string = "-0";
                if (!sign_flag) disp_string = "0";
            }
            else
            {
                if (sign_flag) disp_string = disp_string.Insert(0, "-");
                if (!sign_flag) disp_string = disp_string.Remove(0, 1);
            }
            Display_Label.Text = disp_string;
        }
        private void Button_Equal_Clicked(object sender, EventArgs e)
        {
            execute_operation();
            floating_point_flag = 0;
            operation_flag = 0;// 0 = no operation, 1=add, 2=sub, 3=mul, 4=div, 5=%
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
            ongoing_flag = false;
            sign_flag = false;
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
            String button_number = Button_Zero.Text;
            press_number(button_number);
        }

        private void Button_1_Clicked(object sender, EventArgs e)
        {
            String button_number = Button_1.Text;
            press_number(button_number);
        }

        private void Button_2_Clicked(object sender, EventArgs e)
        {
            String button_number = Button_2.Text;
            press_number(button_number);
        }
        
        private void Button_3_Clicked(object sender, EventArgs e)
        {
            String button_number = Button_3.Text;
            press_number(button_number);
        }

        private void Button_4_Clicked(object sender, EventArgs e)
        {
            String button_number = Button_4.Text;
            press_number(button_number);
        }

        private void Button_5_Clicked(object sender, EventArgs e)
        {
            String button_number = Button_5.Text;
            press_number(button_number);
        }

        private void Button_6_Clicked(object sender, EventArgs e)
        {
            String button_number = Button_6.Text;
            press_number(button_number);
        }

        private void Button_7_Clicked(object sender, EventArgs e)
        {
            String button_number = Button_7.Text;
            press_number(button_number);
        }

        private void Button_8_Clicked(object sender, EventArgs e)
        {
            String button_number = Button_8.Text;
            press_number(button_number);
        }

        private void Button_9_Clicked(object sender, EventArgs e)
        {
            String button_number = Button_9.Text;
            press_number(button_number);
        }
    }
}
