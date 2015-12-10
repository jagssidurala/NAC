using System;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI;
using System.Collections;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for DataGridTemplate.
	/// </summary>
	public class DataGridTemplate : System.Web.UI.Page,ITemplate 
	{
		ListItemType templateType;
		string columnName;		

		public void InstantiateIn(System.Web.UI.Control container) 
		{

			Literal lc = new Literal();
			//CheckBox chkb=new CheckBox();
			//LinkButton lb = new LinkButton(); 

			switch(templateType)

			{

				case ListItemType.Header:

					lc.Text = "<B>" + columnName + "</B>";
					
					//chkb.Text = "Select"; 
					//lb.CommandName = "EditButton"; 
					//container.Controls.Add(chkb);
					container.Controls.Add(lc);

					break;

				case ListItemType.Item:

					//lc.Text=columnName;
					//lc.Text = "Select " + columnName;
					//chkb.Text = "Select"; 

					//chkb.ID=columnName;
					//container.Controls.Add(chkb);
					container.Controls.Add(lc);

					break;

				case ListItemType.EditItem:

					TextBox tb = new TextBox();
					tb.Text = "";
					container.Controls.Add(tb);
					break;

				case ListItemType.Footer:

					lc.Text = "<I>" + columnName + "</I>";
					container.Controls.Add(lc);
					break;

 

			}

		}

		public DataGridTemplate(ListItemType type, string colname)
		{
			templateType = type;
			columnName = colname;
		}
	}
}
