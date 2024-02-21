
namespace V3
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
            this.songList = new System.Windows.Forms.ListBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.btn_Previous = new System.Windows.Forms.Button();
            this.btn_PlayPause = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.lbl_SongName = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_AddQueue = new System.Windows.Forms.Button();
            this.btn_RemoveSong = new System.Windows.Forms.Button();
            this.lbl_TotalDuration = new System.Windows.Forms.Label();
            this.lbl_CurrentPosition = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // songList
            // 
            this.songList.FormattingEnabled = true;
            this.songList.ItemHeight = 16;
            this.songList.Location = new System.Drawing.Point(168, 12);
            this.songList.Name = "songList";
            this.songList.Size = new System.Drawing.Size(430, 196);
            this.songList.TabIndex = 0;
            this.songList.SelectedIndexChanged += new System.EventHandler(this.songList_SelectedIndexChanged);
            // 
            // trackBar
            // 
            this.trackBar.LargeChange = 1;
            this.trackBar.Location = new System.Drawing.Point(168, 281);
            this.trackBar.Maximum = 1000;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(430, 56);
            this.trackBar.TabIndex = 1;
            // 
            // btn_Previous
            // 
            this.btn_Previous.Location = new System.Drawing.Point(168, 352);
            this.btn_Previous.Name = "btn_Previous";
            this.btn_Previous.Size = new System.Drawing.Size(75, 35);
            this.btn_Previous.TabIndex = 2;
            this.btn_Previous.Text = "Previous";
            this.btn_Previous.UseVisualStyleBackColor = true;
            this.btn_Previous.Click += new System.EventHandler(this.btn_Previous_Click);
            // 
            // btn_PlayPause
            // 
            this.btn_PlayPause.Location = new System.Drawing.Point(336, 352);
            this.btn_PlayPause.Name = "btn_PlayPause";
            this.btn_PlayPause.Size = new System.Drawing.Size(75, 35);
            this.btn_PlayPause.TabIndex = 2;
            this.btn_PlayPause.Text = "Pause";
            this.btn_PlayPause.UseVisualStyleBackColor = true;
            this.btn_PlayPause.Click += new System.EventHandler(this.btn_PlayPause_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.Location = new System.Drawing.Point(523, 352);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(75, 35);
            this.btn_Next.TabIndex = 2;
            this.btn_Next.Text = " ";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // lbl_SongName
            // 
            this.lbl_SongName.AutoSize = true;
            this.lbl_SongName.Location = new System.Drawing.Point(168, 238);
            this.lbl_SongName.Name = "lbl_SongName";
            this.lbl_SongName.Size = new System.Drawing.Size(46, 17);
            this.lbl_SongName.TabIndex = 3;
            this.lbl_SongName.Text = "label1";
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(604, 12);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(130, 35);
            this.btn_Add.TabIndex = 4;
            this.btn_Add.Text = "Add Music";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_AddQueue
            // 
            this.btn_AddQueue.Location = new System.Drawing.Point(604, 91);
            this.btn_AddQueue.Name = "btn_AddQueue";
            this.btn_AddQueue.Size = new System.Drawing.Size(130, 35);
            this.btn_AddQueue.TabIndex = 5;
            this.btn_AddQueue.Text = "Add Queue";
            this.btn_AddQueue.UseVisualStyleBackColor = true;
            this.btn_AddQueue.Click += new System.EventHandler(this.btn_AddQueue_Click);
            // 
            // btn_RemoveSong
            // 
            this.btn_RemoveSong.Location = new System.Drawing.Point(604, 173);
            this.btn_RemoveSong.Name = "btn_RemoveSong";
            this.btn_RemoveSong.Size = new System.Drawing.Size(130, 35);
            this.btn_RemoveSong.TabIndex = 6;
            this.btn_RemoveSong.Text = "Remove Song";
            this.btn_RemoveSong.UseVisualStyleBackColor = true;
            this.btn_RemoveSong.Click += new System.EventHandler(this.btn_RemoveSong_Click);
            // 
            // lbl_TotalDuration
            // 
            this.lbl_TotalDuration.AutoSize = true;
            this.lbl_TotalDuration.Location = new System.Drawing.Point(605, 281);
            this.lbl_TotalDuration.Name = "lbl_TotalDuration";
            this.lbl_TotalDuration.Size = new System.Drawing.Size(46, 17);
            this.lbl_TotalDuration.TabIndex = 7;
            this.lbl_TotalDuration.Text = "label1";
            // 
            // lbl_CurrentPosition
            // 
            this.lbl_CurrentPosition.AutoSize = true;
            this.lbl_CurrentPosition.Location = new System.Drawing.Point(116, 281);
            this.lbl_CurrentPosition.Name = "lbl_CurrentPosition";
            this.lbl_CurrentPosition.Size = new System.Drawing.Size(46, 17);
            this.lbl_CurrentPosition.TabIndex = 8;
            this.lbl_CurrentPosition.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 450);
            this.Controls.Add(this.lbl_CurrentPosition);
            this.Controls.Add(this.lbl_TotalDuration);
            this.Controls.Add(this.btn_RemoveSong);
            this.Controls.Add(this.btn_AddQueue);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.lbl_SongName);
            this.Controls.Add(this.btn_Next);
            this.Controls.Add(this.btn_PlayPause);
            this.Controls.Add(this.btn_Previous);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.songList);
            this.Name = "Form1";
            this.Text = "Mp3 Player";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox songList;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Button btn_Previous;
        private System.Windows.Forms.Button btn_PlayPause;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Label lbl_SongName;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_AddQueue;
        private System.Windows.Forms.Button btn_RemoveSong;
        private System.Windows.Forms.Label lbl_TotalDuration;
        private System.Windows.Forms.Label lbl_CurrentPosition;
    }
}

