namespace Lesson11_winform
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pEat = new System.Windows.Forms.ProgressBar();
            this.pHappy = new System.Windows.Forms.ProgressBar();
            this.pAge = new System.Windows.Forms.ProgressBar();
            this.buttA = new System.Windows.Forms.Button();
            this.buttLeft = new System.Windows.Forms.Button();
            this.buttRight = new System.Windows.Forms.Button();
            this.buttB = new System.Windows.Forms.Button();
            this.buttOptions = new System.Windows.Forms.Button();
            this.buttNewPet = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.labelXcoord = new System.Windows.Forms.Label();
            this.stateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Aksent", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(332, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "ТАМАГОЧА";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 25;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Aksent", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(676, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "МУЗ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Aksent", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(676, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "НОВ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Aksent", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(676, 181);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "ОПЦ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pEat
            // 
            this.pEat.Location = new System.Drawing.Point(233, 101);
            this.pEat.Name = "pEat";
            this.pEat.Size = new System.Drawing.Size(100, 16);
            this.pEat.TabIndex = 10;
            // 
            // pHappy
            // 
            this.pHappy.Location = new System.Drawing.Point(371, 101);
            this.pHappy.Name = "pHappy";
            this.pHappy.Size = new System.Drawing.Size(100, 16);
            this.pHappy.TabIndex = 10;
            this.pHappy.Tag = "";
            // 
            // pAge
            // 
            this.pAge.Location = new System.Drawing.Point(509, 101);
            this.pAge.Name = "pAge";
            this.pAge.Size = new System.Drawing.Size(100, 16);
            this.pAge.TabIndex = 10;
            // 
            // buttA
            // 
            this.buttA.BackColor = System.Drawing.Color.Gainsboro;
            this.buttA.BackgroundImage = global::Lesson11_winform.Resource1.ButtonBig;
            this.buttA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttA.FlatAppearance.BorderSize = 0;
            this.buttA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttA.Location = new System.Drawing.Point(61, 288);
            this.buttA.Name = "buttA";
            this.buttA.Size = new System.Drawing.Size(56, 55);
            this.buttA.TabIndex = 13;
            this.buttA.UseVisualStyleBackColor = false;
            this.buttA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttA_MouseDown);
            this.buttA.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttA_MouseUp);
            // 
            // buttLeft
            // 
            this.buttLeft.BackColor = System.Drawing.Color.Gainsboro;
            this.buttLeft.BackgroundImage = global::Lesson11_winform.Resource1.ButtonBig;
            this.buttLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttLeft.FlatAppearance.BorderSize = 0;
            this.buttLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttLeft.Location = new System.Drawing.Point(61, 369);
            this.buttLeft.Name = "buttLeft";
            this.buttLeft.Size = new System.Drawing.Size(56, 55);
            this.buttLeft.TabIndex = 13;
            this.buttLeft.UseVisualStyleBackColor = false;
            this.buttLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttLeft_MouseDown);
            this.buttLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttLeft_MouseUp);
            // 
            // buttRight
            // 
            this.buttRight.BackColor = System.Drawing.Color.Silver;
            this.buttRight.BackgroundImage = global::Lesson11_winform.Resource1.ButtonBig;
            this.buttRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttRight.FlatAppearance.BorderSize = 0;
            this.buttRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttRight.Location = new System.Drawing.Point(681, 369);
            this.buttRight.Name = "buttRight";
            this.buttRight.Size = new System.Drawing.Size(56, 55);
            this.buttRight.TabIndex = 13;
            this.buttRight.UseVisualStyleBackColor = false;
            this.buttRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttRight_MouseDown);
            this.buttRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttRight_MouseUp);
            // 
            // buttB
            // 
            this.buttB.BackColor = System.Drawing.Color.Silver;
            this.buttB.BackgroundImage = global::Lesson11_winform.Resource1.ButtonBig;
            this.buttB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttB.FlatAppearance.BorderSize = 0;
            this.buttB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttB.Location = new System.Drawing.Point(681, 288);
            this.buttB.Name = "buttB";
            this.buttB.Size = new System.Drawing.Size(56, 55);
            this.buttB.TabIndex = 13;
            this.buttB.UseVisualStyleBackColor = false;
            this.buttB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttB_MouseDown);
            this.buttB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttB_MouseUp);
            // 
            // buttOptions
            // 
            this.buttOptions.BackgroundImage = global::Lesson11_winform.Resource1.ButtonSmall;
            this.buttOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttOptions.FlatAppearance.BorderSize = 0;
            this.buttOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttOptions.Location = new System.Drawing.Point(681, 143);
            this.buttOptions.Margin = new System.Windows.Forms.Padding(0);
            this.buttOptions.MaximumSize = new System.Drawing.Size(60, 46);
            this.buttOptions.MinimumSize = new System.Drawing.Size(50, 34);
            this.buttOptions.Name = "buttOptions";
            this.buttOptions.Size = new System.Drawing.Size(50, 34);
            this.buttOptions.TabIndex = 8;
            this.buttOptions.UseVisualStyleBackColor = true;
            this.buttOptions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttOptions_MouseClick);
            // 
            // buttNewPet
            // 
            this.buttNewPet.BackgroundImage = global::Lesson11_winform.Resource1.ButtonSmall;
            this.buttNewPet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttNewPet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttNewPet.FlatAppearance.BorderSize = 0;
            this.buttNewPet.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.buttNewPet.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.buttNewPet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttNewPet.Location = new System.Drawing.Point(681, 88);
            this.buttNewPet.Margin = new System.Windows.Forms.Padding(0);
            this.buttNewPet.MaximumSize = new System.Drawing.Size(60, 42);
            this.buttNewPet.MinimumSize = new System.Drawing.Size(50, 34);
            this.buttNewPet.Name = "buttNewPet";
            this.buttNewPet.Size = new System.Drawing.Size(50, 34);
            this.buttNewPet.TabIndex = 7;
            this.buttNewPet.UseVisualStyleBackColor = true;
            this.buttNewPet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttNewPet_MouseClick);
            this.buttNewPet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttNewPet_MouseDown);
            this.buttNewPet.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttNewPet_MouseUp);
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox1.BackgroundImage = global::Lesson11_winform.Resource1.ButtonSmall;
            this.checkBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox1.FlatAppearance.BorderSize = 0;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(681, 33);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox1.MaximumSize = new System.Drawing.Size(60, 42);
            this.checkBox1.MinimumSize = new System.Drawing.Size(50, 34);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(50, 34);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Lesson11_winform.Resource1.age_32x32;
            this.pictureBox3.Location = new System.Drawing.Point(474, 85);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Lesson11_winform.Resource1.happy_32x32;
            this.pictureBox2.Location = new System.Drawing.Point(336, 85);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Lesson11_winform.Resource1.eat_32x32;
            this.pictureBox1.Location = new System.Drawing.Point(198, 85);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // labelXcoord
            // 
            this.labelXcoord.AutoSize = true;
            this.labelXcoord.Location = new System.Drawing.Point(61, 13);
            this.labelXcoord.Name = "labelXcoord";
            this.labelXcoord.Size = new System.Drawing.Size(35, 13);
            this.labelXcoord.TabIndex = 14;
            this.labelXcoord.Text = "label5";
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(541, 13);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(35, 13);
            this.stateLabel.TabIndex = 15;
            this.stateLabel.Text = "label5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 462);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.labelXcoord);
            this.Controls.Add(this.buttA);
            this.Controls.Add(this.buttLeft);
            this.Controls.Add(this.buttRight);
            this.Controls.Add(this.buttB);
            this.Controls.Add(this.pAge);
            this.Controls.Add(this.pHappy);
            this.Controls.Add(this.pEat);
            this.Controls.Add(this.buttOptions);
            this.Controls.Add(this.buttNewPet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(900, 800);
            this.MinimumSize = new System.Drawing.Size(800, 462);
            this.Name = "Form1";
            this.Text = "Tamagotchi";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttNewPet;
        private System.Windows.Forms.Button buttOptions;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar pEat;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ProgressBar pHappy;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ProgressBar pAge;
        private System.Windows.Forms.Button buttB;
        private System.Windows.Forms.Button buttRight;
        private System.Windows.Forms.Button buttLeft;
        private System.Windows.Forms.Button buttA;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label labelXcoord;
        private System.Windows.Forms.Label stateLabel;
    }
}

