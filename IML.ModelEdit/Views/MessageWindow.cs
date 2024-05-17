using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IML.ModelEdit
{
  public partial class MessageWindow : Form
  {
    public MessageWindow ()
    {
      InitializeComponent();
    }

    public static void Show(string message, object content)
    {
      MessageWindow window = new MessageWindow();
      window.MessageBox.Text = message;
      if (content is IEnumerable)
      {
        ListBox listBox = new ListBox();
        foreach (object item in (content as IEnumerable))
          listBox.Items.Add(item);
        listBox.Dock = DockStyle.Fill;
        listBox.ScrollAlwaysVisible = false;
        listBox.HorizontalScrollbar = true;
        window.ContentPanel.Controls.Add(listBox);
      }
      else
      {
        TextBox textBox = new TextBox();
        textBox.Text = content.ToString();
        textBox.Dock = DockStyle.Fill;
        textBox.ReadOnly = true;
        window.ContentPanel.Controls.Add(textBox);
      }
      window.ShowDialog();
    }
  }
}
