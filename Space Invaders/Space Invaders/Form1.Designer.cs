namespace SpaceInvaders
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.ContactShoot_tick = new System.Windows.Forms.Timer(this.components);
            this.MoveMonsters_tick = new System.Windows.Forms.Timer(this.components);
            this.MonsterShoot_tick = new System.Windows.Forms.Timer(this.components);
            this.DetectLaser_tick = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.Finish = new System.Windows.Forms.Label();
            this.playerMove = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ContactShoot_tick
            // 
            this.ContactShoot_tick.Enabled = true;
            this.ContactShoot_tick.Interval = 10;
            this.ContactShoot_tick.Tick += new System.EventHandler(this.ContactShoot);
            // 
            // MoveMonsters_tick
            // 
            this.MoveMonsters_tick.Enabled = true;
            this.MoveMonsters_tick.Interval = 10;
            this.MoveMonsters_tick.Tick += new System.EventHandler(this.MoveMonsters);
            // 
            // MonsterShoot_tick
            // 
            this.MonsterShoot_tick.Enabled = true;
            this.MonsterShoot_tick.Interval = 1500;
            this.MonsterShoot_tick.Tick += new System.EventHandler(this.MonsterShoot);
            // 
            // DetectLaser_tick
            // 
            this.DetectLaser_tick.Enabled = true;
            this.DetectLaser_tick.Interval = 1;
            this.DetectLaser_tick.Tick += new System.EventHandler(this.DetectLaser);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 719);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Score: 0";
            // 
            // Finish
            // 
            this.Finish.AutoSize = true;
            this.Finish.Font = new System.Drawing.Font("Sitka Small", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Finish.ForeColor = System.Drawing.Color.White;
            this.Finish.Location = new System.Drawing.Point(286, 285);
            this.Finish.Name = "Finish";
            this.Finish.Size = new System.Drawing.Size(0, 52);
            this.Finish.TabIndex = 7;
            // 
            // playerMove
            // 
            this.playerMove.Enabled = true;
            this.playerMove.Interval = 10;
            this.playerMove.Tick += new System.EventHandler(this.playerMove_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(784, 781);
            this.Controls.Add(this.Finish);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 820);
            this.MinimumSize = new System.Drawing.Size(800, 820);
            this.Name = "Form1";
            this.Text = "Space Invaders";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PressKey);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ReleasedKey);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer ContactShoot_tick;
        private System.Windows.Forms.Timer MoveMonsters_tick;
        private System.Windows.Forms.Timer MonsterShoot_tick;
        private System.Windows.Forms.Timer DetectLaser_tick;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Finish;
        private System.Windows.Forms.Timer playerMove;
    }
}

