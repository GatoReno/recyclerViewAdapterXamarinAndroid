using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ListAdapterPractice.Models;

namespace ListAdapterPractice.Resources.DataSource
{
    public class RecyclerViewAdapterContacts : RecyclerView.Adapter //, View.IOnClickListener
    {
        public EventHandler<ContactAdapterClickEventArgs> ItemClick;

        IList<Contact> _items;

        public RecyclerViewAdapterContacts(IList<Contact> data)
        {
            this._items = data;
        }
        public override int ItemCount => _items.Count;


        public override void OnBindViewHolder(RecyclerView.ViewHolder viewholder, int position)
        {
            var holder = viewholder as ContactAdapterViewHolder;
            holder.email_row.Text = _items[position].Email;
            var subpass = _items[position].Password;
            holder.password_row.Text = "****" + subpass.Substring(subpass.Length - 4);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.contact_file, parent, false);
            var vholder = new ContactAdapterViewHolder(itemView, OnClick);
            return vholder;
        }

        private void OnClick(ContactAdapterClickEventArgs args)
        {
            var contact = _items[args.Position];
            args.Contact = contact;
            ItemClick?.Invoke(this, args);
        }
    }

    public class ContactAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
        public Contact Contact { get; set; }
    }

    public class ContactAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView email_row { get; set; }
        public TextView password_row { get; set; }

        public ContactAdapterViewHolder(View itemView, Action<ContactAdapterClickEventArgs> clickListener) : base(itemView)
        {
            email_row = (TextView)itemView.FindViewById(Resource.Id.email_row);
            password_row = (TextView)itemView.FindViewById(Resource.Id.password_row);
            itemView.Click += (sender, e) => clickListener(new ContactAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }
}
