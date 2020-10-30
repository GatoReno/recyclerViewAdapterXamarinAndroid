using System;
using Android.Views;
using Android.Widget;

namespace ListAdapterPractice.Resources.DataSource
{
    public class ContactHolder : Android.Support.V7.Widget.RecyclerView.ViewHolder
    {

        public View Item { get; private set; }
        public TextView Email { get; set; }
        public TextView Password { get; set; }

        public ContactHolder(View itemView) : base(itemView)
        {
            this.Item = itemView;
            this.Email = itemView.FindViewById<TextView>(Resource.Id.email_row);
            this.Password = itemView.FindViewById<TextView>(Resource.Id.password_row);

        }
    }
}
