using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void UpdateSize()
        {
            UpdateTotalPrice();
            if (rbSmall.Checked)
            {
                lbSize.Text = "Small";
                return;
            }
            if (rbLarge.Checked)
            {
                lbSize.Text = "Large";
                return;
            }
            if(rbMedium.Checked)
            {
                lbSize.Text = "Medium";
                return;
            }
        }

        void UpdateToppings()
        {
            UpdateTotalPrice();

            string sToppings = "";
            if (chkExtraChesse.Checked)
            {
                sToppings = "Extra Chesse";
            }


            if (chkOnions.Checked)
            {
                sToppings += ", Onions";
            }

            if (chkMushrooms.Checked)
            {
                sToppings += ", Mushrooms";
            }

            if (chkOlives.Checked)
            {
                sToppings += ", Olives";
            }

            if (chkTomatoes.Checked)
            {
                sToppings += ", Tomatoes";
            }

            if (chkGreenPapers.Checked)
            {
                sToppings += ", Green Papers";
            }

            if (sToppings.StartsWith(","))
            {
                sToppings = sToppings.Substring(1, sToppings.Length - 1).Trim();
            }

            if (sToppings == "")
                sToppings = "No Toppings";

            lbToppings.Text = sToppings;
        }

        void UpdateWhereToEat()
        {
            UpdateTotalPrice();
            if(rbEatIn.Checked)
            { 
                lbWhereToEat.Text = "Eat In.";
            return;
            }

            if (rbTakeOut.Checked)
            {
                lbWhereToEat.Text = "Take Out.";
                return;
            }
}

        void UpdateCrust()
        {
            UpdateTotalPrice();
            if (rbThin.Checked)
            {
                lbCrustType.Text = "Thin Crust";
                return;
            }

            if (rbThick.Checked)
            {
                lbCrustType.Text = "Thick Crust";
                return;
            }

        }

        float GetSelectedSizePrice()
        {
            if (rbSmall.Checked)
                return Convert.ToSingle(rbSmall.Tag);
            else if (rbMedium.Checked)
                return Convert.ToSingle(rbMedium.Tag);
            else
                return Convert.ToSingle(rbLarge.Tag);
        }

        float GetSelectedCrustPrice()
        {
            if (rbThin.Checked)
                return Convert.ToSingle(rbThin.Tag);
            else
                return Convert.ToSingle(rbThick.Tag);
        }

        float GetSelectedToppingsPrice()
        {
            float ToppingsTotalPrice = 0;

            if (chkExtraChesse.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkExtraChesse.Tag);
            }


            if (chkOnions.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkOnions.Tag);
            }

            if (chkMushrooms.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkMushrooms.Tag);
            }

            if (chkOlives.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkOlives.Tag);
            }

            if (chkTomatoes.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkTomatoes.Tag);
            }

            if (chkGreenPapers.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkGreenPapers.Tag);
            }



            return ToppingsTotalPrice;
        }

        float CalculateTotalPrice()
        {
            return GetSelectedSizePrice() + GetSelectedCrustPrice() + GetSelectedToppingsPrice();
        }

        void UpdateTotalPrice()
        {
            lbPrice.Text = "$"+CalculateTotalPrice().ToString();
        }

        void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateToppings();
            UpdateCrust();
            UpdateWhereToEat();
            UpdateTotalPrice();
        }

        void ResetForm()
        {
            gbSize.Enabled = true;
            gbToppings.Enabled = true;
            gbCrust.Enabled = true;
            gbWhereToEat.Enabled = true;

            rbMedium.Checked = true;

            chkExtraChesse.Checked = false;
            chkOnions.Checked = false;
            chkMushrooms.Checked = false;
            chkOlives.Checked = false;
            chkTomatoes.Checked = false;
            chkGreenPapers.Checked = false;

            rbThin.Checked = true;
            rbEatIn.Checked = true;
            btnOrderPizza.Enabled = true;
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbThin_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbThick_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void chkExtraChesse_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOnions_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkGreenPapers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void btnRestForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Order", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Placed Successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnOrderPizza.Enabled = false;
                gbSize.Enabled = false;
                gbToppings.Enabled = false;
                gbCrust.Enabled = false;
                gbWhereToEat.Enabled = false;

            }
            else

                MessageBox.Show("Update your order", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }
    }

}
