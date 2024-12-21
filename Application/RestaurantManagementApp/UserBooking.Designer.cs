namespace RestaurantManagementApp
{
    partial class UserBooking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserBooking));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEdit_reset = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblBooking = new System.Windows.Forms.Label();
            this.lblMenu = new System.Windows.Forms.Label();
            this.lblHome = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.bookingDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumberPeople = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnSeats = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAgree = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBudget = new System.Windows.Forms.TextBox();
            this.btnPre_orders_Dish = new System.Windows.Forms.Button();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(524, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 50);
            this.label1.TabIndex = 9;
            this.label1.Text = "CHAT PALACE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1250, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 29);
            this.label3.TabIndex = 11;
            this.label3.Text = "X";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.lblEdit_reset);
            this.panel1.Controls.Add(this.lblLocation);
            this.panel1.Controls.Add(this.lblBooking);
            this.panel1.Controls.Add(this.picUser);
            this.panel1.Controls.Add(this.lblMenu);
            this.panel1.Controls.Add(this.lblHome);
            this.panel1.Location = new System.Drawing.Point(-1, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1281, 89);
            this.panel1.TabIndex = 10;
            // 
            // lblEdit_reset
            // 
            this.lblEdit_reset.AutoSize = true;
            this.lblEdit_reset.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdit_reset.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEdit_reset.Location = new System.Drawing.Point(928, 40);
            this.lblEdit_reset.Name = "lblEdit_reset";
            this.lblEdit_reset.Size = new System.Drawing.Size(175, 25);
            this.lblEdit_reset.TabIndex = 0;
            this.lblEdit_reset.Text = "Edit/Reset bill";
            this.lblEdit_reset.Click += new System.EventHandler(this.lblEdit_reset_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLocation.Location = new System.Drawing.Point(775, 40);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(108, 25);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "Location";
            this.lblLocation.Click += new System.EventHandler(this.lblLocation_Click);
            // 
            // lblBooking
            // 
            this.lblBooking.AutoSize = true;
            this.lblBooking.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBooking.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBooking.Location = new System.Drawing.Point(615, 40);
            this.lblBooking.Name = "lblBooking";
            this.lblBooking.Size = new System.Drawing.Size(103, 25);
            this.lblBooking.TabIndex = 0;
            this.lblBooking.Text = "Booking";
            this.lblBooking.Click += new System.EventHandler(this.lblBooking_Click);
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMenu.Location = new System.Drawing.Point(462, 40);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(72, 25);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "Menu";
            this.lblMenu.Click += new System.EventHandler(this.lblMenu_Click);
            // 
            // lblHome
            // 
            this.lblHome.AutoSize = true;
            this.lblHome.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblHome.Location = new System.Drawing.Point(316, 40);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(77, 25);
            this.lblHome.TabIndex = 0;
            this.lblHome.Text = "Home";
            this.lblHome.Click += new System.EventHandler(this.lblHome_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(202, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 28);
            this.label2.TabIndex = 12;
            this.label2.Text = "Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Book Antiqua", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(202, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 28);
            this.label4.TabIndex = 12;
            this.label4.Text = "Time:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Book Antiqua", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(735, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 28);
            this.label5.TabIndex = 12;
            this.label5.Text = "Mail";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Book Antiqua", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(735, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 28);
            this.label6.TabIndex = 12;
            this.label6.Text = "Date:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(307, 225);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(283, 22);
            this.txtName.TabIndex = 13;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(823, 225);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(283, 22);
            this.txtMail.TabIndex = 13;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(307, 278);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(283, 22);
            this.txtTime.TabIndex = 13;
            // 
            // bookingDate
            // 
            this.bookingDate.Location = new System.Drawing.Point(823, 276);
            this.bookingDate.Name = "bookingDate";
            this.bookingDate.Size = new System.Drawing.Size(278, 22);
            this.bookingDate.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Book Antiqua", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(165, 327);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 28);
            this.label7.TabIndex = 12;
            this.label7.Text = "Location:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(307, 331);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(283, 24);
            this.comboBox1.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Book Antiqua", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(735, 327);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(213, 28);
            this.label8.TabIndex = 12;
            this.label8.Text = "Number of people:";
            // 
            // txtNumberPeople
            // 
            this.txtNumberPeople.Location = new System.Drawing.Point(973, 333);
            this.txtNumberPeople.Name = "txtNumberPeople";
            this.txtNumberPeople.Size = new System.Drawing.Size(153, 22);
            this.txtNumberPeople.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Book Antiqua", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(182, 427);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 28);
            this.label9.TabIndex = 12;
            this.label9.Text = "Message:";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(179, 458);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(956, 83);
            this.txtMessage.TabIndex = 13;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(307, 385);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(165, 22);
            this.textBox3.TabIndex = 16;
            // 
            // btnSeats
            // 
            this.btnSeats.Location = new System.Drawing.Point(171, 378);
            this.btnSeats.Name = "btnSeats";
            this.btnSeats.Size = new System.Drawing.Size(130, 36);
            this.btnSeats.TabIndex = 17;
            this.btnSeats.Text = "Seats";
            this.btnSeats.UseVisualStyleBackColor = true;
            this.btnSeats.Click += new System.EventHandler(this.btnSeats_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(668, 573);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(165, 41);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnAgree
            // 
            this.btnAgree.Location = new System.Drawing.Point(474, 573);
            this.btnAgree.Name = "btnAgree";
            this.btnAgree.Size = new System.Drawing.Size(165, 41);
            this.btnAgree.TabIndex = 18;
            this.btnAgree.Text = "Agree";
            this.btnAgree.UseVisualStyleBackColor = true;
            this.btnAgree.Click += new System.EventHandler(this.btnAgree_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(490, 544);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(329, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Please check again to make sure your\'s bills is correct";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Book Antiqua", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(501, 156);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 28);
            this.label11.TabIndex = 12;
            this.label11.Text = "Budget:";
            // 
            // txtBudget
            // 
            this.txtBudget.Location = new System.Drawing.Point(601, 162);
            this.txtBudget.Name = "txtBudget";
            this.txtBudget.Size = new System.Drawing.Size(153, 22);
            this.txtBudget.TabIndex = 13;
            // 
            // btnPre_orders_Dish
            // 
            this.btnPre_orders_Dish.Location = new System.Drawing.Point(856, 385);
            this.btnPre_orders_Dish.Name = "btnPre_orders_Dish";
            this.btnPre_orders_Dish.Size = new System.Drawing.Size(159, 36);
            this.btnPre_orders_Dish.TabIndex = 17;
            this.btnPre_orders_Dish.Text = "Pre-ordered dishes ";
            this.btnPre_orders_Dish.UseVisualStyleBackColor = true;
            this.btnPre_orders_Dish.Click += new System.EventHandler(this.btnPreOrders_Click);
            // 
            // picUser
            // 
            this.picUser.BackColor = System.Drawing.Color.White;
            this.picUser.Image = ((System.Drawing.Image)(resources.GetObject("picUser.Image")));
            this.picUser.Location = new System.Drawing.Point(1231, 39);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(50, 50);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUser.TabIndex = 12;
            this.picUser.TabStop = false;
            this.picUser.Click += new System.EventHandler(this.picUser_Click);
            // 
            // UserBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnAgree);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPre_orders_Dish);
            this.Controls.Add(this.btnSeats);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.bookingDate);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtBudget);
            this.Controls.Add(this.txtNumberPeople);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserBooking";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblEdit_reset;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblBooking;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.DateTimePicker bookingDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNumberPeople;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnSeats;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAgree;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBudget;
        private System.Windows.Forms.Button btnPre_orders_Dish;
    }
}