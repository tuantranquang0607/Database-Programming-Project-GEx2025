using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCollectionManagment
{
    internal static class UIUtilities
    {
        /// <summary>
        /// Clear windows control container extension
        /// </summary>
        /// <param name="controls">The controls collection</param>
        public static void ClearControls(this Control.ControlCollection controls)
        {
            foreach (Control ctl in controls)
            {
                switch (ctl)
                {
                    case TextBox txt:
                        txt.Clear();
                        break;
                    case CheckBox chk:
                        chk.Checked = false;
                        break;
                    case GroupBox gB:
                        ClearControls(gB.Controls);
                        break;
                }
            }
        }

        /// <summary>
        /// Extension method for binding a combobox to a datatable
        /// </summary>
        /// <param name="cmb">The combobox to bind to the datatable</param>
        /// <param name="dt">The datatable records</param>
        /// <param name="displayMember">The display value to show in the combobox</param>
        /// <param name="valueMember">The value of the selected item in the combobox</param>
        public static void Bind(this ComboBox cmb, DataTable dt, string displayMember, string valueMember)
        {
            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;
            cmb.DataSource = dt;
        }

        public static void Bind(this ComboBox cmb, DataTable dt, string displayMember, string valueMember, string defaultValue)
        {
            DataRow dr = dt.NewRow();
            dr[displayMember] = defaultValue;
            dr[valueMember] = DBNull.Value;

            dt.Rows.InsertAt(dr, 0);

            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;
            cmb.DataSource = dt;
        }
    }
}
