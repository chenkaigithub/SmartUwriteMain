using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIMTClassLibrary
{
    public partial class ucAuthorInfo : UserControl
    {
        private int count;
        private Author item;

        public ucAuthorInfo()
        {
            InitializeComponent();
        }

        public ucAuthorInfo(Author author)
        {
            InitializeComponent();
            this.author = author;
            first.Text = author.name.fore;
            last.Text = author.name.last;
            full.Text = author.name.full;
            no.Text = "第" + count + "作者：";
        }

        public ucAuthorInfo(int count, Author author)
        {
            InitializeComponent();
            this.author = author;
            this.count = count;
            first.Text = author.name.fore;
            last.Text = author.name.last;
            full.Text = author.name.full;
            no.Text = "第" + count + "作者";
        }

        public string getFore()
        {
            return first.Text;
        }

        public string getLast()
        {
            return last.Text;
        }

        public string getFull()
        {
            return full.Text;
        }

        public Author author { get; set; }
    }
}
