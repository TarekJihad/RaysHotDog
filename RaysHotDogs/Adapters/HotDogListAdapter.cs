using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RaysHotDogs.Core.Model;
using RaysHotDogs.Utility;

namespace RaysHotDogs.Adapters
{
    public class HotDogListAdapter : BaseAdapter<HotDog>
    {
        List<HotDog> items;
        Activity context;
        public HotDogListAdapter(List<HotDog> items, Activity context) :base()
        {
            this.items = items;
            this.context = context;
        }
        public override HotDog this[int position] => items[position];

        public override int Count => items.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            //if(convertView == null)
            //{
            //    convertView = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            //}
            //convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Name;

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://gillcleerenpluralsight.blob.core.windows.net/files/" + item.ImagePath + ".jpg");
            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.HotDogRowView, null);
            }
            convertView.FindViewById<ImageView>(Resource.Id.hotDogImageView).SetImageBitmap(imageBitmap);
            convertView.FindViewById<TextView>(Resource.Id.hotDogNameTextView).Text = item.Name;
            convertView.FindViewById<TextView>(Resource.Id.shortDescriptionTextView).Text = item.ShortDescription;
            convertView.FindViewById<TextView>(Resource.Id.priceTextView).Text = "$ " + item.Price;
            return convertView;
        }
    }
}