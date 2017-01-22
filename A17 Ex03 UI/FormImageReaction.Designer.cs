namespace A17_Ex03_UI
{
    partial class FormImageReaction
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
            System.Windows.Forms.Label createdTimeLabel;
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label likedByUserLabel;
            System.Windows.Forms.Label likesCountLabel;
            System.Windows.Forms.Label messageLabel;
            this.buttonComment = new System.Windows.Forms.Button();
            this.buttonShare = new System.Windows.Forms.Button();
            this.textBoxAddAComment = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBoxSelectedPicture = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.commentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.createdTimeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.likedByUserCheckBox = new System.Windows.Forms.CheckBox();
            this.likesCountTextBox = new System.Windows.Forms.TextBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            createdTimeLabel = new System.Windows.Forms.Label();
            idLabel = new System.Windows.Forms.Label();
            likedByUserLabel = new System.Windows.Forms.Label();
            likesCountLabel = new System.Windows.Forms.Label();
            messageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedPicture)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonComment
            // 
            this.buttonComment.Location = new System.Drawing.Point(32, 938);
            this.buttonComment.Name = "buttonComment";
            this.buttonComment.Size = new System.Drawing.Size(168, 59);
            this.buttonComment.TabIndex = 16;
            this.buttonComment.Text = "Comment";
            this.buttonComment.UseVisualStyleBackColor = true;
            this.buttonComment.Click += new System.EventHandler(this.buttonComment_Click);
            // 
            // buttonShare
            // 
            this.buttonShare.Location = new System.Drawing.Point(227, 938);
            this.buttonShare.Name = "buttonShare";
            this.buttonShare.Size = new System.Drawing.Size(168, 59);
            this.buttonShare.TabIndex = 17;
            this.buttonShare.Text = "Share";
            this.buttonShare.UseVisualStyleBackColor = true;
            this.buttonShare.Click += new System.EventHandler(this.buttonShare_Click);
            // 
            // textBoxAddAComment
            // 
            this.textBoxAddAComment.Location = new System.Drawing.Point(32, 829);
            this.textBoxAddAComment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxAddAComment.Multiline = true;
            this.textBoxAddAComment.Name = "textBoxAddAComment";
            this.textBoxAddAComment.Size = new System.Drawing.Size(1062, 56);
            this.textBoxAddAComment.TabIndex = 20;
            this.textBoxAddAComment.Text = "Add a comment  / Share with status";
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.commentBindingSource;
            this.listBox1.DisplayMember = "Message";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(1133, 59);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(187, 729);
            this.listBox1.TabIndex = 21;
            // 
            // pictureBoxSelectedPicture
            // 
            this.pictureBoxSelectedPicture.BackColor = System.Drawing.Color.White;
            this.pictureBoxSelectedPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxSelectedPicture.Location = new System.Drawing.Point(32, 59);
            this.pictureBoxSelectedPicture.Name = "pictureBoxSelectedPicture";
            this.pictureBoxSelectedPicture.Size = new System.Drawing.Size(1062, 727);
            this.pictureBoxSelectedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSelectedPicture.TabIndex = 19;
            this.pictureBoxSelectedPicture.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(createdTimeLabel);
            this.panel1.Controls.Add(this.createdTimeDateTimePicker);
            this.panel1.Controls.Add(idLabel);
            this.panel1.Controls.Add(this.idTextBox);
            this.panel1.Controls.Add(likedByUserLabel);
            this.panel1.Controls.Add(this.likedByUserCheckBox);
            this.panel1.Controls.Add(likesCountLabel);
            this.panel1.Controls.Add(this.likesCountTextBox);
            this.panel1.Controls.Add(messageLabel);
            this.panel1.Controls.Add(this.messageTextBox);
            this.panel1.Location = new System.Drawing.Point(1356, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 729);
            this.panel1.TabIndex = 22;
            // 
            // commentBindingSource
            // 
            this.commentBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.Comment);
            // 
            // createdTimeLabel
            // 
            createdTimeLabel.AutoSize = true;
            createdTimeLabel.Location = new System.Drawing.Point(30, 58);
            createdTimeLabel.Name = "createdTimeLabel";
            createdTimeLabel.Size = new System.Drawing.Size(147, 25);
            createdTimeLabel.TabIndex = 0;
            createdTimeLabel.Text = "Created Time:";
            // 
            // createdTimeDateTimePicker
            // 
            this.createdTimeDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.commentBindingSource, "CreatedTime", true));
            this.createdTimeDateTimePicker.Location = new System.Drawing.Point(188, 54);
            this.createdTimeDateTimePicker.Name = "createdTimeDateTimePicker";
            this.createdTimeDateTimePicker.Size = new System.Drawing.Size(273, 31);
            this.createdTimeDateTimePicker.TabIndex = 1;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(30, 94);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(35, 25);
            idLabel.TabIndex = 2;
            idLabel.Text = "Id:";
            // 
            // idTextBox
            // 
            this.idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.commentBindingSource, "Id", true));
            this.idTextBox.Location = new System.Drawing.Point(188, 91);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(273, 31);
            this.idTextBox.TabIndex = 3;
            // 
            // likedByUserLabel
            // 
            likedByUserLabel.AutoSize = true;
            likedByUserLabel.Location = new System.Drawing.Point(30, 133);
            likedByUserLabel.Name = "likedByUserLabel";
            likedByUserLabel.Size = new System.Drawing.Size(152, 25);
            likedByUserLabel.TabIndex = 4;
            likedByUserLabel.Text = "Liked By User:";
            // 
            // likedByUserCheckBox
            // 
            this.likedByUserCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.commentBindingSource, "LikedByUser", true));
            this.likedByUserCheckBox.Location = new System.Drawing.Point(188, 128);
            this.likedByUserCheckBox.Name = "likedByUserCheckBox";
            this.likedByUserCheckBox.Size = new System.Drawing.Size(273, 24);
            this.likedByUserCheckBox.TabIndex = 5;
            this.likedByUserCheckBox.Text = "checkBox1";
            this.likedByUserCheckBox.UseVisualStyleBackColor = true;
            // 
            // likesCountLabel
            // 
            likesCountLabel.AutoSize = true;
            likesCountLabel.Location = new System.Drawing.Point(30, 167);
            likesCountLabel.Name = "likesCountLabel";
            likesCountLabel.Size = new System.Drawing.Size(132, 25);
            likesCountLabel.TabIndex = 6;
            likesCountLabel.Text = "Likes Count:";
            // 
            // likesCountTextBox
            // 
            this.likesCountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.commentBindingSource, "LikesCount", true));
            this.likesCountTextBox.Location = new System.Drawing.Point(188, 164);
            this.likesCountTextBox.Name = "likesCountTextBox";
            this.likesCountTextBox.Size = new System.Drawing.Size(273, 31);
            this.likesCountTextBox.TabIndex = 7;
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.Location = new System.Drawing.Point(30, 204);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new System.Drawing.Size(106, 25);
            messageLabel.TabIndex = 8;
            messageLabel.Text = "Message:";
            // 
            // messageTextBox
            // 
            this.messageTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.commentBindingSource, "Message", true));
            this.messageTextBox.Location = new System.Drawing.Point(188, 201);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(273, 31);
            this.messageTextBox.TabIndex = 9;
            // 
            // FormImageReaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1906, 1056);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBoxAddAComment);
            this.Controls.Add(this.pictureBoxSelectedPicture);
            this.Controls.Add(this.buttonShare);
            this.Controls.Add(this.buttonComment);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormImageReaction";
            this.Text = "ImageReaction";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedPicture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonComment;
        private System.Windows.Forms.Button buttonShare;
        private System.Windows.Forms.PictureBox pictureBoxSelectedPicture;
        private System.Windows.Forms.TextBox textBoxAddAComment;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.BindingSource commentBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker createdTimeDateTimePicker;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.CheckBox likedByUserCheckBox;
        private System.Windows.Forms.TextBox likesCountTextBox;
        private System.Windows.Forms.TextBox messageTextBox;
    }
}