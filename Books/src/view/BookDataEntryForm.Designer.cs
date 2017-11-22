using System;
using System.Collections.Generic;

namespace Books
{
    partial class BookDataEntryForm
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

        #region

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookDataEntryForm));
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.releaseDateLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.picturePicker = new Books.PicturePicker();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(150, 257);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker.TabIndex = 0;
            this.dateTimePicker.Validating += new System.ComponentModel.CancelEventHandler(this.OnDateValidating);
            this.dateTimePicker.Validated += new System.EventHandler(this.OnDateValidated);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(122, 69);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(100, 22);
            this.titleTextBox.TabIndex = 1;
            this.titleTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.OnTitleValidating);
            this.titleTextBox.Validated += new System.EventHandler(this.OnTitleValidated);
            // 
            // authorTextBox
            // 
            this.authorTextBox.Location = new System.Drawing.Point(122, 133);
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.Size = new System.Drawing.Size(100, 22);
            this.authorTextBox.TabIndex = 2;
            this.authorTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.OnAuthorValidating);
            this.authorTextBox.Validated += new System.EventHandler(this.OnAuthorValidated);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(81, 72);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(39, 17);
            this.titleLabel.TabIndex = 4;
            this.titleLabel.Text = "Title:";
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(66, 136);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(54, 17);
            this.authorLabel.TabIndex = 5;
            this.authorLabel.Text = "Author:";
            // 
            // releaseDateLabel
            // 
            this.releaseDateLabel.AutoSize = true;
            this.releaseDateLabel.Location = new System.Drawing.Point(203, 225);
            this.releaseDateLabel.Name = "releaseDateLabel";
            this.releaseDateLabel.Size = new System.Drawing.Size(98, 17);
            this.releaseDateLabel.TabIndex = 6;
            this.releaseDateLabel.Text = "Release Date:";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(280, 105);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(69, 17);
            this.categoryLabel.TabIndex = 7;
            this.categoryLabel.Text = "Category:";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(122, 340);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 8;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OnOKButtonClicked);
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.Location = new System.Drawing.Point(312, 340);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.OnCancelButtonClicked);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // picturePicker
            // 
            this.picturePicker.Description = "POETRY";
            this.picturePicker.Location = new System.Drawing.Point(355, 105);
            this.picturePicker.Name = "picturePicker";
            this.picturePicker.Size = new System.Drawing.Size(110, 92);
            this.picturePicker.TabIndex = 10;
            this.picturePicker.ImageChanged += new System.EventHandler(this.OnImageChanged);
            // 
            // BookDataEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 400);
            this.Controls.Add(this.picturePicker);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.releaseDateLabel);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.authorTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.dateTimePicker);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BookDataEntryForm";
            this.Text = "Create Book";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.DateTimePicker dateTimePicker;
        protected System.Windows.Forms.TextBox titleTextBox;
        protected System.Windows.Forms.TextBox authorTextBox;
        protected System.Windows.Forms.Label titleLabel;
        protected System.Windows.Forms.Label authorLabel;
        protected System.Windows.Forms.Label releaseDateLabel;
        protected System.Windows.Forms.Label categoryLabel;
        protected System.Windows.Forms.Button OKButton;
        protected System.Windows.Forms.Button cancelButton;
        protected System.Windows.Forms.ErrorProvider errorProvider;
        protected PicturePicker picturePicker;
    }
}