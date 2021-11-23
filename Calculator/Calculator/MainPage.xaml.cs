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
        bool ongoing_flag, sign_flag, operator_clicked, floating_point_flag;
        int operation_flag;

        public MainPage()
        {
            InitializeComponent();
            opr1 = 0;
            opr2 = 0;
            disp_val = 0;
            floating_point_flag = false;
            operation_flag = 0;// 0 = no operation, 1=add, 2=sub, 3=mul, 4=div, 5=%
            operator_clicked = false;
            ongoing_flag = false;
            sign_flag = false;
            disp_string = disp_val.ToString();
            Display_Label.Text = disp_string;
        }
        private String round_string(String str)
        {
            if (str.Length > 12) return disp_string.Remove(12);
            return str;
        }
        // method execute_operation to do the operation
        private void execute_operation(){
            if (operator_clicked) return;
            // calculates the result in case two operands and an operation are entred
            if (operation_flag > 0)
            {
                double.TryParse(disp_string, out opr2);
                switch (operation_flag)
                {
                    case 1:
                        disp_val = opr1 + opr2;
                        break;
                    case 2:
                        disp_val = opr1 - opr2;
                        break;
                    case 3:
                        disp_val = opr1 * opr2;
                        break;
                    case 4:
                        disp_val = opr1 / opr2;
                        break;
                    case 5:
                        disp_val = opr1 % opr2;
                        break;
                }
                opr1 = disp_val;
                opr2 = 0;
                disp_string = disp_val.ToString();
                Display_Label.Text = round_string(disp_string);
            }
            else
            {
                double.TryParse(disp_string, out opr1); 
            }
            operator_clicked = true;
            ongoing_flag = false;
            floating_point_flag = false;
            sign_flag = false;
        }
        private void press_number(String button_number)
        {
            operator_clicked = false;
 
            if (disp_string == "0" || !ongoing_flag) disp_string = "";
            if (operation_flag > 0 && !ongoing_flag) disp_string = button_number;
            else if (disp_string == "0" && (button_number == "0")) disp_string = "0";
            else disp_string += button_number;
            if (disp_string == "0" && sign_flag) disp_string = "-"+button_number;
            Display_Label.Text = round_string(disp_string);
            if (button_number != "0") ongoing_flag = true;
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
            Display_Label.Text = round_string(disp_string);
            //not working woth equal yet
        }
        private void Button_Equal_Clicked(object sender, EventArgs e)
        {
            execute_operation();
            operation_flag = 0;// 0 = no operation, 1=add, 2=sub, 3=mul, 4=div, 5=%
            operator_clicked = false;
        }
        private void Button_Dot_Clicked(object sender, EventArgs e)
        {
            if (!floating_point_flag) floating_point_flag = true;
            else return;
            if (operator_clicked || disp_string == "0") disp_string = "0.";
            else disp_string += ".";
            ongoing_flag = true;
            if (disp_string.Length > 12) return;
            Display_Label.Text = disp_string;
        }
        private void Button_C_Clicked(object sender, EventArgs e)
        {
            opr1 = 0;
            opr2 = 0;
            disp_val = 0;
            floating_point_flag = false;
            operation_flag = 0;// 0 = no operation, 1=add, 2=sub, 3=mul, 4=div, 5=%
            operator_clicked = false;
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
